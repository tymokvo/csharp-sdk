/* 
 * Pollination Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.5.32
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
    /// CreateOrgDto
    /// </summary>
    [DataContract]
    public partial class CreateOrgDto :  IEquatable<CreateOrgDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrgDto" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateOrgDto() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrgDto" /> class.
        /// </summary>
        /// <param name="name">The pretty name of the org (required).</param>
        /// <param name="picture">The avatar picture for the Org (required).</param>
        /// <param name="contactEmail">The contact email for the organisation (required).</param>
        /// <param name="description">A description of the org (default to &quot;&quot;).</param>
        /// <param name="accountName">The unique name of the org in small case without spaces (required).</param>
        public CreateOrgDto
        (
           string name, string picture, string contactEmail, string accountName, // Required parameters
           string description = "" // Optional parameters
        )// BaseClass
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for CreateOrgDto and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            
            // to ensure "picture" is required (not null)
            if (picture == null)
            {
                throw new InvalidDataException("picture is a required property for CreateOrgDto and cannot be null");
            }
            else
            {
                this.Picture = picture;
            }
            
            // to ensure "contactEmail" is required (not null)
            if (contactEmail == null)
            {
                throw new InvalidDataException("contactEmail is a required property for CreateOrgDto and cannot be null");
            }
            else
            {
                this.ContactEmail = contactEmail;
            }
            
            // to ensure "accountName" is required (not null)
            if (accountName == null)
            {
                throw new InvalidDataException("accountName is a required property for CreateOrgDto and cannot be null");
            }
            else
            {
                this.AccountName = accountName;
            }
            
            // use default value if no "description" provided
            if (description == null)
            {
                this.Description ="";
            }
            else
            {
                this.Description = description;
            }

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// The pretty name of the org
        /// </summary>
        /// <value>The pretty name of the org</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        [JsonProperty("name")]
        public string Name { get; set; } 
        /// <summary>
        /// The avatar picture for the Org
        /// </summary>
        /// <value>The avatar picture for the Org</value>
        [DataMember(Name="picture", EmitDefaultValue=false)]
        [JsonProperty("picture")]
        public string Picture { get; set; } 
        /// <summary>
        /// The contact email for the organisation
        /// </summary>
        /// <value>The contact email for the organisation</value>
        [DataMember(Name="contact_email", EmitDefaultValue=false)]
        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; } 
        /// <summary>
        /// A description of the org
        /// </summary>
        /// <value>A description of the org</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        [JsonProperty("description")]
        public string Description { get; set; }  = "";
        /// <summary>
        /// The unique name of the org in small case without spaces
        /// </summary>
        /// <value>The unique name of the org in small case without spaces</value>
        [DataMember(Name="account_name", EmitDefaultValue=false)]
        [JsonProperty("account_name")]
        public string AccountName { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateOrgDto {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Picture: ").Append(Picture).Append("\n");
            sb.Append("  ContactEmail: ").Append(ContactEmail).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  AccountName: ").Append(AccountName).Append("\n");
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
        /// <returns>CreateOrgDto object</returns>
        public static CreateOrgDto FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<CreateOrgDto>(json, JsonSetting.ConvertSetting);
            return obj;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>CreateOrgDto object</returns>
        public CreateOrgDto DuplicateCreateOrgDto()
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
            return this.Equals(input as CreateOrgDto);
        }

        /// <summary>
        /// Returns true if CreateOrgDto instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateOrgDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateOrgDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Picture == input.Picture ||
                    (this.Picture != null &&
                    this.Picture.Equals(input.Picture))
                ) && 
                (
                    this.ContactEmail == input.ContactEmail ||
                    (this.ContactEmail != null &&
                    this.ContactEmail.Equals(input.ContactEmail))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.AccountName == input.AccountName ||
                    (this.AccountName != null &&
                    this.AccountName.Equals(input.AccountName))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Picture != null)
                    hashCode = hashCode * 59 + this.Picture.GetHashCode();
                if (this.ContactEmail != null)
                    hashCode = hashCode * 59 + this.ContactEmail.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.AccountName != null)
                    hashCode = hashCode * 59 + this.AccountName.GetHashCode();
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
