using PollinationSDK.Model;

namespace PollinationSDK.Wrapper
{
    /// <summary>
    /// Wrapper for DAGOutputParameter, which overrides the ToString()
    /// </summary>
    public class OutputParameter: DAGOutputParameter
    {
        public OutputParameter(DAGOutputParameter outputParameter)
        {
            this.From = outputParameter.From;
            this.Name = outputParameter.Name;
        }

        public override string ToString()
        {
            return $"parameter: {this.Name}"; 
        }
    }
}
