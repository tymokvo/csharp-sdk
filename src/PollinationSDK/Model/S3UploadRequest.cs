/* 
 * Pollination Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.5.28
 * 
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


namespace PollinationSDK
{
    /// <summary>
    /// S3UploadRequest
    /// </summary>
    [DataContract]
    public partial class S3UploadRequest : HoneybeeObject, IEquatable<S3UploadRequest>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="S3UploadRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected S3UploadRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="S3UploadRequest" /> class.
        /// </summary>
        /// <param name="url">url (required).</param>
        /// <param name="fields">fields (required).</param>
        public S3UploadRequest
        (
            , string url, Dictionary<string, string> fields// Required parameters
            , // Optional parameters
        )// BaseClass
        {
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new InvalidDataException("url is a required property for S3UploadRequest and cannot be null");
            }
            else
            {
                this.Url = url;
            }
            
            // to ensure "fields" is required (not null)
            if (fields == null)
            {
                throw new InvalidDataException("fields is a required property for S3UploadRequest and cannot be null");
            }
            else
            {
                this.Fields = fields;
            }
            

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue=false)]
        [JsonProperty("url")]
        public string Url { get; set; } 
        /// <summary>
        /// Gets or Sets Fields
        /// </summary>
        [DataMember(Name="fields", EmitDefaultValue=false)]
        [JsonProperty("fields")]
        public Dictionary<string, string> Fields { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"S3UploadRequest {iDd.Identifier}";
       
            return "S3UploadRequest";
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString(bool detailed)
        {
            if (!detailed)
                return this.ToString();
            
            var sb = new StringBuilder();
            sb.Append("S3UploadRequest:\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Fields: ").Append(Fields).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>S3UploadRequest object</returns>
        public static S3UploadRequest FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<S3UploadRequest>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>S3UploadRequest object</returns>
        public S3UploadRequest DuplicateS3UploadRequest()
        {
            return Duplicate() as S3UploadRequest;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>HoneybeeObject</returns>
        public override HoneybeeObject Duplicate()
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
            return this.Equals(input as S3UploadRequest);
        }

        /// <summary>
        /// Returns true if S3UploadRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of S3UploadRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(S3UploadRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.Fields == input.Fields ||
                    this.Fields != null &&
                    input.Fields != null &&
                    this.Fields.SequenceEqual(input.Fields)
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
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.Fields != null)
                    hashCode = hashCode * 59 + this.Fields.GetHashCode();
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
