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

        public override string ToString()
        {
            return $"artifact: {this.Name}"; 
        }
    }
}
