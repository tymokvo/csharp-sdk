using Newtonsoft.Json;
using PollinationSDK.Model;

namespace PollinationSDK.Wrapper
{
    /// <summary>
    /// Simulation wrapper contains the project (ProjectDto), and simulationID for tracking the simulation.
    /// </summary>
    public class Simulation
    {
        public ProjectDto project { get; set; }
        public string simulationID { get; set; }
        public Simulation(ProjectDto proj, string simuId)
        {
            this.project = proj;
            this.simulationID = simuId;
        }

        public override string ToString()
        {
            return $"{this.project.Owner.Name}/{this.project.Name}/{this.simulationID}"; 
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
    }
}
