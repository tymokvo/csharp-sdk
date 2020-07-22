/* 
 * Pollination Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.6.0
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


namespace PollinationSDK.Model
{
    /// <summary>
    /// ProjectPolicySubjectDto
    /// </summary>
    [DataContract]
    public partial class ProjectPolicySubjectDto :  IEquatable<ProjectPolicySubjectDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPolicySubjectDto" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProjectPolicySubjectDto() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPolicySubjectDto" /> class.
        /// </summary>
        /// <param name="type">The type of policy subject. Can be &#x60;team&#x60;, &#x60;org&#x60; or &#x60;user&#x60; (required).</param>
        /// <param name="id">The ID of the policy subject (required).</param>
        /// <param name="role">The role within the policy subject that the access policy refers (required).</param>
        public ProjectPolicySubjectDto
        (
           string type, string id, string role// Required parameters
           // Optional parameters
        )// BaseClass
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for ProjectPolicySubjectDto and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new InvalidDataException("id is a required property for ProjectPolicySubjectDto and cannot be null");
            }
            else
            {
                this.Id = id;
            }
            
            // to ensure "role" is required (not null)
            if (role == null)
            {
                throw new InvalidDataException("role is a required property for ProjectPolicySubjectDto and cannot be null");
            }
            else
            {
                this.Role = role;
            }
            

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// The type of policy subject. Can be &#x60;team&#x60;, &#x60;org&#x60; or &#x60;user&#x60;
        /// </summary>
        /// <value>The type of policy subject. Can be &#x60;team&#x60;, &#x60;org&#x60; or &#x60;user&#x60;</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        [JsonProperty("type")]
        public string Type { get; set; } 
        /// <summary>
        /// The ID of the policy subject
        /// </summary>
        /// <value>The ID of the policy subject</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        [JsonProperty("id")]
        public string Id { get; set; } 
        /// <summary>
        /// The role within the policy subject that the access policy refers
        /// </summary>
        /// <value>The role within the policy subject that the access policy refers</value>
        [DataMember(Name="role", EmitDefaultValue=false)]
        [JsonProperty("role")]
        public string Role { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProjectPolicySubjectDto {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
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
        /// <returns>ProjectPolicySubjectDto object</returns>
        public static ProjectPolicySubjectDto FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ProjectPolicySubjectDto>(json, JsonSetting.ConvertSetting);
            return obj;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ProjectPolicySubjectDto object</returns>
        public ProjectPolicySubjectDto DuplicateProjectPolicySubjectDto()
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
            return this.Equals(input as ProjectPolicySubjectDto);
        }

        /// <summary>
        /// Returns true if ProjectPolicySubjectDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ProjectPolicySubjectDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProjectPolicySubjectDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Role == input.Role ||
                    (this.Role != null &&
                    this.Role.Equals(input.Role))
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Role != null)
                    hashCode = hashCode * 59 + this.Role.GetHashCode();
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
