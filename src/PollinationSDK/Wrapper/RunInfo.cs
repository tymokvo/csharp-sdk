using PollinationSDK.Api;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
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
            this.Recipe = this.Run.Recipe;
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

        //private static RecipeInterface GetRecipe(string url)
        //{
        //    Helper.GetRecipeFromRecipeSourceURL(url, out var recipe);
        //    return recipe;
        //}


        public override string ToString()
        {
            return $"CLOUD:{this.Project.Owner.Name}/{this.Project.Name}/{this.RunID}";
        }


        //public async Task<string> WatchRunStatusAsync(Action<string> progressAction = default, System.Threading.CancellationToken cancelToken = default)
        //{
        //    var api = new RunsApi();
        //    var proj = this.Project;
        //    var simuId = this.RunID;
        //    var run = api.GetRun(proj.Owner.Name, proj.Name, simuId);
        //    var status = run.Status;
        //    var startTime = status.StartedAt;
        //    while (status.FinishedAt <= status.StartedAt)
        //    {
        //        var currentSeconds = Math.Round((DateTime.UtcNow - startTime).TotalSeconds);
        //        // wait 5 seconds before calling api to re-check the status
        //        var isCreatedOrScheduled = status.Status == RunStatusEnum.Created || status.Status == RunStatusEnum.Scheduled;
        //        var totalDelaySeconds = isCreatedOrScheduled ? 3 : 5;
        //        for (int i = 0; i < totalDelaySeconds; i++)
        //        {
        //            // suspended by user
        //            cancelToken.ThrowIfCancellationRequested();

        //            progressAction?.Invoke($"{status.Status}: [{GetUserFriendlyTimeCounter(TimeSpan.FromSeconds(currentSeconds))}]");
        //            await Task.Delay(1000);
        //            currentSeconds++;
        //        }
        //        // suspended by user
        //        cancelToken.ThrowIfCancellationRequested();

        //        // update status
        //        await Task.Delay(1000);
        //        run = api.GetRun(proj.Owner.Name, proj.Name, simuId);
        //        status = run.Status;
        //        //_simulation = new Simulation(proj, simuId);
        //    }
        //    this.Run = run;
        //    // suspended by user
        //    cancelToken.ThrowIfCancellationRequested();

        //    var totalTime = status.FinishedAt - startTime;
        //    var finishMessage = status.Status.ToString();
        //    //progressAction?.Invoke($"Task: {status.Status}");

        //    finishMessage = $"{finishMessage}: [{GetUserFriendlyTimeCounter(totalTime)}]";
        //    progressAction?.Invoke(finishMessage);
        //    return finishMessage;

        //    string GetUserFriendlyTimeCounter(TimeSpan timeDelta)
        //    {
        //        string format = @"hh\:mm\:ss";
        //        if (timeDelta.Days > 0)
        //            format = @"d\ hh\:mm\:ss";
        //        else if (timeDelta.Hours > 0)
        //            format = @"hh\:mm\:ss";
        //        else if (timeDelta.Minutes > 0)
        //            format = @"mm\:ss";
        //        else
        //            format = @"ss";
        //        return timeDelta.ToString(format);
        //    }
        //}





        ///// <summary>
        ///// Download all log for a simulation and combine it into one text format
        ///// </summary>
        ///// <param name="progressAction"></param>
        ///// <param name="cancelToken"></param>
        ///// <returns></returns>
        //public async Task<string> GetSimulationOutputLogAsync(Action<string> progressAction = default, System.Threading.CancellationToken cancelToken = default)
        //{
        //    // get task log ids 
        //    if (cancelToken.IsCancellationRequested) return string.Empty;
        //    progressAction?.Invoke($"Getting log IDs");
        //    var proj = this.Project;
        //    var simuId = this.RunID;
        //    var api = new RunsApi();
        //    var job = api.GetRun(proj.Owner.Name, proj.Name, simuId);
        //    var status = job.Status;
        //    if (status.Status == "Running") throw new ArgumentException("Simulation is still running, please wait until it's done!");
        //    var taskDic = status.Steps.OrderBy(_ => _.Value.StartedAt).ToDictionary(_ => _.Key, _ => $"[{_.Key}]\n{_.Value.StartedAt.ToLocalTime()} : {_.Value.Name}");
        //    var taskIDs = taskDic.Keys;

        //    //Download file
        //    if (cancelToken.IsCancellationRequested) return string.Empty;
        //    progressAction?.Invoke($"Downloading logs");

        //    //var url = api.GetSimulationLogs(proj.Owner.Name, proj.Name, simuId).ToString();
        //    var url = "";
        //    if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("Failed to call GetSimulationLogs");
        //    var dir = Path.Combine(Helper.GenTempFolder(), simuId);
        //    var downloadfile = await Helper.DownloadFromUrlAsync(url, dir);


        //    //unzip file 
        //    if (cancelToken.IsCancellationRequested) return string.Empty;
        //    progressAction?.Invoke($"Reading logs");
        //    Helper.Unzip(downloadfile, dir, true);



        //    //read logs
        //    if (cancelToken.IsCancellationRequested) return string.Empty;
        //    var taskFiles = Directory.GetFiles(dir, "*.log", SearchOption.AllDirectories);
        //    var totalCount = taskIDs.Count;
        //    var current = 0;
        //    foreach (var logFile in taskFiles)
        //    {
        //        if (cancelToken.IsCancellationRequested) break;

        //        var logID = new DirectoryInfo(Path.GetDirectoryName(logFile)).Name;
        //        if (!taskIDs.Contains(logID)) continue;

        //        var logHeader = taskDic[logID];
        //        var logContent = File.ReadAllText(logFile);
        //        logContent = string.IsNullOrWhiteSpace(logContent) ? "No log available for this task." : logContent;
        //        taskDic[logID] = $"{logHeader} \n{logContent}";
        //        current++;

        //        progressAction?.Invoke($"Reading logs [{current}/{totalCount}]");
        //    }

        //    var fullLog = string.Join("\n\n", taskDic.Values);
        //    return fullLog;
        //}

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

        //private static void CheckOutputLogs(RunsApi api, Project proj, string simuId)
        //{
        //    //var api = new RunsApi();
        //    var steps = api.GetRunSteps(proj.Owner.Name, proj.Name, simuId.ToString());
        //    foreach (var item in steps.Resources)
        //    {
        //        var stepLog = api.GetRunStepLogs(proj.Owner.Name, proj.Name, simuId.ToString(), item.Id);
        //        Console.WriteLine(stepLog);
        //    }

        //}


        public List<Interface.Io.Outputs.IDag> GetOutputs()
        {
            var outputs = this.Recipe.Outputs
                .OfType<Interface.Io.Outputs.IDag>().ToList();

            return outputs;
        }


        public List<Interface.Io.Inputs.IStep> GetInputs()
        {
            var inputs = this.Run.Status.Inputs
                  .OfType<Interface.Io.Inputs.IStep>().ToList();
           
            return inputs;
        }


        /// <summary>
        /// Get a run's output assets
        /// </summary>
        /// <returns></returns>
        public List<RunOutputAsset> GetOutputAssets(string platform)
        {
            var cloudSource = this.ToString();
            var assets = this.GetOutputs().Select(_ => new RunOutputAsset(_, platform, cloudSource)).ToList();
            return assets;
        }


        /// <summary>
        /// Get a run's input assets
        /// </summary>
        /// <returns></returns>
        public List<RunInputAsset> GetInputAssets()
        {
            var cloudSource = this.ToString();
            var assets = this.GetInputs().Select(_ => new RunInputAsset(_, cloudSource)).ToList();
            return assets;

        }

        

        public async Task<List<RunAssetBase>> DownloadRunAssetsAsync(List<RunAssetBase> runAssets, string saveAsDir = default, Action<string> reportingAction = default, bool useCached = false)
        {
            var downloadedAssets = new List<RunAssetBase>();

            try
            {
                var dir = string.IsNullOrEmpty(saveAsDir) ? Helper.GenTempFolder() : saveAsDir;
                var simuID = this.RunID.Substring(0, 8);
                dir = Path.Combine(dir, simuID);
                var inputDir = Path.Combine(dir, "inputs");
                var outputDir = Path.Combine(dir, "outputs");

                var inputAssets = runAssets.OfType<RunInputAsset>();
                var outputAssets = runAssets.OfType<RunOutputAsset>();

                // check if cached
                if (useCached)
                {
                    inputAssets = CheckCached(inputAssets, inputDir).OfType<RunInputAsset>();
                    outputAssets = CheckCached(outputAssets, outputDir).OfType<RunOutputAsset>();
                }
                
                // assembly download tasks
                var tasks = new List<Task<string>>();
                var inputTasks = DownloadInputArtifact(this, inputAssets, inputDir);
                tasks.AddRange(inputTasks);
                var outputTasks = DownloadOutputArtifact(this, outputAssets, outputDir);
                tasks.AddRange(outputTasks);

                // watching tasks
                var total = tasks.Count();
                var completed = 0;
                while (total - completed > 0)
                {
                    reportingAction?.Invoke($"0%");
                    var finishedTask = await Task.WhenAny(tasks);
                    await finishedTask;
                    completed++;

                    int finishedPercent = (int)(completed / (double)total * 100);
                    reportingAction?.Invoke($"{finishedPercent}%");
                }
                reportingAction?.Invoke($"{completed}/{total} loaded");

                var allAssets = new List<RunAssetBase>();
                allAssets.AddRange(inputAssets);
                allAssets.AddRange(outputAssets);

                // collect all downloaded assets
                var works = allAssets.Zip(tasks, (asset, task) => new { asset, task });
                foreach (var item in works)
                {
                    var savedFolderOrFilePath = await item.task;
                    var dup = item.asset.Duplicate();
                    dup.LocalPath = savedFolderOrFilePath;
                    downloadedAssets.Add(dup);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return downloadedAssets;

        }

        private static IEnumerable<RunAssetBase> CheckCached(IEnumerable<RunAssetBase> outputAssets, string dir)
        {
            var inputDir = dir;
            var checkedAssets = new List<RunAssetBase>();
            foreach (var item in outputAssets)
            {
                var dupObj = item.Duplicate();
                var isCached = item.CheckIfAssetCached(inputDir);
                if (isCached)
                {
                    var cachedPath = item.GetCachedAsset(inputDir);
                    dupObj.LocalPath = cachedPath;
                }

                checkedAssets.Add(dupObj);
            }
            return checkedAssets;
        }


        /// <summary>
        /// Download output assets with one call
        /// </summary>
        /// <param name="runInfo"></param>
        /// <param name="artifactName"></param>
        /// <param name="saveAsDir"></param>
        /// <returns></returns>
        private static List<Task<string>> DownloadOutputArtifact(RunInfo runInfo, IEnumerable<RunOutputAsset> assets, string saveAsDir)
        {
            var tasks = new List<Task<string>>();
            if (assets == null || !assets.Any()) return tasks;
            var api = new PollinationSDK.Api.RunsApi();
            foreach (var asset in assets)
            {
                try
                {
                    if (asset.IsDownloadable() && !asset.IsSaved())
                    {
                        var url = api.GetRunOutput(runInfo.Project.Owner.Name, runInfo.Project.Name, runInfo.RunID, asset.Name).ToString();
                        var task = Helper.DownloadFromUrlAsync(url, Path.Combine(saveAsDir, asset.Name));
                        tasks.Add(task);
                       
                    }
                    else
                    {
                        tasks.Add(Task.Run(() => asset.LocalPath));
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"Failed to download output artifact {asset.Name}.\n -{e.Message}");
                }
            }
            return tasks;

        }
        /// <summary>
        /// Download input assets with one call.
        /// </summary>
        /// <param name="runInfo"></param>
        /// <param name="assets">RunInputAssets</param>
        /// <param name="saveAsDir"></param>
        /// <returns>Saved path</returns>
        private static List<Task<string>> DownloadInputArtifact(RunInfo runInfo, IEnumerable<RunInputAsset> assets, string saveAsDir)
        {
            var tasks = new List<Task<string>>();
            if (assets == null || !assets.Any()) return tasks;
            var api = new PollinationSDK.Api.RunsApi();
            foreach (var asset in assets)
            {
                try
                {
                    if (asset.IsDownloadable() && !asset.IsSaved())
                    {
                        var url = api.DownloadRunArtifact(runInfo.Project.Owner.Name, runInfo.Project.Name, runInfo.RunID, path: asset.CloudPath).ToString();
                        var task = Helper.DownloadFromUrlAsync(url, Path.Combine(saveAsDir, asset.Name));
                        tasks.Add(task);
                    }
                    else
                    {
                        tasks.Add(Task.Run(() => asset.LocalPath));
                    }
          
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"Failed to download input artifact {asset.Name}.\n -{e.Message}");
                }
            }
            return tasks;

        }


    }
}
