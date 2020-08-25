using Newtonsoft.Json;
using PollinationSDK.Api;
using PollinationSDK.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PollinationSDK.Wrapper
{
    /// <summary>
    /// Simulation wrapper contains the project (ProjectDto), and simulationID for tracking the simulation.
    /// </summary>
    public class Simulation
    {
        // keep all setters public, so that JsonConvert can DeserializeObject it. 
        public ProjectDto Project { get; set; }
        public string SimulationID { get; set; }

        [IgnoreDataMember]
        public string Logs { get; set; }
        public Simulation(ProjectDto proj, string simuId)
        {
            this.Project = proj;
            this.SimulationID = simuId;
        }

        public override string ToString()
        {
            return $"{this.Project.Owner.Name}/{this.Project.Name}/{this.SimulationID}"; 
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Simulation FromJson(string json)
        {
            var obj =  JsonConvert.DeserializeObject<Simulation>(json);
            return obj;
        }

        public Simulation Duplicate()
        {
            return FromJson(this.ToJson());
        }

        public async Task CheckStatusAndGetLogsAsync(Action<string> progressAction = default, System.Threading.CancellationToken cancelToken = default)
        {
            var api = new SimulationsApi();
            var proj = this.Project;
            var simuId = this.SimulationID;

            var status =  await api.GetSimulationAsync(proj.Owner.Name, proj.Name, simuId);
            var startTime = status.StartedAt.ToUniversalTime();
            while (status.Status == "Running")
            {
                var currentSeconds = Math.Round((DateTime.UtcNow - startTime).TotalSeconds);
                // wait 5 seconds before calling api to re-check the status
                for (int i = 0; i < 5; i++)
                {
                    await Task.Delay(1000);
                    currentSeconds++;
                    progressAction?.Invoke($"{status.Status}: [{currentSeconds} s]");

                    // suspended by user
                    if (cancelToken.IsCancellationRequested) break;
                }
                // suspended by user
                if (cancelToken.IsCancellationRequested) break;


                // update status
                status = await api.GetSimulationAsync(proj.Owner.Name, proj.Name, simuId);
                //_simulation = new Simulation(proj, simuId);
            }
            // suspended by user
            if (cancelToken.IsCancellationRequested)
            {
                StopSimulaiton();
                return;
            }
            var totalSeconds = Math.Round((DateTime.UtcNow - startTime).TotalSeconds);
            var finishMessage = status.Status == "Succeeded" ? $"✔ Succeeded" : $"❌ {status.Status}";
            progressAction?.Invoke($"Task: {status.Status}");

            // Only get simulation logs when run toggle is set to true by user
            if (cancelToken.IsCancellationRequested) return;
            var outputs = api.GetSimulationLogs(proj.Owner.Name, proj.Name, simuId.ToString());
            var logUrl= outputs.ToString();
            this.Logs = await GetSimulationOutputLogAsync(progressAction, cancelToken);

            progressAction?.Invoke($"{finishMessage}: [{totalSeconds} s]");
        }

        public void StopSimulaiton()
        {
            var proj = this.Project;
            var simuId = this.SimulationID;
            var api = new SimulationsApi();
            api.StopSimulationAsync(proj.Owner.Name, proj.Name, simuId);
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
            var simuId = this.SimulationID;
            var api = new SimulationsApi();
            var status = api.GetSimulation(proj.Owner.Name, proj.Name, simuId);
            if(status.Status == "Running") throw new ArgumentException("Simulation is still running, please wait until it's done!");
            var taskDic = status.Tasks.OrderBy(_ => _.Value.StartedAt).ToDictionary(_ => _.Key, _ => $"[{_.Key}]\n{_.Value.StartedAt.ToLocalTime()} : {_.Value.Name}");
            var taskIDs = taskDic.Keys;

            //Download file
            if (cancelToken.IsCancellationRequested) return string.Empty;
            progressAction?.Invoke($"Downloading logs");
            
            var url = api.GetSimulationLogs(proj.Owner.Name, proj.Name, simuId).ToString();
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("Failed to call GetSimulationLogs");
            var dir = Path.Combine(Helper.GenTempFolder(), simuId);
            var downloadfile = await DownloadFile(url, dir);


            //unzip file 
            if (cancelToken.IsCancellationRequested) return string.Empty;
            progressAction?.Invoke($"Reading logs");
            Helper.Unzip(downloadfile, dir);
           


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

        private static async Task<string> DownloadFile(string url, string dir)
        {
            var request = new RestRequest(Method.GET);
            var client = new RestClient(url.ToString());
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Unable to download file");

            // prep file path
            var fileName = Path.GetFileName(url).Split(new[] { '?' })[0];
            var tempDir = string.IsNullOrEmpty(dir) ? Path.Combine(Path.GetTempPath(), "Pollination", Path.GetRandomFileName()) : dir;
            Directory.CreateDirectory(tempDir);
            var file = Path.Combine(tempDir, fileName);

            var b = response.RawBytes;
            File.WriteAllBytes(file, b);

            if (!File.Exists(file)) throw new ArgumentException($"Failed to download {fileName}");
            return file;
        }


    }
}
