using System.Linq;
using System.Collections.Generic;

namespace PollinationSDK
{
    public partial class RecipeInterface
    {
        public IEnumerable<Interface.Io.Inputs.IDag> InputList => this.Inputs.OfType<Interface.Io.Inputs.IDag>();
        public IEnumerable<Interface.Io.Outputs.IDag> OutputList => this.Outputs.OfType<Interface.Io.Outputs.IDag>();
    }
}