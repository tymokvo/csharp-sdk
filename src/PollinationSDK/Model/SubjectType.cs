/* 
 * Pollination Server
 *
 * Pollination Server OpenAPI Defintion
 *
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
using QueenbeeSDK;

namespace PollinationSDK
{
    /// <summary>
    /// An enumeration.
    /// </summary>
    /// <value>An enumeration.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum SubjectType
    {
        /// <summary>
        /// Enum User for value: user
        /// </summary>
        [EnumMember(Value = "user")]
        User = 1,

        /// <summary>
        /// Enum Team for value: team
        /// </summary>
        [EnumMember(Value = "team")]
        Team = 2

    }

}
