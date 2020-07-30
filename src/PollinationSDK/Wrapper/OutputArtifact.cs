using PollinationSDK.Model;

namespace PollinationSDK.Wrapper
{
    /// <summary>
    /// Wrapper for DAGOutputArtifact, which overrides the ToString()
    /// </summary>
    public class OutputArtifact: DAGOutputArtifact
    {
        public OutputArtifact(DAGOutputArtifact outputArtifact)
        {
            this.From = outputArtifact.From;
            this.Name = outputArtifact.Name;
        }

        public OutputArtifact(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"artifact: {this.Name}"; 
        }
    }
}
