
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace PollinationSDK
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum SortEnum
    {
        [EnumMember(Value = "ascending")]
        Ascending = 1,

        [EnumMember(Value = "descending")]
        Descending = 2,


    }

}
