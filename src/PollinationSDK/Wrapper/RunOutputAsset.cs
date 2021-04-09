using Newtonsoft.Json;
using System.Collections.Generic;

namespace PollinationSDK.Wrapper
{
    public class RunOutputAsset: RunAssetBase
    {
        [JsonProperty]
        public List<IOAliasHandler> Handlers { get; private set; }

        [JsonProperty]
        public string AliasName { get; private set; }

        [JsonConstructorAttribute]
        protected RunOutputAsset()
        {
        }

        public RunOutputAsset(Interface.Io.Outputs.IDag dagOutput, string platform, string cloudRunSource = default)
        {
            if (dagOutput == null)
                return;

            this.Name = dagOutput.Name;

            //var platform = "grasshopper";
            var dagOutputAlias = dagOutput.GetAlias(platform);
            // override the name and description
            this.AliasName = dagOutputAlias?.Name ?? this.Name;
            this.Handlers = dagOutputAlias?.Handler;

            // keep cloud source: CLOUD:mingbo/demo/1D725BD1-44E1-4C3C-85D6-4D98F558DE7C
            this.CloudRunSource = cloudRunSource;
            this.CloudPath = this.Name;
        }

        public override object CheckOutputWithHandler(object inputData, HandlerChecker handlerChecker)
        {
            handlerChecker = handlerChecker ?? DefaultHandlerChecker.Instance;
            return handlerChecker.CheckWithHandlers(inputData, this.Handlers);
        }


        public override RunAssetBase Duplicate()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RunOutputAsset>(json);
        }
    }

}
