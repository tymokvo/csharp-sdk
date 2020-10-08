using PollinationSDK.Model;
using System;
using System.Linq;

namespace PollinationSDK.Wrapper
{
    /// <summary>
    /// A Wrapper for SubmitSimulationDto, which overrides the ToString() to provide a human readable format.
    /// </summary>
    public class Workflow: SubmitSimulation
    {
        public Workflow(string recipeOwner, RecipePackage recipe, SimulationInputs args)
            : base(PackageToRecipeSel(recipeOwner, recipe), args)
        {
        }

        private static RecipeSelection PackageToRecipeSel(string recipeOwner, RecipePackage recipe)
        {
            var name = recipe.Manifest.Metadata.Name;
            var digest = recipe.Digest;
            return new RecipeSelection(name: name, owner: recipeOwner, digest);
        }

        public override string ToString()
        {
            var headerString = $"{this.Recipe.Owner}/{this.Recipe.Name}/{this.Recipe.Tag}";

            var inputParams = this.Inputs.Parameters.Select(_ => $"    {_.Name}: {_.Value}").ToList();
            inputParams.AddRange(this.Inputs.Artifacts.Select(_ => $"    {_.Name}: {_.Source}"));
            var inputParamsString = string.Join(Environment.NewLine, inputParams);

            return $"{headerString}:{Environment.NewLine}{inputParamsString}";
        }

    }
}
