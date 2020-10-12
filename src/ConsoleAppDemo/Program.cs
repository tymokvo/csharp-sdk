using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PollinationSDK;
using RestSharp;
using System.Net;
using RestSharp.Extensions;
using System.IO;
using PollinationSDK.Wrapper;
using System.Threading;

namespace ConsoleAppDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to sign in...");
            Console.ReadKey();


          
            AuthHelper.SignInAsync( devEnv: true).Wait();

            var me = Helper.CurrentUser;
            Console.WriteLine($"You are: {me.Username}");


            Console.WriteLine("--------------------Get recipes-------------------");
            var api = new RecipesApi();
            var recipeList = api.ListRecipes(1, 25);
            var recs = recipeList.Resources;
            foreach (var item in recs)
            {
                Console.WriteLine($"{item.Owner.Name}/{item.Name}/{item.LatestTag}");
            }


            //Console.WriteLine("--------------------Get projects-------------------");
            //var projApi = new ProjectsApi();
            //var projList = projApi.ListProjects(page: 1, perPage: 25);
            //foreach (var item in projList.Resources)
            //{
            //    Console.WriteLine($"{item.Owner.Name}/{item.Name}/is public: {item.Public}/Admin: {item.Permissions.Admin}");
            //    Console.WriteLine($"{item.Permissions}");
            //}


            //Console.WriteLine("--------------------Get a recipe-------------------");
            //var recipeOwner = "ladybug-tools";
            //var recipeName = "daylight-factor";
            //var recipeApi = new RecipesApi();
            //var rec = recipeApi.GetRecipeByTag(recipeOwner, recipeName, "latest");
            //Console.WriteLine($"{rec.Manifest.Metadata.Name}/{rec.Manifest.Metadata.Name}/{rec.Tag}");


            //Console.WriteLine("--------------------Get a project-------------------");
            //var proj = Helper.GetAProject(me, "demo");
            //Console.WriteLine($"Getting the project. \n Found this project ID: {proj.Id}");


            //Console.WriteLine("--------------------Getting Recipe Params-------------------");
            //GetRecipeParameters();


            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine("Creating a project");
            //var proj = CreateAProject(me);


            //Console.WriteLine("--------------------Upload a directory-------------------");
            //var dir = @"C:\Users\mingo\Downloads\Compressed\project_folder\project_folder";
            //var task = Helper.UploadDirectoryAsync(proj, dir);
            //task.Wait();


            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine("Getting the recipes");
            //var recipies = GetRecipes();
            //Console.WriteLine(string.Join("\n", recipies));


            //Console.WriteLine("---------------------------------------");
            //var projects = GetProjects();
            //Console.WriteLine("Getting the project list");
            //Console.WriteLine(string.Join("\n", projects));


            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine($"Deleting the project {newProj}");
            //DeleteMyProjects(me, newProj);


            //Console.WriteLine("--------------------Creating a new Simulaiton-------------------");
            ////CreateSimulation(proj);
            //var cts = new System.Threading.CancellationTokenSource();
            //var token = cts.Token;

            ////var workflow = CreateWorkflow("ladybug-tools", "annual-daylight");
            //var workflow = CreateWorkflow_AnnualDaylight();

            //try
            //{
            //    var task = runSimu(proj, workflow, Console.WriteLine, token);

            //    //cts.CancelAfter(60000);
            //    task.Wait();

            //    Console.WriteLine($"Canceled check: {token.IsCancellationRequested}");
            //    cts.Dispose();


            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.InnerException.Message);
            //    //throw;
            //}



            //Console.WriteLine("--------------------Download simulation output-------------------");
            //DownloadOutputs(proj, "8b7033ac-e2e7-44d3-b631-81fa1ecfefb0", new List<string> { "results"});
            //Console.WriteLine("Done downloading");


            //Console.WriteLine("--------------------Download simulation log-------------------");
            ////@"C:\\Users\\mingo\\AppData\\Local\\Temp\\Pollination\\9936f815-25f1-40b8-a298-71091dd6b71a\\re4veore.tvs\\logs.tgz"
            //var simu = new Simulation(proj, "419f600f-3f31-4dda-a7f5-1cdcd2bab08d");
            //var simuLog = simu.GetSimulationOutputLogAsync(Console.WriteLine).Result;

            //Console.WriteLine("Done downloading");
            //Console.WriteLine(simuLog);



            Console.ReadKey();

        }

        private static async Task runSimu(Project proj, SubmitSimulation workflow, Action<string> msgAction, CancellationToken token)
        {
            try
            {
                var simu = await Helper.RunSimulationAsync(proj, workflow, msgAction, token);
                await simu.CheckStatusAndGetLogsAsync(msgAction, token);

                msgAction(simu.Logs);

                if (!token.IsCancellationRequested)
                {
                    var dup = simu.Duplicate();
                    msgAction($"Finished simulation: {dup.ToJson()}");
                }

                msgAction($"Canceled by user: {token.IsCancellationRequested}");

            }
            catch (Exception)
            {

                throw;
            }
           

        }

        private static IEnumerable<string> GetRecipes()
        {
            var api = new RecipesApi();
            var d = api.ListRecipes(_public: true);
            var recipes = d.Resources.Select(_ => _.Name);

            return recipes;
        }

        private static void GetRecipeParameters()
        {
            var api = new RecipesApi();
            //var d = api.ListRecipes(owner: new[] { "ladybug-tools" }.ToList()).Resources.First(_ => _.Name == "annual-energy-use");

            var recTag = api.GetRecipeByTag("ladybug-tools", "annual-energy-use", "latest");
            //var recTag = api.GetRecipeByTag("ladybug-tools", "annual-energy-use", "c2657adb0b13db6cd3ff706d9d6db59b98ef8f994d2809d23c3ed449c19b52ea");
            //TODO: ask Antoine to fix why Manifest returns Recipe 
            var mani = recTag.Manifest;
            //TODO: ask Antoine to fix why Flow returns DAG 
            var flow = mani.Flow.First();
            var inputs = flow.Inputs;
            var ParamNames = inputs.Parameters.Select(_ => _.Name);
            Console.WriteLine("------------------Getting Recipe Input Params---------------------");
            Console.WriteLine(string.Join("\n", ParamNames));

            var artifactNames = inputs.Artifacts.Select(_ => _.Name);
            Console.WriteLine("------------------Getting Recipe Input artifacts---------------------");
            Console.WriteLine(string.Join("\n", artifactNames));

            //return inputs.ToString();
            //return recipes;
        }

        private static Workflow CreateWorkflow_AnnualDaylight()
        {
            var recipeOwner = "ladybug-tools";
            var recipeName = "annual-daylight";
            var recipeApi = new RecipesApi();
            var rec = recipeApi.GetRecipeByTag(recipeOwner, recipeName, "latest");
            var arg = new SimulationInputs()
            {
                Parameters = new List<SimulationInputParameter>()
                {
                    new SimulationInputParameter("sensor-grids", "[\"room\"]")
                },
                Artifacts = new List<SimulationInputArtifact>()
                {
                    new SimulationInputArtifact("model", new ProjectFolderSource(@"C:\Users\mingo\Downloads\Compressed\project_folder\project_folder\model")),
                    new SimulationInputArtifact("wea", new ProjectFolderSource(@"C:\Users\mingo\Downloads\Compressed\project_folder\project_folder\in.wea"))
                }
            };

            var wf = new PollinationSDK.Wrapper.Workflow(recipeOwner, rec, arg);
            return wf;
        }


        private static Workflow CreateWorkflow(string recipeOwner, string recipeName)
        {
            var recipeApi = new RecipesApi();
            var rec = recipeApi.GetRecipeByTag(recipeOwner, recipeName, "latest");
            var arg = new SimulationInputs()
            {
                Parameters = new List<SimulationInputParameter>()
                {
                    new SimulationInputParameter("filter-design-days", "True")
                },
                Artifacts = new List<SimulationInputArtifact>()
                {
                    new SimulationInputArtifact("ddy-file", new ProjectFolderSource(@"C:\ladybug\USA_NY_New.York-Kennedy.Intl.AP.744860_TMY3\USA_NY_New.York-Kennedy.Intl.AP.744860_TMY3.ddy")),
                    new SimulationInputArtifact("epw-file", new ProjectFolderSource(@"C:\ladybug\USA_NY_New.York-Kennedy.Intl.AP.744860_TMY3\USA_NY_New.York-Kennedy.Intl.AP.744860_TMY3.epw")),
                    new SimulationInputArtifact("model-json", new ProjectFolderSource(@"D:\Dev\honeybee-schema\samples\model\model_complete_single_zone_office.json"))
                }
            };
            
            var wf = new PollinationSDK.Wrapper.Workflow(recipeOwner, rec, arg);
            return wf;
        }


        private static ProjectList GetProjects(UserPrivate user)
        {
            var api = new ProjectsApi();
            var d = api.ListProjects(_public: true, owner: new List<string>() { user.Username });
            //var projectNames = d.Select(_ => $"<{_.Id}> {_.Name} ({_.Owner.Name})");

            return d;
        }

        private static Project CreateAProject(UserPrivate user)
        {
            var userName = user.Username;
            //var userName = "mingbo";


            var api = new ProjectsApi();

            var name = "My new project " + Guid.NewGuid().ToString().Substring(0, 5);
            var proj = new ProjectCreate(name, "A new project from GH");

            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Creating project: {name}");
            var res = api.CreateProject(userName, proj);

            Console.WriteLine($"New project id: {res.Id}");
            Console.WriteLine(res.Message);

            var newProj = Helper.GetAProject(user.Username, name);
            return newProj;
        }

        private static void DeleteMyProjects(UserPrivate user, string projectName)
        {
            var userName = user.Username;
            var api = new ProjectsApi();
            api.DeleteProject(userName, projectName);

        }

        private static async Task<bool> CheckSimulationStatus(Project proj, string simuId)
        {
            var api = new SimulationsApi();

            var status = api.GetSimulation(proj.Owner.Name, proj.Name, simuId);
            var startTime = status.StartedAt.ToUniversalTime();
            while (status.Status == "Running")
            {

                await Task.Delay(1000);
                var runseconds = Math.Round((DateTime.UtcNow - startTime).TotalSeconds);
                Console.WriteLine($"{status.Status}: [{runseconds} s]");

                // update status
                status = api.GetSimulation(proj.Owner.Name, proj.Name, simuId);

            }

            var totalSeconds = Math.Round((DateTime.UtcNow - startTime).TotalSeconds);
            Console.WriteLine($"{status.Status}: [{totalSeconds} s]");

            return true;
        }

        private static void CheckOutputLogs(Project proj, string simuId)
        {
            var api = new SimulationsApi();
            var outputs = api.GetSimulationLogs(proj.Owner.Name, proj.Name, simuId.ToString());
            Console.WriteLine(outputs);
        }

        private async static void DownloadOutputs(Project proj, string simuId, List<string> artifacts)
        {
            var simu = new Simulation(proj, simuId);
            var simuStatus = new PollinationSDK.Api.SimulationsApi().GetSimulation(simu.Project.Owner.Name, simu.Project.Name, simu.SimulationID);

            var artfs = artifacts.Select(_ => new OutputArtifact(_)).ToList();
            var temp = Path.Combine( Path.GetTempPath(), Path.GetRandomFileName());
            //Directory.CreateDirectory(temp);

            Action<int> reportPercent = (int percent) => Console.WriteLine($"{percent}%");
            var filePaths = await PollinationSDK.Helper.DownloadOutputArtifactsAsync(simu, artfs, temp, reportPercent);

          

        }



    }


}
