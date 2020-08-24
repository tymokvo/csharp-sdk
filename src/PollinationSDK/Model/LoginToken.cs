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
    /// LoginToken
    /// </summary>
    [DataContract]
    public partial class LoginToken :  IEquatable<LoginToken>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginToken" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LoginToken() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginToken" /> class.
        /// </summary>
        /// <param name="accessToken">accessToken (required).</param>
        /// <param name="idToken">idToken.</param>
        /// <param name="scope">scope.</param>
        /// <param name="tokenType">tokenType (required).</param>
        /// <param name="expiresIn">expiresIn (required).</param>
        public LoginToken
        (
           string accessToken, string tokenType, int expiresIn, // Required parameters
           string idToken= default, string scope= default // Optional parameters
        )// BaseClass
        {
            // to ensure "accessToken" is required (not null)
            if (accessToken == null)
            {
                throw new InvalidDataException("accessToken is a required property for LoginToken and cannot be null");
            }
            else
            {
                this.AccessToken = accessToken;
            }
            
            // to ensure "tokenType" is required (not null)
            if (tokenType == null)
            {
                throw new InvalidDataException("tokenType is a required property for LoginToken and cannot be null");
            }
            else
            {
                this.TokenType = tokenType;
            }
            
            // to ensure "expiresIn" is required (not null)
            if (expiresIn == null)
            {
                throw new InvalidDataException("expiresIn is a required property for LoginToken and cannot be null");
            }
            else
            {
                this.ExpiresIn = expiresIn;
            }
            
            this.IdToken = idToken;
            this.Scope = scope;

            // Set non-required readonly properties with defaultValue
        }
        
        /// <summary>
        /// Gets or Sets AccessToken
        /// </summary>
        [DataMember(Name="access_token", EmitDefaultValue=false)]
        [JsonProperty("access_token")]
        public string AccessToken { get; set; } 
        /// <summary>
        /// Gets or Sets IdToken
        /// </summary>
        [DataMember(Name="id_token", EmitDefaultValue=false)]
        [JsonProperty("id_token")]
        public string IdToken { get; set; } 
        /// <summary>
        /// Gets or Sets Scope
        /// </summary>
        [DataMember(Name="scope", EmitDefaultValue=false)]
        [JsonProperty("scope")]
        public string Scope { get; set; } 
        /// <summary>
        /// Gets or Sets TokenType
        /// </summary>
        [DataMember(Name="token_type", EmitDefaultValue=false)]
        [JsonProperty("token_type")]
        public string TokenType { get; set; } 
        /// <summary>
        /// Gets or Sets ExpiresIn
        /// </summary>
        [DataMember(Name="expires_in", EmitDefaultValue=false)]
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LoginToken {\n");
            sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
            sb.Append("  IdToken: ").Append(IdToken).Append("\n");
            sb.Append("  Scope: ").Append(Scope).Append("\n");
            sb.Append("  TokenType: ").Append(TokenType).Append("\n");
            sb.Append("  ExpiresIn: ").Append(ExpiresIn).Append("\n");
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
        /// <returns>LoginToken object</returns>
        public static LoginToken FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<LoginToken>(json, JsonSetting.ConvertSetting);
            return obj;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>LoginToken object</returns>
        public LoginToken DuplicateLoginToken()
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
            return this.Equals(input as LoginToken);
        }

        /// <summary>
        /// Returns true if LoginToken instances are equal
        /// </summary>
        /// <param name="input">Instance of LoginToken to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LoginToken input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AccessToken == input.AccessToken ||
                    (this.AccessToken != null &&
                    this.AccessToken.Equals(input.AccessToken))
                ) && 
                (
                    this.IdToken == input.IdToken ||
                    (this.IdToken != null &&
                    this.IdToken.Equals(input.IdToken))
                ) && 
                (
                    this.Scope == input.Scope ||
                    (this.Scope != null &&
                    this.Scope.Equals(input.Scope))
                ) && 
                (
                    this.TokenType == input.TokenType ||
                    (this.TokenType != null &&
                    this.TokenType.Equals(input.TokenType))
                ) && 
                (
                    this.ExpiresIn == input.ExpiresIn ||
                    (this.ExpiresIn != null &&
                    this.ExpiresIn.Equals(input.ExpiresIn))
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
                if (this.AccessToken != null)
                    hashCode = hashCode * 59 + this.AccessToken.GetHashCode();
                if (this.IdToken != null)
                    hashCode = hashCode * 59 + this.IdToken.GetHashCode();
                if (this.Scope != null)
                    hashCode = hashCode * 59 + this.Scope.GetHashCode();
                if (this.TokenType != null)
                    hashCode = hashCode * 59 + this.TokenType.GetHashCode();
                if (this.ExpiresIn != null)
                    hashCode = hashCode * 59 + this.ExpiresIn.GetHashCode();
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
