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
    /// The Inputs of a Function
    /// </summary>
    [DataContract]
    public partial class FunctionInputs : HoneybeeObject, IEquatable<FunctionInputs>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionInputs" /> class.
        /// </summary>
        /// <param name="parameters">parameters.</param>
        /// <param name="artifacts">artifacts.</param>
        public FunctionInputs
        (
            , // Required parameters
            , List<FunctionParameterIn> parameters= default, List<FunctionArtifact> artifacts= default// Optional parameters
        )// BaseClass
        {
            this.Parameters = parameters;
            this.Artifacts = artifacts;

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// Gets or Sets Parameters
        /// </summary>
        [DataMember(Name="parameters", EmitDefaultValue=false)]
        [JsonProperty("parameters")]
        public List<FunctionParameterIn> Parameters { get; set; } 
        /// <summary>
        /// Gets or Sets Artifacts
        /// </summary>
        [DataMember(Name="artifacts", EmitDefaultValue=false)]
        [JsonProperty("artifacts")]
        public List<FunctionArtifact> Artifacts { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            if (this is IIDdBase iDd)
                return $"FunctionInputs {iDd.Identifier}";
       
            return "FunctionInputs";
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
            sb.Append("FunctionInputs:\n");
            sb.Append("  Parameters: ").Append(Parameters).Append("\n");
            sb.Append("  Artifacts: ").Append(Artifacts).Append("\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>FunctionInputs object</returns>
        public static FunctionInputs FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<FunctionInputs>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() ? obj : null;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>FunctionInputs object</returns>
        public FunctionInputs DuplicateFunctionInputs()
        {
            return Duplicate() as FunctionInputs;
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
            return this.Equals(input as FunctionInputs);
        }

        /// <summary>
        /// Returns true if FunctionInputs instances are equal
        /// </summary>
        /// <param name="input">Instance of FunctionInputs to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FunctionInputs input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Parameters == input.Parameters ||
                    this.Parameters != null &&
                    input.Parameters != null &&
                    this.Parameters.SequenceEqual(input.Parameters)
                ) && 
                (
                    this.Artifacts == input.Artifacts ||
                    this.Artifacts != null &&
                    input.Artifacts != null &&
                    this.Artifacts.SequenceEqual(input.Artifacts)
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
                if (this.Parameters != null)
                    hashCode = hashCode * 59 + this.Parameters.GetHashCode();
                if (this.Artifacts != null)
                    hashCode = hashCode * 59 + this.Artifacts.GetHashCode();
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
