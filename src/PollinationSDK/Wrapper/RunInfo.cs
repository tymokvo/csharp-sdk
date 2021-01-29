using PollinationSDK.Api;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using QueenbeeSDK;
using System.Collections.Generic;

namespace PollinationSDK.Wrapper
{
    public class RunInfo
    {
        public string RunID => this.Run.Id;
        public Run Run { get; private set; }
        public Project Project { get; private set; }
        public RecipeInterface Recipe { get; private set; }

        //[IgnoreDataMember]
        //public string Logs { get; set; }
        public RunInfo(Project proj, string runID): this(proj, GetRun(proj, runID))
        {
        }

        public RunInfo(Project proj, Run run)
        {
            this.Run = run;
            this.Project = proj;
            this.Recipe = GetRecipe(this.Run.Job.Source);
        }

        public RunInfo(string localRunPath)
        {
        }

        private static Run GetRun(Project proj, string runID)
        {
            var api = new RunsApi();
            var run = api.GetRun(proj.Owner.Name, proj.Name, runID.ToString());
            return run;
        }

        private static RecipeInterface GetRecipe(string url)
        {
            Helper.GetRecipeFromRecipeSourceURL(url, out var recipe);
            return recipe;
        }


        public override string ToString()
        {
            //var jobId = _Job.Name ?? JobRunID;
            return $"{this.Project.Owner.Name}/{this.Project.Name}/{this.RunID}";
        }

        public async Task<string> WatchRunStatusAsync(Action<string> progressAction = default, System.Threading.CancellationToken cancelToken = default)
        {
            var api = new RunsApi();
            var proj = this.Project;
            var simuId = this.RunID;

            var run = api.GetRun(proj.Owner.Name, proj.Name, simuId);
            var status = run.Status;
            var startTime = status.StartedAt;
            while (status.FinishedAt <= status.StartedAt)
            {
                var currentSeconds = Math.Round((DateTime.UtcNow - startTime).TotalSeconds);
                // wait 5 seconds before calling api to re-check the status
                var totalDelaySeconds = status.Status == "Scheduled" ? 3 : 5;
                for (int i = 0; i < totalDelaySeconds; i++)
                {
                    progressAction?.Invoke($"{status.Status}: [{GetUserFriendlyTimeCounter(TimeSpan.FromSeconds(currentSeconds))}]");
                    await Task.Delay(1000);
                    currentSeconds++;
                    // suspended by user
                    if (cancelToken.IsCancellationRequested) break;
                }
                // suspended by user
                if (cancelToken.IsCancellationRequested) break;


                // update status
                await Task.Delay(1000);
                run = api.GetRun(proj.Owner.Name, proj.Name, simuId);
                status = run.Status;
                //_simulation = new Simulation(proj, simuId);
            }
            this.Run = run;
            // suspended by user
            if (cancelToken.IsCancellationRequested)
            {
                StopSimulaiton();
                return "Canceled";
            }
            var totalTime = status.FinishedAt - startTime;
            var finishMessage = status.Status == "Succeeded" ? $"✔ {status.Status}" : $"❌ {status.Status}";
            //progressAction?.Invoke($"Task: {status.Status}");

            if (cancelToken.IsCancellationRequested) return "Canceled";
            finishMessage = $"{finishMessage}: [{GetUserFriendlyTimeCounter(totalTime)}]";
            progressAction?.Invoke(finishMessage);
            return finishMessage;

            string GetUserFriendlyTimeCounter(TimeSpan timeDelta)
            {
                string format = @"hh\:mm\:ss";
                if (timeDelta.Days > 0)
                    format = @"d\ hh\:mm\:ss";
                else if (timeDelta.Hours > 0)
                    format = @"hh\:mm\:ss";
                else if (timeDelta.Minutes > 0)
                    format = @"mm\:ss";
                else
                    format = @"ss";
                return timeDelta.ToString(format);
            }
        }

        public void StopSimulaiton()
        {
            var proj = this.Project;
            var simuId = this.RunID;
            var api = new RunsApi();
            api.StopRunAsync(proj.Owner.Name, proj.Name, simuId);
        }



