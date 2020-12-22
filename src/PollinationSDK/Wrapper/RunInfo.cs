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
        public Run Run { get; set; }
        public Project Project { get; set; }
        public RecipeInterface Recipe { get; set; }

        //[IgnoreDataMember]
        //public string Logs { get; set; }
        public RunInfo(Project proj, string runID)
        {
            var api = new RunsApi();
            var run = api.GetRun(proj.Owner.Name, proj.Name, runID.ToString());
            this.Run = run;
            this.Project = proj;
            //this.Recipe = Recipe;
            //this.RunID = run.Id;
        }

        public RunInfo(string localRunPath)
        {

        }

        public override string ToString()
        {
            //var jobId = _Job.Name ?? JobRunID;
            return $"{this.Project.Owner.Name}/{this.Project.Name}/{this.RunID}";
        }

        public async Task CheckStatusAndGetLogsAsync(Action<string> progressAction = default, System.Threading.CancellationToken cancelToken = default)
        {
            var api = new RunsApi();
            var proj = this.Project;
            var simuId = this.RunID;

            var job = api.GetRun(proj.Owner.Name, proj.Name, simuId);
            var status = job.Status;
            var startTime = status.StartedAt;
            while (status.Status == "Running" || status.Status == "Scheduled")
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
                job = api.GetRun(proj.Owner.Name, proj.Name, simuId);
                status = job.Status;
                //_simulation = new Simulation(proj, simuId);
            }
            // suspended by user
            if (cancelToken.IsCancellationRequested)
            {
                StopSimulaiton();
                return;
            }
            var totalTime = DateTime.UtcNow - startTime;
            var finishMessage = status.Status == "Succeeded" ? $"✔ Succeeded" : $"❌ {status.Status}";
            progressAction?.Invoke($"Task: {status.Status}");

            // Only get simulation logs when run toggle is set to true by user
            if (cancelToken.IsCancellationRequested) return;
            //CheckOutputLogs(api, proj, simuId.ToString());
            //var outputs = api.GetSimulationLogs(proj.Owner.Name, proj.Name, simuId.ToString());
            //var logUrl= outputs.ToString();
            //this.Logs = await GetSimulationOutputLogAsync(progressAction, cancelToken);

            progressAction?.Invoke($"{finishMessage}: [{GetUserFriendlyTimeCounter(totalTime)}]");

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
        /// <param name="runInfo"></param>
        /// <param name="artifacts"></param>
        /// <param name="saveAsDir"></param>
        /// <param name="reportProgressAction"></param>
        /// <returns></returns>
        public async Task<List<string>> DownloadOutputArtifactsAsync(List<string> artifacts, string saveAsDir = default, Action<int> reportProgressAction = default)
        {
            //_filePaths = new List<string>();
            var downloadedFiles = new List<string>();
            try
            {
                var dir = string.IsNullOrEmpty(saveAsDir) ? Helper.GenTempFolder() : saveAsDir;
                var simuID = this.RunID.Substring(0, 8);
                dir = Path.Combine(dir, simuID, "outputs");

                var tasks = artifacts.Select(_ => DownloadArtifact(this, _, dir)).ToList();
                //var tasks = artifacts.SelectMany(_ => DownloadArtifactWithItems(simu, _, saveAsDir)).ToList();

                var total = tasks.Count();
                while (tasks.Count() > 0)
                {
                    var finishedTask = await Task.WhenAny(tasks);
                    downloadedFiles.Add(finishedTask.Result);
                    tasks.Remove(finishedTask);

                    var left = tasks.Count();
                    var finishedPercent = (total - left) / (double)total * 100;
                    reportProgressAction?.Invoke((int)finishedPercent);

                }

            }
            catch (Exception e)
            {
                throw e;
            }

            var artifactNames = artifacts.Select(_ => _.ToUpper()).ToList();
            var filePaths = downloadedFiles.OrderBy(_ => artifactNames.IndexOf(Path.GetFileNameWithoutExtension(_).ToUpper())).ToList();

            if (filePaths.Count == 1)
            {
                //if folder, then return items in folder
                var path = filePaths[0];
                if (Directory.Exists(path))
                {
                    var items = Directory.EnumerateFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly);
                    filePaths = items.Any() ? items.ToList() : filePaths;
                }
            }
            return filePaths;
            //return finished;
        }

        /// <summary>
        /// Download an artifact with one call. It'd be a zip file if the artifact is a folder
        /// </summary>
        /// <param name="runInfo"></param>
        /// <param name="artifact"></param>
        /// <param name="saveAsDir"></param>
        /// <returns></returns>
        private static Task<string> DownloadArtifact(RunInfo runInfo, string artifactName, string saveAsDir)
        {
            //var file = string.Empty;
            //var outputDirOrFile = string.Empty;
            try
            {
                var api = new PollinationSDK.Api.RunsApi();
                //var url = api.GetSimulationOutputArtifact(runInfo.Project.Owner.Name, runInfo.Project.Name, runInfo.RunID, artifactName).ToString();
                //var url = "";
                var url = api.GetRunOutput(runInfo.Project.Owner.Name, runInfo.Project.Name, runInfo.RunID, artifactName).ToString();
                var task = Helper.DownloadFromUrlAsync(url, saveAsDir);
                return task;

            }
            catch (Exception e)
            {
                throw new ArgumentException($"Failed to download artifact {artifactName}.\n -{e.Message}");
            }
        }


    }
}
