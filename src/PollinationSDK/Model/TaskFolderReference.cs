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
    /// A reference to a folder that is generated in a task.
    /// </summary>
    [DataContract]
    public partial class TaskFolderReference :  IEquatable<TaskFolderReference>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskFolderReference" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TaskFolderReference() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskFolderReference" /> class.
        /// </summary>
        /// <param name="annotations">An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries..</param>
        /// <param name="name">The name of the task to pull output data from. (required).</param>
        /// <param name="variable">The name of the variable. (required).</param>
        public TaskFolderReference
        (
           string name, string variable, // Required parameters
           Dictionary<string, string> annotations= default // Optional parameters
        )// BaseClass
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for TaskFolderReference and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            
            // to ensure "variable" is required (not null)
            if (variable == null)
            {
                throw new InvalidDataException("variable is a required property for TaskFolderReference and cannot be null");
            }
            else
            {
                this.Variable = variable;
            }
            
            this.Annotations = annotations;

            // Set non-required readonly properties with defaultValue
            this.Type = "TaskFolderReference";
        }
        
        /// <summary>
        /// An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries.
        /// </summary>
        /// <value>An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries.</value>
        [DataMember(Name="annotations", EmitDefaultValue=false)]
        [JsonProperty("annotations")]
        public Dictionary<string, string> Annotations { get; set; } 
        /// <summary>
        /// The name of the task to pull output data from.
        /// </summary>
        /// <value>The name of the task to pull output data from.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        [JsonProperty("name")]
        public string Name { get; set; } 
        /// <summary>
        /// The name of the variable.
        /// </summary>
        /// <value>The name of the variable.</value>
        [DataMember(Name="variable", EmitDefaultValue=false)]
        [JsonProperty("variable")]
        public string Variable { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaskFolderReference {\n");
            sb.Append("  Annotations: ").Append(Annotations).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Variable: ").Append(Variable).Append("\n");
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
        /// <returns>TaskFolderReference object</returns>
        public static TaskFolderReference FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<TaskFolderReference>(json, JsonSetting.ConvertSetting);
            return obj;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>TaskFolderReference object</returns>
        public TaskFolderReference DuplicateTaskFolderReference()
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
            return this.Equals(input as TaskFolderReference);
        }

        /// <summary>
        /// Returns true if TaskFolderReference instances are equal
        /// </summary>
        /// <param name="input">Instance of TaskFolderReference to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaskFolderReference input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Variable == input.Variable ||
                    (this.Variable != null &&
                    this.Variable.Equals(input.Variable))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Variable != null)
                    hashCode = hashCode * 59 + this.Variable.GetHashCode();
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
            Regex regexType = new Regex(@"^TaskFolderReference$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
