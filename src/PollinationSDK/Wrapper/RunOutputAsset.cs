using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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
            this.Description = dagOutputAlias?.Description ?? dagOutput.Description;

            // keep cloud source: CLOUD:mingbo/demo/1D725BD1-44E1-4C3C-85D6-4D98F558DE7C
            this.CloudRunSource = cloudRunSource;
            this.CloudPath = this.Name;
        }

        public override object CheckOutputWithHandler(object inputData, HandlerChecker handlerChecker)
        {
            handlerChecker = handlerChecker ?? DefaultHandlerChecker.Instance;
            return handlerChecker.CheckWithHandlers(inputData, this.Handlers);
        }


        public object PreloadLinkedOutputWithHandler(object inputData, HandlerChecker handlerChecker)
        {
            handlerChecker = handlerChecker ?? DefaultHandlerChecker.Instance;
            if (this.Handlers.Count != 2)
                throw new System.ArgumentException("Linked Output requires 2 handlers");
            // the first handler is for preloading
            var handlerForPreload = this.Handlers?.Skip(1)?.ToList();
            return handlerChecker.CheckWithHandlers(inputData, handlerForPreload);
        }

        public override RunAssetBase Duplicate()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RunOutputAsset>(json);
        }
    }

}
