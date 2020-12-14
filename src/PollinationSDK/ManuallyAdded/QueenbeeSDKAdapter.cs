
using Newtonsoft.Json;

namespace PollinationSDK.Client
{
    /// <summary>
    /// API client is mainly responsible for making the HTTP call to the API backend.
    /// </summary>
    public class AnyOfJsonConverter : QueenbeeSDK.AnyOfJsonConverter
    { 
    }
}

namespace PollinationSDK
{
    public static class JsonSetting
    {
        public static JsonSerializerSettings AnyOfConvertSetting => QueenbeeSDK.JsonSetting.AnyOfConvertSetting;
    }
}