        /// <summary>
        /// Download all log for a simulation and combine it into one text format
        /// </summary>
        /// <param name="progressAction"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public async Task<string> GetSimulationOutputLogAsync(Action<string> progressAction = default, System.Threading.CancellationToken cancelToken = default)
        {
            // get task log ids 
            if (cancelToken.IsCancellationRequested) return string.Empty;
            progressAction?.Invoke($"Getting log IDs");
            var proj = this.Project;
            var simuId = this.RunID;
            var api = new RunsApi();
            var job = api.GetRun(proj.Owner.Name, proj.Name, simuId);
            var status = job.Status;
            if (status.Status == "Running") throw new ArgumentException("Simulation is still running, please wait until it's done!");
            var taskDic = status.Steps.OrderBy(_ => _.Value.StartedAt).ToDictionary(_ => _.Key, _ => $"[{_.Key}]\n{_.Value.StartedAt.ToLocalTime()} : {_.Value.Name}");
            var taskIDs = taskDic.Keys;

            //Download file
            if (cancelToken.IsCancellationRequested) return string.Empty;
            progressAction?.Invoke($"Downloading logs");

            //var url = api.GetSimulationLogs(proj.Owner.Name, proj.Name, simuId).ToString();
            var url = "";
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("Failed to call GetSimulationLogs");
            var dir = Path.Combine(Helper.GenTempFolder(), simuId);
            var downloadfile = await Helper.DownloadFromUrlAsync(url, dir);


            //unzip file 
            if (cancelToken.IsCancellationRequested) return string.Empty;
            progressAction?.Invoke($"Reading logs");
            Helper.Unzip(downloadfile, dir, true);



            //read logs
            if (cancelToken.IsCancellationRequested) return string.Empty;
            var taskFiles = Directory.GetFiles(dir, "*.log", SearchOption.AllDirectories);
            var totalCount = taskIDs.Count;
            var current = 0;
            foreach (var logFile in taskFiles)
            {
                if (cancelToken.IsCancellationRequested) break;

                var logID = new DirectoryInfo(Path.GetDirectoryName(logFile)).Name;
                if (!taskIDs.Contains(logID)) continue;

                var logHeader = taskDic[logID];
                var logContent = File.ReadAllText(logFile);
                logContent = string.IsNullOrWhiteSpace(logContent) ? "No log available for this task." : logContent;
                taskDic[logID] = $"{logHeader} \n{logContent}";
                current++;

                progressAction?.Invoke($"Reading logs [{current}/{totalCount}]");
            }

            var fullLog = string.Join("\n\n", taskDic.Values);
            return fullLog;
        }

        //private static async Task<string> DownloadFile(string url, string dir)
        //{
        //    var request = new RestRequest(Method.GET);
        //    var client = new RestClient(url.ToString());
        //    var response = await client.ExecuteAsync(request);
        //    if (response.StatusCode != HttpStatusCode.OK)
        //        throw new Exception($"Unable to download file");

        //    // prep file path
        //    var fileName = Path.GetFileName(url).Split(new[] { '?' })[0];
        //    var tempDir = string.IsNullOrEmpty(dir) ? Path.Combine(Path.GetTempPath(), "Pollination", Path.GetRandomFileName()) : dir;
        //    Directory.CreateDirectory(tempDir);
        //    var file = Path.Combine(tempDir, fileName);

        //    var b = response.RawBytes;
        //    File.WriteAllBytes(file, b);

        //    if (!File.Exists(file)) throw new ArgumentException($"Failed to download {fileName}");
        //    return file;
        //}

        private static void CheckOutputLogs(RunsApi api, Project proj, string simuId)
        {
            //var api = new RunsApi();
            var steps = api.GetRunSteps(proj.Owner.Name, proj.Name, simuId.ToString());
            foreach (var item in steps.Resources)
            {
                var stepLog = api.GetRunStepLogs(proj.Owner.Name, proj.Name, simuId.ToString(), item.Id);
                Console.WriteLine(stepLog);
            }

        }


        /// <summary>
        /// Download a list of OutputArtifacts from a simulation.
        /// </summary>
        /// <param name="inputAssetPaths">asset name, relative path to project folder of file or folder </param>
        /// <param name="outputAssets">output name</param>
        /// <param name="saveAsDir"></param>
        /// <param name="reportProgressAction"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, List<string>>> DownloadRunAssetsAsync(Dictionary<string, string> inputAssetPaths, List<string> outputAssets, string saveAsDir = default, Action<int> reportProgressAction = default, bool useCached = false)
        {
            //_filePaths = new List<string>();
            var downloadedFiles = new Dictionary<string, List<string>>();
            try
            {
                var dir = string.IsNullOrEmpty(saveAsDir) ? Helper.GenTempFolder() : saveAsDir;
                var simuID = this.RunID.Substring(0, 8);
                dir = Path.Combine(dir, simuID);
                var inputDir = Path.Combine(dir, "inputs");
                var outputDir = Path.Combine(dir, "outputs");

                // check if cached
                if (useCached)
                    downloadedFiles = CheckCached(ref inputAssetPaths, ref outputAssets, inputDir, outputDir);

                // assembly download tasks
                var tasks = new List<Task<string>>();
                var inputTasks = DownloadInputArtifact(this, inputAssetPaths, inputDir);
                tasks.AddRange(inputTasks);
                var outputTasks = DownloadOutputArtifact(this, outputAssets, outputDir);
                tasks.AddRange(outputTasks);

                // watching tasks
                var total = tasks.Count();
                var completed = 0;
                while (total - completed < 0)
                {
                    var finishedTask =  await Task.WhenAny(tasks);
                    await finishedTask;
                    completed++;

                    var finishedPercent = completed / (double)total * 100;
                    reportProgressAction?.Invoke((int)finishedPercent);
                }

                var assetNames = inputAssetPaths?.Select(_=> $"IN_{_.Key}")?.ToList() ?? new List<string>();
                assetNames.AddRange(outputAssets?.Select(_ => $"OUT_{_}"));

                // collect all downloaded assets
                var works = assetNames.Zip(tasks, (name, task) => new { name, task });
                foreach (var item in works)
                {
                    var savedFolderOrFilePath = await item.task;
                    var subPaths = CheckIfFolderPath(savedFolderOrFilePath);
                    downloadedFiles.Add(item.name, subPaths);
                }
            
            }
            catch (Exception e)
            {
                throw e;
            }

            return downloadedFiles;
            //return finished;

            List<string> CheckIfFolderPath(string p)
            {
                if (Directory.Exists(p))
                {
                    var items = Directory.EnumerateFileSystemEntries(p, "*", SearchOption.TopDirectoryOnly);
                    var itemPaths = items.Any() ? items.ToList() : new List<string>() { p };
                    return itemPaths;
                }
                else
                {
                    return new List<string>() { p };
                }
            }
        }

