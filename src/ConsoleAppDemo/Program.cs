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


            //var a = new ArtifaceSourcePath("asset/grid/room.pts");
            //Console.WriteLine(a);
            //var arg = new ArgumentArtifact("input-grid", a);
            ////var aj = JsonConvert.SerializeObject(a);
            //Console.WriteLine(arg.ToJson());
          
            AuthHelper.SignInAsync().Wait();

            var me = Helper.CurrentUser;
            Console.WriteLine($"You are: {me.Username}");


            Console.WriteLine("--------------------Get a project-------------------");
            var proj = Helper.GetAProject(me, "unnamed");
            Console.WriteLine($"Getting the project. \n Found this project ID: {proj.Id}");


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

            //var workflow = CreateWorkflow();

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
            //DownloadOutputs(proj, "e89ecadf-6844-4ca6-a02d-1c2382231f87");
            //Console.WriteLine("Done downloading");

            Console.WriteLine("--------------------Download simulation log-------------------");
            //@"C:\\Users\\mingo\\AppData\\Local\\Temp\\Pollination\\9936f815-25f1-40b8-a298-71091dd6b71a\\re4veore.tvs\\logs.tgz"
            var simu = new Simulation(proj, "419f600f-3f31-4dda-a7f5-1cdcd2bab08d");
            var simuLog = simu.GetSimulationOutputLogAsync(Console.WriteLine).Result;

            Console.WriteLine("Done downloading");
            Console.WriteLine(simuLog);



            Console.ReadKey();

        }

        private static async Task runSimu(ProjectDto proj, SubmitSimulationDto workflow, Action<string> msgAction, CancellationToken token)
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
        private static Workflow CreateWorkflow()
        {
            var recipeApi = new RecipesApi();
            var recOwner = "ladybug-tools";
            var rec = recipeApi.GetRecipeByTag(recOwner, "annual-energy-use", "latest");
            var arg = new AppModulesProjectsDtoSimulationArguments()
            {
                Parameters = new List<ArgumentParameter>()
                {
                    new ArgumentParameter("filter-design-days", "True")
                },
                Artifacts = new List<AppModulesProjectsDtoSimulationArgumentArtifact>()
                {
                    new AppModulesProjectsDtoSimulationArgumentArtifact("ddy-file", new ArtifaceSourcePath(@"C:\ladybug\USA_NY_New.York-Kennedy.Intl.AP.744860_TMY3\USA_NY_New.York-Kennedy.Intl.AP.744860_TMY3.ddy")),
                    new AppModulesProjectsDtoSimulationArgumentArtifact("epw-file", new ArtifaceSourcePath(@"C:\ladybug\USA_NY_New.York-Kennedy.Intl.AP.744860_TMY3\USA_NY_New.York-Kennedy.Intl.AP.744860_TMY3.epw")),
                    new AppModulesProjectsDtoSimulationArgumentArtifact("model-json", new ArtifaceSourcePath(@"D:\Dev\honeybee-schema\samples\model\model_complete_single_zone_office.json"))
                }
            };
            
            var wf = new PollinationSDK.Wrapper.Workflow(recOwner, rec, arg);
            return wf;
        }


        private static IEnumerable<ProjectDto> GetProjects(PrivateUserDto user)
        {
            var api = new ProjectsApi();
            var d = api.ListProjects(_public: true, owner: new List<string>() { user.Username });
            //var projectNames = d.Select(_ => $"<{_.Id}> {_.Name} ({_.Owner.Name})");

            return d;
        }

        private static ProjectDto CreateAProject(PrivateUserDto user)
        {
            var userName = user.Username;
            //var userName = "mingbo";


            var api = new ProjectsApi();

            var name = "My new project " + Guid.NewGuid().ToString().Substring(0, 5);
            var proj = new PatchProjectDto(name, "A new project from GH");

            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Creating project: {name}");
            var res = api.CreateProject(userName, proj);

            Console.WriteLine($"New project id: {res.Id}");
            Console.WriteLine(res.Message);

            var newProj = Helper.GetAProject(user, name);
            return newProj;
        }

        private static void DeleteMyProjects(PrivateUserDto user, string projectName)
        {
            var userName = user.Username;
            var api = new ProjectsApi();
            api.DeleteProject(userName, projectName);

        }

        private static async Task<bool> CheckSimulationStatus(ProjectDto proj, string simuId)
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

        private static void CheckOutputLogs(ProjectDto proj, string simuId)
        {
            var api = new SimulationsApi();
            var outputs = api.GetSimulationLogs(proj.Owner.Name, proj.Name, simuId.ToString());
            Console.WriteLine(outputs);
        }

        private async static void DownloadOutputs(ProjectDto proj, string simuId)
        {
            var api = new PollinationSDK.Api.SimulationsApi();

            var outputDownloadURL = api.GetSimulationOutputs(proj.Owner.Name, proj.Name, simuId).ToString();
            //outputDownloadURL = "https://nyc3.digitaloceanspaces.com/pollination-bucket/accounts/9af569d8-1ce9-4bed-914b-32051b3b2d2d/projects/2d69dd8b-5a32-4fa9-a16f-5637c451c17e/simulations/e89ecadf-6844-4ca6-a02d-1c2382231f87/outputs.tgz?AWSAccessKeyId=ECHSSBKXTHZWSJ3UV4CU&Signature=m%2FLN3Rr%2FB6MUD6xnGWagHTl7YHI%3D&Expires=1594700427";
            var fileName = Path.GetFileName(outputDownloadURL).Split(new[] { '?' })[0];

            Console.WriteLine($"Simulation output link url: {outputDownloadURL}");
            var request = new RestRequest(Method.GET);
            var client = new RestClient(outputDownloadURL.ToString());
            var response = await client.ExecuteTaskAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Unable to download file");

            Task.Delay(3000);


            var file = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), fileName);
            response.RawBytes.SaveAs(file);

            if (File.Exists(file))
            {
                Console.WriteLine($"Finished downloading: {file}");
            }

            //client.DownloadData(request).SaveAs(file);

        }



    }


}
