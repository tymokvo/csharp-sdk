
using System.Collections.Generic;
using System.Linq;

namespace PollinationSDK
{
    public static class ModelExtensions
    {
        public static List<Interface.Io.Outputs.IDag> GetOutputs(this RecipeInterface recipe)
        {
            var outputs = recipe.Outputs
              .OfType<Interface.Io.Outputs.IDag>().ToList();

            return outputs;
        }
        public static List<Interface.Io.Inputs.IDag> GetInputs(this RecipeInterface recipe)
        {
            var outputs = recipe.Inputs
              .OfType<Interface.Io.Inputs.IDag>().ToList();

            return outputs;
        }
        
        public static Interface.Io.Inputs.IStep ToStepInput(this Interface.Io.Inputs.IDag dag, object value)
        {
            if (value == null)
                throw new System.ArgumentNullException("Input value cannot be null for step input");
            Interface.Io.Inputs.IStep step = null;
            //AnyOf<DAGGenericInput,DAGStringInput,DAGIntegerInput,DAGNumberInput,DAGBooleanInput,DAGFolderInput,DAGFileInput,DAGPathInput,DAGArrayInput,DAGJSONObjectInput>
            switch (dag)
            {
                case DAGStringInput s:
                    step = new StepStringInput(s.Name, value.ToString(), s.Annotations, s.Description, s.Default, s.Alias, s.Required, s.Spec);
                    break;
                case DAGIntegerInput s:
                    step = new StepIntegerInput(s.Name, int.Parse(value.ToString()), s.Annotations, s.Description, s.Default, s.Alias, s.Required, s.Spec);
                    break;
                case DAGNumberInput s:
                    step = new StepNumberInput(s.Name, double.Parse(value.ToString()), s.Annotations, s.Description, s.Default, s.Alias, s.Required, s.Spec);
                    break;
                case DAGBooleanInput s:
                    step = new StepBooleanInput(s.Name, bool.Parse(value.ToString()), s.Annotations, s.Description, s.Default, s.Alias, s.Required, s.Spec);
                    break;
                case DAGFolderInput s:
                    step = new StepFolderInput(s.Name, new ProjectFolder( path: value.ToString()), s.Annotations, s.Description, s.Default, s.Alias, s.Required, s.Spec);
                    break;
                case DAGFileInput s:
                    step = new StepFileInput(s.Name, new ProjectFolder(path: value.ToString()), s.Annotations, s.Description, s.Default, s.Alias, s.Required, s.Spec, extensions: s.Extensions);
                    break;
                case DAGPathInput s:
                    step = new StepPathInput(s.Name, new ProjectFolder(path: value.ToString()), s.Annotations, s.Description, s.Default, s.Alias, s.Required, s.Spec, extensions: s.Extensions);
                    break;
                case DAGArrayInput s:
                    //["room", "hallway"]
                    var list = value.ToString().Trim(new char[] { '[', ']', ' ' }).Split(',').Select(_=>_.Trim(new char[] { '"', ' ' }) as object).ToList();
                    step = new StepArrayInput(s.Name, list, s.Annotations, s.Description, s.Default, s.Alias, s.Required, s.Spec, s.ItemsType);
                    break;
                case DAGJSONObjectInput g:
                    step = new StepJSONObjectInput(g.Name, value, g.Annotations, g.Description, g.Default, g.Alias, g.Required, g.Spec);
                    break;
                case DAGGenericInput g:
                    step = new StepStringInput(g.Name, value.ToString(), g.Annotations, g.Description, g.Default, g.Alias, g.Required, g.Spec);
                    break;
                default:
                    throw new System.ArgumentException($"{dag.GetType().Name} is not supported to be converted to step input");
                    break;
            }

            return step;
        }
    }
}
