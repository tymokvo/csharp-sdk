using Newtonsoft.Json;
using PollinationSDK.Api;
using PollinationSDK.Model;
using System;
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

        public async Task CheckStatusAsync(Action<string> progressAction = default, System.Threading.CancellationToken cancelToken = default)
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
            progressAction?.Invoke($"{finishMessage}: [{totalSeconds} s]");

            // Only get simulation logs when run toggle is set to true by user
            if (!cancelToken.IsCancellationRequested)
            {
                var outputs = api.GetSimulationLogs(proj.Owner.Name, proj.Name, simuId.ToString());
                this.Logs = outputs.ToString();
            }

        }

        public void StopSimulaiton()
        {
            var proj = this.Project;
            var simuId = this.SimulationID;
            var api = new SimulationsApi();
            api.SuspendSimulationAsync(proj.Owner.Name, proj.Name, simuId);
        }
    }
}
