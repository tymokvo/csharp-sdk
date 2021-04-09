using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System.Linq;

namespace PollinationSDK
{
    public static class IOExtensions
    {
        public static object GetDefaultValue(this Interface.Io.Inputs.IDag inputDag)
        {
            // use this dummy is for future-proofing. Just in case "Default" is changed in the future
            DAGStringInput dummy;
            return inputDag.GetPropertyValue(nameof(dummy.Default));
        }

        public static object GetDefaultValue(this Interface.Io.Inputs.IAlias inputAlias)
        {
            // use this dummy is for future-proofing. Just in case "Default" is changed in the future
            DAGStringInputAlias dummy;
            return inputAlias.GetPropertyValue(nameof(dummy.Default));
        }

        public static object GetDefaultValue(this Interface.Io.Inputs.IStep inputStep)
        {
            // use this dummy is for future-proofing. Just in case "Default" is changed in the future
            StepStringInput dummy;
            return inputStep.GetPropertyValue(nameof(dummy.Default));
        }

        /// <summary>
        /// Get user's argument of value type inputs (string, int, double, etc)
        /// </summary>
        /// <param name="inputStep"></param>
        /// <returns>return an empty list if inputStep is a path type, which need to be downloaded</returns>
        public static List<object> GetInputValue(this Interface.Io.Inputs.IStep inputStep)
        {
            var value = new List<object>();

            if (inputStep.IsPathType()) return value;

            if (inputStep is StepArrayInput s)
                value.AddRange(s.Value);
            else
            {
                var v = inputStep.GetValue();
                value.Add(v);
            }

            return value;
        }

        /// <summary>
        /// Get asset path of ProjectFolder type to be downloaded
        /// </summary>
        /// <param name="inputStep"></param>
        /// <returns>return empty if it is not a path type input</returns>
        public static string GetInputPath(this Interface.Io.Inputs.IStep inputStep)
        {
            var value = string.Empty;
            if (inputStep.IsPathType())
            {
                var pathSource = inputStep.GetPathSource();
                if (pathSource.Obj is ProjectFolder file)
                    value = file.Path;
                else
                    throw new System.ArgumentException($"The source of {inputStep.Name} is {pathSource.Obj.GetType()}, which is not supported ProjectFolder type");

            }
            return value;
        }

        private static object GetPropertyValue(this Interface.Io.Inputs.IoBase ioBase, string propertyName)
        {
            return ioBase.GetType().GetProperty(propertyName).GetValue(ioBase, null);
        }

        private static JsonSchema GetSpecSchema(this Interface.Io.Inputs.IoBase ioBase)
        {
            if (ioBase.Spec == null) return null;
            var specJson = ioBase.Spec.ToString();
            return JsonSchema.Parse(specJson);
        }

        public static bool ValidateWithSpec(this Interface.Io.Inputs.IoBase ioBase, object value, out IList<string> outputMessages)
        {
            outputMessages = null;
            if (ioBase.Spec == null) return true;
            var spec = ioBase.GetSpecSchema();

            var data = JToken.FromObject(value);
            var valid  = data.IsValid(spec, out outputMessages);
           

            return valid;
        }
        /// <summary>
        /// Validate input value against spec schema
        /// </summary>
        /// <param name="ioBase"></param>
        /// <param name="value"></param>
        /// <returns>Returns true, otherwise throw ArgumentException if value is not valid</returns>
        public static bool ValidateWithSpec(this Interface.Io.Inputs.IoBase ioBase, object value)
        {
            
            if (!ioBase.ValidateWithSpec(value, out var messages))
            {
                var msg = string.Join("\n", messages);
                throw new System.ArgumentException(msg);
            }

            return true;
        }

        public static bool IsValueType(this Interface.Io.Inputs.IStep inputStep)
        {
            return !inputStep.IsPathType();
        }

        /// <summary>
        /// Check if a Step input is a StepFileInput, StepFolderInput, or StepPathInput
        /// </summary>
        /// <param name="inputStep"></param>
        /// <returns></returns>
        public static bool IsPathType(this Interface.Io.Inputs.IStep inputStep)
        {
            if (inputStep is StepFileInput) return true;
            if (inputStep is StepFolderInput) return true;
            if (inputStep is StepPathInput) return true;
            return false;
        }

        /// <summary>
        /// Check if a Dag input is a DAGFileInput, DAGFolderInput, or DAGPathInput
        /// </summary>
        /// <param name="inputDag"></param>
        /// <returns></returns>
        public static bool IsPathType(this Interface.Io.Inputs.IDag inputDag)
        {
            if (inputDag is DAGFileInput) return true;
            if (inputDag is DAGFolderInput) return true;
            if (inputDag is DAGPathInput) return true;
            return false;
        }

        /// <summary>
        /// Get the source of a path type Step input. Returns null if inputStep is not path type
        /// </summary>
        /// <param name="inputStep"></param>
        /// <returns></returns>
        public static AnyOf<HTTP, S3, ProjectFolder> GetPathSource(this Interface.Io.Inputs.IStep inputStep)
        {
            if (inputStep.IsPathType())
            {
                StepFileInput dummy;
                return inputStep.GetPropertyValue(nameof(dummy.Source)) as AnyOf<HTTP, S3, ProjectFolder>;
            }
            else
            {
                return null;
            }
            
        }

        /// <summary>
        /// Get the value of non-path type Stet input. Returns null if inputStep is a path type
        /// </summary>
        /// <param name="inputStep"></param>
        /// <returns></returns>
        public static object GetValue(this Interface.Io.Inputs.IStep inputStep)
        {
            if (inputStep.IsValueType())
            {
                StepStringInput dummy;
                return inputStep.GetPropertyValue(nameof(dummy.Value));
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Get an alias for a platform (rhino, grasshopper, revit, etc)
        /// </summary>
        /// <param name="inputDag"></param>
        /// <param name="platform">platform name (rhino, grasshopper, revit, etc)</param>
        /// <returns></returns>
        public static Interface.Io.Inputs.IAlias GetAlias(this Interface.Io.Inputs.IDag inputDag, string platform)
        {
            return inputDag.Alias?.OfType<Interface.Io.Inputs.IAlias>()?.FirstOrDefault(_ => _.Platform.Contains(platform));

        }

        /// <summary>
        /// Get an alias for a platform (rhino, grasshopper, revit, etc)
        /// </summary>
        /// <param name="outputDag"></param>
        /// <param name="platform">platform name (rhino, grasshopper, revit, etc)</param>
        /// <returns></returns>
        public static Interface.Io.Outputs.IAlias GetAlias(this Interface.Io.Outputs.IDag outputDag, string platform)
        {
            return outputDag.Alias?.OfType<Interface.Io.Outputs.IAlias>()?.FirstOrDefault(_ => _.Platform.Contains(platform));

        }


    }
}
