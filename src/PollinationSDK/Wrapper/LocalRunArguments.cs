

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PollinationSDK.Wrapper
{
    public class LocalRunArguments
    {

        private List<AnyOf<JobArgument, JobPathArgument>> _args { get; }

        public LocalRunArguments(List<AnyOf<JobArgument, JobPathArgument>> arguments)
        {
            this._args = arguments;
        }

        //public void Validate(RecipeInterface recipe)
        //{
        //    // check if any required parameters are missing
        //    var resuired = recipe.InputList.Where(_ => _.Required).Select(_ => _.Name);

        //    var missingRequired = resuired.Where(_ => !this._dic.ContainsKey(_));
        //    if (missingRequired.Any())
        //    {
        //        var msg = string.Join(",", missingRequired);
        //        throw new ArgumentException($"Missing required parameters [{msg}]!");
        //    }
        //}

        public string SaveToFolder(string folder)
        {
            var dic = new Dictionary<string, object>();
            foreach (var item in this._args)
            {
                var argName = string.Empty;
                object argValue = string.Empty;

                if (item.Obj is JobPathArgument p)
                {
                    argName = p.Name;
                    //copy to folder
                    var tempPath = (p.Source.Obj as PollinationSDK.ProjectFolder).Path;
                    if (!File.Exists(tempPath))
                        throw new ArgumentException($"Failed to find path argument {tempPath}");
                    var fileName = Path.GetFileName(tempPath);
                    var newPath = Path.Combine(folder, fileName);
                    File.Copy(tempPath, newPath, true);
                    if (!File.Exists(newPath))
                        throw new ArgumentException($"Failed to find path argument {newPath}");
                    argValue = fileName;

                }
                else if (item.Obj is JobArgument arg)
                {
                    argName = arg.Name;
                    argValue = arg.Value;
                }

                //// check with handlers
                //var alias = this.RecipeInfo.InputArgumentInfos.FirstOrDefault(_ => _.DagInput.Name == argName).DagInputAlias;
                //argValue = CheckInputWithHandler(argValue, alias?.Handler);

                dic.Add(argName, argValue);
            }

            string json = JsonConvert.SerializeObject(dic, Formatting.Indented);
            var path = Path.Combine(folder, "inputs.json");
            File.WriteAllText(path, json);
            if (!File.Exists(path))
                throw new ArgumentException("Failed to save inputs.json");
            return path;
        }

    }

}