        private static Dictionary<string, List<string>> CheckCached(ref Dictionary<string, string> inputAssetPaths, ref List<string> outputAssets,  string inputDir, string outputDir)
        {
            var downloadedFiles = new Dictionary<string, List<string>>();

            var nonCachedInputAssets = new Dictionary<string, string>();
            foreach (var item in inputAssetPaths)
            {
                var assetDir = Path.Combine(inputDir, item.Key);
                var cached = Directory.EnumerateFileSystemEntries(assetDir, "*", SearchOption.TopDirectoryOnly).ToList();
                if (cached.Any())
                    downloadedFiles.Add($"IN_{item.Key}", cached);
                else
                    nonCachedInputAssets.Add(item.Key, item.Value);
            }
            // override the inputs
            inputAssetPaths = nonCachedInputAssets;

            var nonCachedOutputAssets = new List<string>();
            foreach (var item in outputAssets)
            {
                var assetDir = Path.Combine(outputDir, item);
                var cached = Directory.EnumerateFileSystemEntries(assetDir, "*", SearchOption.TopDirectoryOnly).ToList();
                if (cached.Any())
                    downloadedFiles.Add($"OUT_{item}", cached);
                else
                    nonCachedOutputAssets.Add(item);
            }
            // override the outputs
            outputAssets = nonCachedOutputAssets;

            return downloadedFiles;
        }




        /// <summary>
        /// Download output assets with one call
        /// </summary>
        /// <param name="runInfo"></param>
        /// <param name="artifactName"></param>
        /// <param name="saveAsDir"></param>
        /// <returns></returns>
        private static List<Task<string>> DownloadOutputArtifact(RunInfo runInfo, List<string> artifactNames, string saveAsDir)
        {
            var tasks = new List<Task<string>>();
            if (artifactNames == null || !artifactNames.Any()) return tasks;
            var api = new PollinationSDK.Api.RunsApi();
            foreach (var artifactName in artifactNames)
            {
                try
                {
                    var url = api.GetRunOutput(runInfo.Project.Owner.Name, runInfo.Project.Name, runInfo.RunID, artifactName).ToString();
                    var task = Helper.DownloadFromUrlAsync(url, Path.Combine(saveAsDir, artifactName));
                    tasks.Add(task);
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"Failed to download output artifact {artifactName}.\n -{e.Message}");
                }
            }
            return tasks;

        }
        /// <summary>
        /// Download input assets with one call.
        /// </summary>
        /// <param name="runInfo"></param>
        /// <param name="assetPaths">Dictionary of input asset's name and path</param>
        /// <param name="saveAsDir"></param>
        /// <returns></returns>
        private static List<Task<string>> DownloadInputArtifact(RunInfo runInfo, Dictionary<string, string> assetPaths, string saveAsDir)
        {
            var tasks = new List<Task<string>>();
            if (assetPaths == null || !assetPaths.Any()) return tasks;
            var api = new PollinationSDK.Api.RunsApi();
            foreach (var assetPath in assetPaths)
            {
                try
                {
                    var url = api.DownloadRunArtifact(runInfo.Project.Owner.Name, runInfo.Project.Name, runInfo.RunID, path: assetPath.Value).ToString();
                    var task = Helper.DownloadFromUrlAsync(url, Path.Combine(saveAsDir, assetPath.Key));
                    tasks.Add(task);

                }
                catch (Exception e)
                {
                    throw new ArgumentException($"Failed to download input artifact {assetPath.Key}.\n -{e.Message}");
                }
            }
            return tasks;

        }


    }
}
