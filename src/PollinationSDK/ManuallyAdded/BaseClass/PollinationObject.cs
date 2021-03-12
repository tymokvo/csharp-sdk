using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PollinationSDK
{
    public abstract class PollinationObject 
    {
         /// <summary>
        /// Gets or Sets Type
        /// The default value is set to "InvalidSchemaObject", which should be overridden in subclass' constructor.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public virtual string Type { get; protected internal set; } = "InvalidSchemaObject";


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
            return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSetting.AnyOfConvertSetting);
        }
    }
}

