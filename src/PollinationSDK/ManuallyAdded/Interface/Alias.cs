using System.Collections.Generic;

namespace PollinationSDK.Interface.Io.Inputs
{

    public partial interface IAlias: IoBase
    {
        List<string> Platform { get; set; }
        List<IOAliasHandler> Handler { get; set; }
        
    }
    

}


namespace PollinationSDK.Interface.Io.Outputs
{

    public partial interface IAlias : IoBase
    {
        List<string> Platform { get; set; }
        List<IOAliasHandler> Handler { get; set; }

    }


}
