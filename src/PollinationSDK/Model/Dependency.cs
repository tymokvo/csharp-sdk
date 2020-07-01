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
    /// Configuration to fetch a Recipe or Operator that another Recipe depends on.
    /// </summary>
    [DataContract]
    public partial class Dependency : HoneybeeObject, IEquatable<Dependency>, IValidatableObject
    {

        /// <summary>
        /// The type of dependency
        /// </summary>
        /// <value>The type of dependency</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Recipe for value: recipe
            /// </summary>
            [EnumMember(Value = "recipe")]
            Recipe = 1,

            /// <summary>
            /// Enum Operator for value: operator
            /// </summary>
            [EnumMember(Value = "operator")]
            Operator = 2

        }

        /// <summary>
        /// The type of dependency
        /// </summary>
        /// <value>The type of dependency</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum Type { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="Dependency" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Dependency() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Dependency" /> class.
        /// </summary>
        /// <param name="type">The type of dependency (required).</param>
        /// <param name="name">Workflow name. This name should be unique among all the resources in your resource. Use an alias if this is not the case. (required).</param>
        /// <param name="hash">The digest hash of the dependency when retrieved from its source. This is locked when the resource dependencies are downloaded..</param>
        /// <param name="alias">An optional alias to refer to this dependency. Useful if the name is already used somewhere else..</param>
        /// <param name="tag">Tag of the resource. (required).</param>
        /// <param name="source">URL to a repository where this resource can be found. (required).</param>
        public Dependency
        (
            , TypeEnum type, string name, string tag, string source, // Required parameters
            , string hash= default, string alias= default, // Optional parameters
        )// BaseClass
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for Dependency and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for Dependency and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            
            // to ensure "tag" is required (not null)
            if (tag == null)
            {
                throw new InvalidDataException("tag is a required property for Dependency and cannot be null");
            }
            else
            {
                this.Tag = tag;
            }
            
            // to ensure "source" is required (not null)
            if (source == null)
            {
                throw new InvalidDataException("source is a required property for Dependency and cannot be null");
            }
            else
            {
                this.Source = source;
            }
            
            this.Hash = hash;
            this.Alias = alias;

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// Workflow name. This name should be unique among all the resources in your resource. Use an alias if this is not the case.
        /// </summary>
        /// <value>Workflow name. This name should be unique among all the resources in your resource. Use an alias if this is not the case.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        [JsonProperty("name")]
        public string Name { get; set; } 
        /// <summary>
        /// The digest hash of the dependency when retrieved from its source. This is locked when the resource dependencies are downloaded.
        /// </summary>
        /// <value>The digest hash of the dependency when retrieved from its source. This is locked when the resource dependencies are downloaded.</value>
        [DataMember(Name="hash", EmitDefaultValue=false)]
        [JsonProperty("hash")]
        public string Hash { get; set; } 
        /// <summary>
        /// An optional alias to refer to this dependency. Useful if the name is already used somewhere else.
        /// </summary>
        /// <value>An optional alias to refer to this dependency. Useful if the name is already used somewhere else.</value>
        [DataMember(Name="alias", EmitDefaultValue=false)]
        [JsonProperty("alias")]
        public string Alias { get; set; } 
        /// <summary>
        /// Tag of the resource.
        /// </summary>
        /// <value>Tag of the resource.</value>
        [DataMember(Name="tag", EmitDefaultValue=false)]
        [JsonProperty("tag")]
        public string Tag { get; set; } 
        /// <summary>
        /// URL to a repository where this resource can be found.
        /// </summary>
        /// <value>URL to a repository where this resource can be found.</value>
        [DataMember(Name="source", EmitDefaultValue=false)]
        [JsonProperty("source")]
        public string Source { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"Dependency {iDd.Identifier}";
       
            return "Dependency";
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
            sb.Append("Dependency:\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Hash: ").Append(Hash).Append("\n");
            sb.Append("  Alias: ").Append(Alias).Append("\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Dependency object</returns>
        public static Dependency FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Dependency>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Dependency object</returns>
        public Dependency DuplicateDependency()
        {
            return Duplicate() as Dependency;
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
            return this.Equals(input as Dependency);
        }

        /// <summary>
        /// Returns true if Dependency instances are equal
        /// </summary>
        /// <param name="input">Instance of Dependency to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Dependency input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Hash == input.Hash ||
                    (this.Hash != null &&
                    this.Hash.Equals(input.Hash))
                ) && 
                (
                    this.Alias == input.Alias ||
                    (this.Alias != null &&
                    this.Alias.Equals(input.Alias))
                ) && 
                (
                    this.Tag == input.Tag ||
                    (this.Tag != null &&
                    this.Tag.Equals(input.Tag))
                ) && 
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Hash != null)
                    hashCode = hashCode * 59 + this.Hash.GetHashCode();
                if (this.Alias != null)
                    hashCode = hashCode * 59 + this.Alias.GetHashCode();
                if (this.Tag != null)
                    hashCode = hashCode * 59 + this.Tag.GetHashCode();
                if (this.Source != null)
                    hashCode = hashCode * 59 + this.Source.GetHashCode();
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
