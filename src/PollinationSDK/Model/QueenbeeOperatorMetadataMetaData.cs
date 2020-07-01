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
    /// Operator metadata information
    /// </summary>
    [DataContract]
    public partial class QueenbeeOperatorMetadataMetaData : HoneybeeObject, IEquatable<QueenbeeOperatorMetadataMetaData>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="QueenbeeOperatorMetadataMetaData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QueenbeeOperatorMetadataMetaData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QueenbeeOperatorMetadataMetaData" /> class.
        /// </summary>
        /// <param name="name">Operator name. This name should be unique among all the operators in your workflow. (required).</param>
        /// <param name="tag">The tag of the operator (required).</param>
        /// <param name="appVersion">The version of the app binary backing the operator (CLI tool or container).</param>
        /// <param name="keywords">A list of keywords to search the operator by.</param>
        /// <param name="maintainers">A list of maintainers for the operator.</param>
        /// <param name="home">The URL of this operator home page.</param>
        /// <param name="sources">A list of URLs to source code for this operator.</param>
        /// <param name="icon">A URL to an SVG or PNG image to be used as an icon.</param>
        /// <param name="deprecated">Whether this operator is deprecated.</param>
        /// <param name="description">A description of what this operator does.</param>
        public QueenbeeOperatorMetadataMetaData
        (
            , string name, string tag, , // Required parameters
            , string appVersion= default, List<string> keywords= default, List<QueenbeeOperatorMetadataMaintainer> maintainers= default, string home= default, List<string> sources= default, string icon= default, bool deprecated= default, string description= default// Optional parameters
        )// BaseClass
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for QueenbeeOperatorMetadataMetaData and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            
            // to ensure "tag" is required (not null)
            if (tag == null)
            {
                throw new InvalidDataException("tag is a required property for QueenbeeOperatorMetadataMetaData and cannot be null");
            }
            else
            {
                this.Tag = tag;
            }
            
            this.AppVersion = appVersion;
            this.Keywords = keywords;
            this.Maintainers = maintainers;
            this.Home = home;
            this.Sources = sources;
            this.Icon = icon;
            this.Deprecated = deprecated;
            this.Description = description;

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// Operator name. This name should be unique among all the operators in your workflow.
        /// </summary>
        /// <value>Operator name. This name should be unique among all the operators in your workflow.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        [JsonProperty("name")]
        public string Name { get; set; } 
        /// <summary>
        /// The tag of the operator
        /// </summary>
        /// <value>The tag of the operator</value>
        [DataMember(Name="tag", EmitDefaultValue=false)]
        [JsonProperty("tag")]
        public string Tag { get; set; } 
        /// <summary>
        /// The version of the app binary backing the operator (CLI tool or container)
        /// </summary>
        /// <value>The version of the app binary backing the operator (CLI tool or container)</value>
        [DataMember(Name="app_version", EmitDefaultValue=false)]
        [JsonProperty("app_version")]
        public string AppVersion { get; set; } 
        /// <summary>
        /// A list of keywords to search the operator by
        /// </summary>
        /// <value>A list of keywords to search the operator by</value>
        [DataMember(Name="keywords", EmitDefaultValue=false)]
        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; } 
        /// <summary>
        /// A list of maintainers for the operator
        /// </summary>
        /// <value>A list of maintainers for the operator</value>
        [DataMember(Name="maintainers", EmitDefaultValue=false)]
        [JsonProperty("maintainers")]
        public List<QueenbeeOperatorMetadataMaintainer> Maintainers { get; set; } 
        /// <summary>
        /// The URL of this operator home page
        /// </summary>
        /// <value>The URL of this operator home page</value>
        [DataMember(Name="home", EmitDefaultValue=false)]
        [JsonProperty("home")]
        public string Home { get; set; } 
        /// <summary>
        /// A list of URLs to source code for this operator
        /// </summary>
        /// <value>A list of URLs to source code for this operator</value>
        [DataMember(Name="sources", EmitDefaultValue=false)]
        [JsonProperty("sources")]
        public List<string> Sources { get; set; } 
        /// <summary>
        /// A URL to an SVG or PNG image to be used as an icon
        /// </summary>
        /// <value>A URL to an SVG or PNG image to be used as an icon</value>
        [DataMember(Name="icon", EmitDefaultValue=false)]
        [JsonProperty("icon")]
        public string Icon { get; set; } 
        /// <summary>
        /// Whether this operator is deprecated
        /// </summary>
        /// <value>Whether this operator is deprecated</value>
        [DataMember(Name="deprecated", EmitDefaultValue=false)]
        [JsonProperty("deprecated")]
        public bool Deprecated { get; set; } 
        /// <summary>
        /// A description of what this operator does
        /// </summary>
        /// <value>A description of what this operator does</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        [JsonProperty("description")]
        public string Description { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"QueenbeeOperatorMetadataMetaData {iDd.Identifier}";
       
            return "QueenbeeOperatorMetadataMetaData";
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
            sb.Append("QueenbeeOperatorMetadataMetaData:\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  AppVersion: ").Append(AppVersion).Append("\n");
            sb.Append("  Keywords: ").Append(Keywords).Append("\n");
            sb.Append("  Maintainers: ").Append(Maintainers).Append("\n");
            sb.Append("  Home: ").Append(Home).Append("\n");
            sb.Append("  Sources: ").Append(Sources).Append("\n");
            sb.Append("  Icon: ").Append(Icon).Append("\n");
            sb.Append("  Deprecated: ").Append(Deprecated).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>QueenbeeOperatorMetadataMetaData object</returns>
        public static QueenbeeOperatorMetadataMetaData FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<QueenbeeOperatorMetadataMetaData>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>QueenbeeOperatorMetadataMetaData object</returns>
        public QueenbeeOperatorMetadataMetaData DuplicateQueenbeeOperatorMetadataMetaData()
        {
            return Duplicate() as QueenbeeOperatorMetadataMetaData;
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
            return this.Equals(input as QueenbeeOperatorMetadataMetaData);
        }

        /// <summary>
        /// Returns true if QueenbeeOperatorMetadataMetaData instances are equal
        /// </summary>
        /// <param name="input">Instance of QueenbeeOperatorMetadataMetaData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QueenbeeOperatorMetadataMetaData input)
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
                    this.Tag == input.Tag ||
                    (this.Tag != null &&
                    this.Tag.Equals(input.Tag))
                ) && 
                (
                    this.AppVersion == input.AppVersion ||
                    (this.AppVersion != null &&
                    this.AppVersion.Equals(input.AppVersion))
                ) && 
                (
                    this.Keywords == input.Keywords ||
                    this.Keywords != null &&
                    input.Keywords != null &&
                    this.Keywords.SequenceEqual(input.Keywords)
                ) && 
                (
                    this.Maintainers == input.Maintainers ||
                    this.Maintainers != null &&
                    input.Maintainers != null &&
                    this.Maintainers.SequenceEqual(input.Maintainers)
                ) && 
                (
                    this.Home == input.Home ||
                    (this.Home != null &&
                    this.Home.Equals(input.Home))
                ) && 
                (
                    this.Sources == input.Sources ||
                    this.Sources != null &&
                    input.Sources != null &&
                    this.Sources.SequenceEqual(input.Sources)
                ) && 
                (
                    this.Icon == input.Icon ||
                    (this.Icon != null &&
                    this.Icon.Equals(input.Icon))
                ) && 
                (
                    this.Deprecated == input.Deprecated ||
                    (this.Deprecated != null &&
                    this.Deprecated.Equals(input.Deprecated))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
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
                if (this.Tag != null)
                    hashCode = hashCode * 59 + this.Tag.GetHashCode();
                if (this.AppVersion != null)
                    hashCode = hashCode * 59 + this.AppVersion.GetHashCode();
                if (this.Keywords != null)
                    hashCode = hashCode * 59 + this.Keywords.GetHashCode();
                if (this.Maintainers != null)
                    hashCode = hashCode * 59 + this.Maintainers.GetHashCode();
                if (this.Home != null)
                    hashCode = hashCode * 59 + this.Home.GetHashCode();
                if (this.Sources != null)
                    hashCode = hashCode * 59 + this.Sources.GetHashCode();
                if (this.Icon != null)
                    hashCode = hashCode * 59 + this.Icon.GetHashCode();
                if (this.Deprecated != null)
                    hashCode = hashCode * 59 + this.Deprecated.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
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
