

using Newtonsoft.Json;

namespace PollinationSDK.Wrapper
{
    public class RunInputAsset : RunAssetBase
    {
        [JsonConstructorAttribute]
        protected RunInputAsset()
        {
        }
        public RunInputAsset(Interface.Io.Inputs.IStep dagInput, string runSource = default)
        {
            if (dagInput == null)
                return;

            // get name
            this.Name = dagInput.Name;
            this.Description = dagInput.Description;

            // check path type
            this.RelativePath = dagInput.GetInputPath();
            

            // value type
            this.Value = dagInput.GetInputValue();

            // cloud source: CLOUD:mingbo/demo/1D725BD1-44E1-4C3C-85D6-4D98F558DE7C
            // local source: LOCAL:C\Users\mingo\simulaiton\1D725BD1
            this.RunSource = runSource;
        }

        public override RunAssetBase Duplicate()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RunInputAsset>(json);
        }

    }

}
