using Newtonsoft.Json;
namespace PollinationSDK
{
    public abstract class PollinationObject 
    {
        /// <summary>
        /// This is the base class for all queenbee schema objects.
        /// </summary>
        protected internal PollinationObject()
        {
        }


        public abstract string ToString(bool detailed);

        public abstract OpenAPIGenBaseModel Duplicate();
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, QueenbeeSDK.JsonSetting.AnyOfConvertSetting);
        }
    }
}

