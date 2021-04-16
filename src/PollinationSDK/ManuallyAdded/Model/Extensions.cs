
using System.Collections.Generic;
using System.Linq;

namespace PollinationSDK
{
    public static class ModelExtensions
    {
        public static List<Interface.Io.Outputs.IDag> GetOutputs(this RecipeInterface recipe)
        {
            var outputs = recipe.Outputs
              .OfType<Interface.Io.Outputs.IDag>().ToList();

            return outputs;
        }
        public static List<Interface.Io.Inputs.IDag> GetInputs(this RecipeInterface recipe)
        {
            var outputs = recipe.Inputs
              .OfType<Interface.Io.Inputs.IDag>().ToList();

            return outputs;
        }

    }
}
