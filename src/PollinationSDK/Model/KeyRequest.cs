/* 
 * pollination-server
 *
 * Pollination Server OpenAPI Definition
 *
 * The version of the OpenAPI document: 0.13.3
 * Contact: info@pollination.cloud
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = PollinationSDK.Client.OpenAPIDateConverter;

namespace PollinationSDK.Model
{
    /// <summary>
    /// KeyRequest
    /// </summary>
    [DataContract]
    public partial class KeyRequest :  IEquatable<KeyRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected KeyRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyRequest" /> class.
        /// </summary>
        /// <param name="key">key (required).</param>
        public KeyRequest
        (
           string key// Required parameters
           // Optional parameters
        )// BaseClass
        {
            // to ensure "key" is required (not null)
            if (key == null)
            {
                throw new InvalidDataException("key is a required property for KeyRequest and cannot be null");
            }
            else
            {
                this.Key = key;
            }
            

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// Gets or Sets Key
        /// </summary>
        [DataMember(Name="key", EmitDefaultValue=false)]
        [JsonProperty("key")]
        public string Key { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class KeyRequest {\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSetting.ConvertSetting);
        }

        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>KeyRequest object</returns>
        public static KeyRequest FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<KeyRequest>(json, JsonSetting.ConvertSetting);
            return obj;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>KeyRequest object</returns>
        public KeyRequest DuplicateKeyRequest()
        {
            return FromJson(this.ToJson());
        }
     
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as KeyRequest);
        }

        /// <summary>
        /// Returns true if KeyRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of KeyRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(KeyRequest input)
        {
            if (input == null)
                return false;
            return 
                (
                    this.Key == input.Key ||
                    (this.Key != null &&
                    this.Key.Equals(input.Key))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Key != null)
                    hashCode = hashCode * 59 + this.Key.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
