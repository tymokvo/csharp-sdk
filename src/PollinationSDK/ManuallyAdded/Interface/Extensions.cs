using System.Collections.Generic;

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

        private static object GetPropertyValue(this Interface.Io.Inputs.IoBase ioBase, string propertyName)
        {
            return ioBase.GetType().GetProperty(propertyName).GetValue(ioBase, null);
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
    }
}
