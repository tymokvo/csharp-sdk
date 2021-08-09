/* 
 * pollination-server
 *
 * Pollination Server OpenAPI Definition
 *
 * The version of the OpenAPI document: 0.15.0
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
    /// APIToken
    /// </summary>
    [DataContract]
    public partial class APIToken :  IEquatable<APIToken>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIToken" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected APIToken() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="APIToken" /> class.
        /// </summary>
        /// <param name="claims">Key value pairs of auth claims the API token is entitled to.</param>
        /// <param name="name">The user friendly name of the API token (required).</param>
        /// <param name="tokenId">The unique ID of this API token (required).</param>
        public APIToken
        (
           string name, string tokenId, // Required parameters
           Dictionary<string, string> claims= default // Optional parameters
        )// BaseClass
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for APIToken and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new InvalidDataException("tokenId is a required property for APIToken and cannot be null");
            }
            else
            {
                this.TokenId = tokenId;
            }
            
            this.Claims = claims;

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// Key value pairs of auth claims the API token is entitled to
        /// </summary>
        /// <value>Key value pairs of auth claims the API token is entitled to</value>
        [DataMember(Name="claims", EmitDefaultValue=false)]
        [JsonProperty("claims")]
        public Dictionary<string, string> Claims { get; set; } 
        /// <summary>
        /// The user friendly name of the API token
        /// </summary>
        /// <value>The user friendly name of the API token</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        [JsonProperty("name")]
        public string Name { get; set; } 
        /// <summary>
        /// The unique ID of this API token
        /// </summary>
        /// <value>The unique ID of this API token</value>
        [DataMember(Name="token_id", EmitDefaultValue=false)]
        [JsonProperty("token_id")]
        public string TokenId { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class APIToken {\n");
            sb.Append("  Claims: ").Append(Claims).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
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
        /// <returns>APIToken object</returns>
        public static APIToken FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<APIToken>(json, JsonSetting.ConvertSetting);
            return obj;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>APIToken object</returns>
        public APIToken DuplicateAPIToken()
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
            return this.Equals(input as APIToken);
        }

        /// <summary>
        /// Returns true if APIToken instances are equal
        /// </summary>
        /// <param name="input">Instance of APIToken to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(APIToken input)
        {
            if (input == null)
                return false;
            return 
                (
                    this.Claims == input.Claims ||
                    this.Claims != null &&
                    input.Claims != null &&
                    this.Claims.SequenceEqual(input.Claims)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.TokenId == input.TokenId ||
                    (this.TokenId != null &&
                    this.TokenId.Equals(input.TokenId))
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
                if (this.Claims != null)
                    hashCode = hashCode * 59 + this.Claims.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.TokenId != null)
                    hashCode = hashCode * 59 + this.TokenId.GetHashCode();
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
