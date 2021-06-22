/* 
 * pollination-server
 *
 * Pollination Server OpenAPI Definition
 *
 * The version of the OpenAPI document: 0.13.2
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
    /// Package metadata information.
    /// </summary>
    [DataContract]
    public partial class MetaData :  IEquatable<MetaData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MetaData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaData" /> class.
        /// </summary>
        /// <param name="annotations">An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries..</param>
        /// <param name="appVersion">The version of the application code underlying the manifest.</param>
        /// <param name="deprecated">Whether this package is deprecated.</param>
        /// <param name="description">A description of what this package does.</param>
        /// <param name="home">The URL of this package&#39;s home page.</param>
        /// <param name="icon">A URL to an SVG or PNG image to be used as an icon.</param>
        /// <param name="keywords">A list of keywords to search the package by.</param>
        /// <param name="license">The license information..</param>
        /// <param name="maintainers">A list of maintainers for the package.</param>
        /// <param name="name">Package name. Make it descriptive and helpful ;) (required).</param>
        /// <param name="sources">A list of URLs to source code for this project.</param>
        /// <param name="tag">The tag of the package (required).</param>
        public MetaData
        (
           string name, string tag, // Required parameters
           Dictionary<string, string> annotations= default, string appVersion= default, bool deprecated= default, string description= default, string home= default, string icon= default, List<string> keywords= default, License license= default, List<Maintainer> maintainers= default, List<string> sources= default // Optional parameters
        )// BaseClass
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for MetaData and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            
            // to ensure "tag" is required (not null)
            if (tag == null)
            {
                throw new InvalidDataException("tag is a required property for MetaData and cannot be null");
            }
            else
            {
                this.Tag = tag;
            }
            
            this.Annotations = annotations;
            this.AppVersion = appVersion;
            this.Deprecated = deprecated;
            this.Description = description;
            this.Home = home;
            this.Icon = icon;
            this.Keywords = keywords;
            this.License = license;
            this.Maintainers = maintainers;
            this.Sources = sources;

            // Set non-required readonly properties with defaultValue
            this.Type = "MetaData";
        }
        
        /// <summary>
        /// An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries.
        /// </summary>
        /// <value>An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries.</value>
        [DataMember(Name="annotations", EmitDefaultValue=false)]
        [JsonProperty("annotations")]
        public Dictionary<string, string> Annotations { get; set; } 
        /// <summary>
        /// The version of the application code underlying the manifest
        /// </summary>
        /// <value>The version of the application code underlying the manifest</value>
        [DataMember(Name="app_version", EmitDefaultValue=false)]
        [JsonProperty("app_version")]
        public string AppVersion { get; set; } 
        /// <summary>
        /// Whether this package is deprecated
        /// </summary>
        /// <value>Whether this package is deprecated</value>
        [DataMember(Name="deprecated", EmitDefaultValue=false)]
        [JsonProperty("deprecated")]
        public bool Deprecated { get; set; } 
        /// <summary>
        /// A description of what this package does
        /// </summary>
        /// <value>A description of what this package does</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        [JsonProperty("description")]
        public string Description { get; set; } 
        /// <summary>
        /// The URL of this package&#39;s home page
        /// </summary>
        /// <value>The URL of this package&#39;s home page</value>
        [DataMember(Name="home", EmitDefaultValue=false)]
        [JsonProperty("home")]
        public string Home { get; set; } 
        /// <summary>
        /// A URL to an SVG or PNG image to be used as an icon
        /// </summary>
        /// <value>A URL to an SVG or PNG image to be used as an icon</value>
        [DataMember(Name="icon", EmitDefaultValue=false)]
        [JsonProperty("icon")]
        public string Icon { get; set; } 
        /// <summary>
        /// A list of keywords to search the package by
        /// </summary>
        /// <value>A list of keywords to search the package by</value>
        [DataMember(Name="keywords", EmitDefaultValue=false)]
        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; } 
        /// <summary>
        /// The license information.
        /// </summary>
        /// <value>The license information.</value>
        [DataMember(Name="license", EmitDefaultValue=false)]
        [JsonProperty("license")]
        public License License { get; set; } 
        /// <summary>
        /// A list of maintainers for the package
        /// </summary>
        /// <value>A list of maintainers for the package</value>
        [DataMember(Name="maintainers", EmitDefaultValue=false)]
        [JsonProperty("maintainers")]
        public List<Maintainer> Maintainers { get; set; } 
        /// <summary>
        /// Package name. Make it descriptive and helpful ;)
        /// </summary>
        /// <value>Package name. Make it descriptive and helpful ;)</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        [JsonProperty("name")]
        public string Name { get; set; } 
        /// <summary>
        /// A list of URLs to source code for this project
        /// </summary>
        /// <value>A list of URLs to source code for this project</value>
        [DataMember(Name="sources", EmitDefaultValue=false)]
        [JsonProperty("sources")]
        public List<string> Sources { get; set; } 
        /// <summary>
        /// The tag of the package
        /// </summary>
        /// <value>The tag of the package</value>
        [DataMember(Name="tag", EmitDefaultValue=false)]
        [JsonProperty("tag")]
        public string Tag { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MetaData {\n");
            sb.Append("  Annotations: ").Append(Annotations).Append("\n");
            sb.Append("  AppVersion: ").Append(AppVersion).Append("\n");
            sb.Append("  Deprecated: ").Append(Deprecated).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Home: ").Append(Home).Append("\n");
            sb.Append("  Icon: ").Append(Icon).Append("\n");
            sb.Append("  Keywords: ").Append(Keywords).Append("\n");
            sb.Append("  License: ").Append(License).Append("\n");
            sb.Append("  Maintainers: ").Append(Maintainers).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Sources: ").Append(Sources).Append("\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
        /// <returns>MetaData object</returns>
        public static MetaData FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<MetaData>(json, JsonSetting.ConvertSetting);
            return obj;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>MetaData object</returns>
        public MetaData DuplicateMetaData()
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
            return this.Equals(input as MetaData);
        }

        /// <summary>
        /// Returns true if MetaData instances are equal
        /// </summary>
        /// <param name="input">Instance of MetaData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MetaData input)
        {
            if (input == null)
                return false;
            return 
                (
                    this.Annotations == input.Annotations ||
                    this.Annotations != null &&
                    input.Annotations != null &&
                    this.Annotations.SequenceEqual(input.Annotations)
                ) && 
                (
                    this.AppVersion == input.AppVersion ||
                    (this.AppVersion != null &&
                    this.AppVersion.Equals(input.AppVersion))
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
                ) && 
                (
                    this.Home == input.Home ||
                    (this.Home != null &&
                    this.Home.Equals(input.Home))
                ) && 
                (
                    this.Icon == input.Icon ||
                    (this.Icon != null &&
                    this.Icon.Equals(input.Icon))
                ) && 
                (
                    this.Keywords == input.Keywords ||
                    this.Keywords != null &&
                    input.Keywords != null &&
                    this.Keywords.SequenceEqual(input.Keywords)
                ) && 
                (
                    this.License == input.License ||
                    (this.License != null &&
                    this.License.Equals(input.License))
                ) && 
                (
                    this.Maintainers == input.Maintainers ||
                    this.Maintainers != null &&
                    input.Maintainers != null &&
                    this.Maintainers.SequenceEqual(input.Maintainers)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Sources == input.Sources ||
                    this.Sources != null &&
                    input.Sources != null &&
                    this.Sources.SequenceEqual(input.Sources)
                ) && 
                (
                    this.Tag == input.Tag ||
                    (this.Tag != null &&
                    this.Tag.Equals(input.Tag))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
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
                if (this.Annotations != null)
                    hashCode = hashCode * 59 + this.Annotations.GetHashCode();
                if (this.AppVersion != null)
                    hashCode = hashCode * 59 + this.AppVersion.GetHashCode();
                if (this.Deprecated != null)
                    hashCode = hashCode * 59 + this.Deprecated.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Home != null)
                    hashCode = hashCode * 59 + this.Home.GetHashCode();
                if (this.Icon != null)
                    hashCode = hashCode * 59 + this.Icon.GetHashCode();
                if (this.Keywords != null)
                    hashCode = hashCode * 59 + this.Keywords.GetHashCode();
                if (this.License != null)
                    hashCode = hashCode * 59 + this.License.GetHashCode();
                if (this.Maintainers != null)
                    hashCode = hashCode * 59 + this.Maintainers.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Sources != null)
                    hashCode = hashCode * 59 + this.Sources.GetHashCode();
                if (this.Tag != null)
                    hashCode = hashCode * 59 + this.Tag.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
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
            // Type (string) pattern
            Regex regexType = new Regex(@"^MetaData$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
