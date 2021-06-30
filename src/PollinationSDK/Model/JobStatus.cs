/* 
 * pollination-server
 *
 * Pollination Server OpenAPI Definition
 *
 * The version of the OpenAPI document: 0.14.0
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
    /// Parametric Job Status.
    /// </summary>
    [DataContract]
    public partial class JobStatus :  IEquatable<JobStatus>, IValidatableObject
    {
        /// <summary>
        /// The status of this job.
        /// </summary>
        /// <value>The status of this job.</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public JobStatusEnum? Status { get; set; }   
        /// <summary>
        /// Initializes a new instance of the <see cref="JobStatus" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JobStatus() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JobStatus" /> class.
        /// </summary>
        /// <param name="annotations">An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries..</param>
        /// <param name="finishedAt">The time at which the task was completed.</param>
        /// <param name="id">The ID of the individual job. (required).</param>
        /// <param name="message">Any message produced by the job. Usually error/debugging hints..</param>
        /// <param name="runsCancelled">The count of runs that have been cancelled (default to 0).</param>
        /// <param name="runsCompleted">The count of runs that have completed (default to 0).</param>
        /// <param name="runsFailed">The count of runs that have failed (default to 0).</param>
        /// <param name="runsPending">The count of runs that are pending (default to 0).</param>
        /// <param name="runsRunning">The count of runs that are running (default to 0).</param>
        /// <param name="source">Source url for the status object. It can be a recipe or a function..</param>
        /// <param name="startedAt">The time at which the job was started (required).</param>
        /// <param name="status">The status of this job..</param>
        public JobStatus
        (
           string id, DateTime startedAt, // Required parameters
           Dictionary<string, string> annotations= default, DateTime finishedAt= default, string message= default, int runsCancelled = 0, int runsCompleted = 0, int runsFailed = 0, int runsPending = 0, int runsRunning = 0, string source= default, JobStatusEnum? status= default // Optional parameters
        )// BaseClass
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new InvalidDataException("id is a required property for JobStatus and cannot be null");
            }
            else
            {
                this.Id = id;
            }
            
            // to ensure "startedAt" is required (not null)
            if (startedAt == null)
            {
                throw new InvalidDataException("startedAt is a required property for JobStatus and cannot be null");
            }
            else
            {
                this.StartedAt = startedAt;
            }
            
            this.Annotations = annotations;
            this.FinishedAt = finishedAt;
            this.Message = message;
            // use default value if no "runsCancelled" provided
            if (runsCancelled == null)
            {
                this.RunsCancelled =0;
            }
            else
            {
                this.RunsCancelled = runsCancelled;
            }
            // use default value if no "runsCompleted" provided
            if (runsCompleted == null)
            {
                this.RunsCompleted =0;
            }
            else
            {
                this.RunsCompleted = runsCompleted;
            }
            // use default value if no "runsFailed" provided
            if (runsFailed == null)
            {
                this.RunsFailed =0;
            }
            else
            {
                this.RunsFailed = runsFailed;
            }
            // use default value if no "runsPending" provided
            if (runsPending == null)
            {
                this.RunsPending =0;
            }
            else
            {
                this.RunsPending = runsPending;
            }
            // use default value if no "runsRunning" provided
            if (runsRunning == null)
            {
                this.RunsRunning =0;
            }
            else
            {
                this.RunsRunning = runsRunning;
            }
            this.Source = source;
            this.Status = status;

            // Set non-required readonly properties with defaultValue
            this.ApiVersion = "v1beta1";
            this.Type = "JobStatus";
        }
        
        /// <summary>
        /// An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries.
        /// </summary>
        /// <value>An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries.</value>
        [DataMember(Name="annotations", EmitDefaultValue=false)]
        [JsonProperty("annotations")]
        public Dictionary<string, string> Annotations { get; set; } 
        /// <summary>
        /// The time at which the task was completed
        /// </summary>
        /// <value>The time at which the task was completed</value>
        [DataMember(Name="finished_at", EmitDefaultValue=false)]
        [JsonProperty("finished_at")]
        public DateTime FinishedAt { get; set; } 
        /// <summary>
        /// The ID of the individual job.
        /// </summary>
        /// <value>The ID of the individual job.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        [JsonProperty("id")]
        public string Id { get; set; } 
        /// <summary>
        /// Any message produced by the job. Usually error/debugging hints.
        /// </summary>
        /// <value>Any message produced by the job. Usually error/debugging hints.</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        [JsonProperty("message")]
        public string Message { get; set; } 
        /// <summary>
        /// The count of runs that have been cancelled
        /// </summary>
        /// <value>The count of runs that have been cancelled</value>
        [DataMember(Name="runs_cancelled", EmitDefaultValue=false)]
        [JsonProperty("runs_cancelled")]
        public int RunsCancelled { get; set; }  = 0;
        /// <summary>
        /// The count of runs that have completed
        /// </summary>
        /// <value>The count of runs that have completed</value>
        [DataMember(Name="runs_completed", EmitDefaultValue=false)]
        [JsonProperty("runs_completed")]
        public int RunsCompleted { get; set; }  = 0;
        /// <summary>
        /// The count of runs that have failed
        /// </summary>
        /// <value>The count of runs that have failed</value>
        [DataMember(Name="runs_failed", EmitDefaultValue=false)]
        [JsonProperty("runs_failed")]
        public int RunsFailed { get; set; }  = 0;
        /// <summary>
        /// The count of runs that are pending
        /// </summary>
        /// <value>The count of runs that are pending</value>
        [DataMember(Name="runs_pending", EmitDefaultValue=false)]
        [JsonProperty("runs_pending")]
        public int RunsPending { get; set; }  = 0;
        /// <summary>
        /// The count of runs that are running
        /// </summary>
        /// <value>The count of runs that are running</value>
        [DataMember(Name="runs_running", EmitDefaultValue=false)]
        [JsonProperty("runs_running")]
        public int RunsRunning { get; set; }  = 0;
        /// <summary>
        /// Source url for the status object. It can be a recipe or a function.
        /// </summary>
        /// <value>Source url for the status object. It can be a recipe or a function.</value>
        [DataMember(Name="source", EmitDefaultValue=false)]
        [JsonProperty("source")]
        public string Source { get; set; } 
        /// <summary>
        /// The time at which the job was started
        /// </summary>
        /// <value>The time at which the job was started</value>
        [DataMember(Name="started_at", EmitDefaultValue=false)]
        [JsonProperty("started_at")]
        public DateTime StartedAt { get; set; } 
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JobStatus {\n");
            sb.Append("  Annotations: ").Append(Annotations).Append("\n");
            sb.Append("  ApiVersion: ").Append(ApiVersion).Append("\n");
            sb.Append("  FinishedAt: ").Append(FinishedAt).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  RunsCancelled: ").Append(RunsCancelled).Append("\n");
            sb.Append("  RunsCompleted: ").Append(RunsCompleted).Append("\n");
            sb.Append("  RunsFailed: ").Append(RunsFailed).Append("\n");
            sb.Append("  RunsPending: ").Append(RunsPending).Append("\n");
            sb.Append("  RunsRunning: ").Append(RunsRunning).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  StartedAt: ").Append(StartedAt).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
        /// <returns>JobStatus object</returns>
        public static JobStatus FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<JobStatus>(json, JsonSetting.ConvertSetting);
            return obj;
        }

        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>JobStatus object</returns>
        public JobStatus DuplicateJobStatus()
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
            return this.Equals(input as JobStatus);
        }

        /// <summary>
        /// Returns true if JobStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of JobStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JobStatus input)
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
                    this.ApiVersion == input.ApiVersion ||
                    (this.ApiVersion != null &&
                    this.ApiVersion.Equals(input.ApiVersion))
                ) && 
                (
                    this.FinishedAt == input.FinishedAt ||
                    (this.FinishedAt != null &&
                    this.FinishedAt.Equals(input.FinishedAt))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.RunsCancelled == input.RunsCancelled ||
                    (this.RunsCancelled != null &&
                    this.RunsCancelled.Equals(input.RunsCancelled))
                ) && 
                (
                    this.RunsCompleted == input.RunsCompleted ||
                    (this.RunsCompleted != null &&
                    this.RunsCompleted.Equals(input.RunsCompleted))
                ) && 
                (
                    this.RunsFailed == input.RunsFailed ||
                    (this.RunsFailed != null &&
                    this.RunsFailed.Equals(input.RunsFailed))
                ) && 
                (
                    this.RunsPending == input.RunsPending ||
                    (this.RunsPending != null &&
                    this.RunsPending.Equals(input.RunsPending))
                ) && 
                (
                    this.RunsRunning == input.RunsRunning ||
                    (this.RunsRunning != null &&
                    this.RunsRunning.Equals(input.RunsRunning))
                ) && 
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
                ) && 
                (
                    this.StartedAt == input.StartedAt ||
                    (this.StartedAt != null &&
                    this.StartedAt.Equals(input.StartedAt))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
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
                if (this.ApiVersion != null)
                    hashCode = hashCode * 59 + this.ApiVersion.GetHashCode();
                if (this.FinishedAt != null)
                    hashCode = hashCode * 59 + this.FinishedAt.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.RunsCancelled != null)
                    hashCode = hashCode * 59 + this.RunsCancelled.GetHashCode();
                if (this.RunsCompleted != null)
                    hashCode = hashCode * 59 + this.RunsCompleted.GetHashCode();
                if (this.RunsFailed != null)
                    hashCode = hashCode * 59 + this.RunsFailed.GetHashCode();
                if (this.RunsPending != null)
                    hashCode = hashCode * 59 + this.RunsPending.GetHashCode();
                if (this.RunsRunning != null)
                    hashCode = hashCode * 59 + this.RunsRunning.GetHashCode();
                if (this.Source != null)
                    hashCode = hashCode * 59 + this.Source.GetHashCode();
                if (this.StartedAt != null)
                    hashCode = hashCode * 59 + this.StartedAt.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
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
            // ApiVersion (string) pattern
            Regex regexApiVersion = new Regex(@"^v1beta1$", RegexOptions.CultureInvariant);
            if (false == regexApiVersion.Match(this.ApiVersion).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ApiVersion, must match a pattern of " + regexApiVersion, new [] { "ApiVersion" });
            }

            // Type (string) pattern
            Regex regexType = new Regex(@"^JobStatus$", RegexOptions.CultureInvariant);
            if (false == regexType.Match(this.Type).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, must match a pattern of " + regexType, new [] { "Type" });
            }

            yield break;
        }
    }

}
