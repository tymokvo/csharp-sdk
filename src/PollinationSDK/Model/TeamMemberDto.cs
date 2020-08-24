/* 
 * Pollination Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.7.6
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
    /// TeamMemberDto
    /// </summary>
    [DataContract]
    public partial class TeamMemberDto :  IEquatable<TeamMemberDto>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name="role", EmitDefaultValue=false)]
        public TeamRoleEnum Role { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMemberDto" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TeamMemberDto() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMemberDto" /> class.
        /// </summary>
        /// <param name="userId">The team member (required).</param>
        /// <param name="role">role (required).</param>
        public TeamMemberDto
        (
           string userId, TeamRoleEnum role// Required parameters
           // Optional parameters
        )// BaseClass
        {
            // to ensure "userId" is required (not null)
            if (userId == null)
            {
                throw new InvalidDataException("userId is a required property for TeamMemberDto and cannot be null");
            }
            else
            {
                this.UserId = userId;
            }
            
            // to ensure "role" is required (not null)
            if (role == null)
            {
                throw new InvalidDataException("role is a required property for TeamMemberDto and cannot be null");
            }
            else
            {
                this.Role = role;
            }
            

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// The team member
        /// </summary>
        /// <value>The team member</value>
        [DataMember(Name="user_id", EmitDefaultValue=false)]
        [JsonProperty("user_id")]
        public string UserId { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TeamMemberDto {\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
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
        /// <returns>TeamMemberDto object</returns>
        public static TeamMemberDto FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<TeamMemberDto>(json, JsonSetting.ConvertSetting);
            return obj;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>TeamMemberDto object</returns>
        public TeamMemberDto DuplicateTeamMemberDto()
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
            return this.Equals(input as TeamMemberDto);
        }

        /// <summary>
        /// Returns true if TeamMemberDto instances are equal
        /// </summary>
        /// <param name="input">Instance of TeamMemberDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TeamMemberDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
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
                if (this.UserId != null)
                    hashCode = hashCode * 59 + this.UserId.GetHashCode();
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
