using PollinationSDK.Api;
using PollinationSDK.Client;
//using PollinationSDK.Model;
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
using QueenbeeSDK;


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
            //var rec = recipeApi.GetRecipeByTag(recipeOwner, recipeName, "*").Manifest;
            //Console.WriteLine($"{rec.Source}/{rec.Metadata.Name}/{rec.Metadata.Tag}");


            Console.WriteLine("--------------------Get a project-------------------");
            var proj = Helper.GetAProject(me.Username, "demo");
            Console.WriteLine($"Getting the project. \nFound this project {proj.Name} ID: {proj.Id}");


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
            //var jobInfo = CreateJob_DaylightFactor();
            ////var jobInfo = CreateJob_AnnualDaylight();

            //try
            //{
            //    jobInfo.SetJobSubFolderPath("round1/test");
            //    var task = runSimu(proj, jobInfo, (s) => Console.WriteLine(s), token);
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


            Console.WriteLine("--------------------get simulation assets-------------------");
            var runApi = new PollinationSDK.Api.RunsApi();
            var run = runApi.GetRun(proj.Owner.Name, proj.Name, "229b7d27-292d-45f8-a06b-da07083d798b");
            var inputArgs = run.Status.Inputs;
            foreach (var item in inputArgs)
            {
                var obj = item.Obj;
                var objType = obj.GetType();
                var name = objType.GetProperty("Name").GetValue(obj);
                var value = objType.GetProperty("Value")?.GetValue(obj);
                if (value == null)
                {
                    var path = objType.GetProperty("Path")?.GetValue(obj).ToString();
                    var url = runApi.DownloadRunArtifact(proj.Owner.Name, proj.Name, run.Id, path);
                    value = url;
                    //Console.WriteLine(url);
                }
                Console.WriteLine($"{name}: {value}");
          

            }
          
            //var output2 = runApi.ListRunArtifacts(proj.Owner.Name, proj.Name, run.Id, path: new List<string>() { "inputs"});

            //foreach (var item in output2)
            //{
            //    Console.WriteLine($"{item.FileName}");
            //    var url = runApi.DownloadRunArtifact(proj.Owner.Name, proj.Name, run.Id, item.Key).ToString();
            //    Console.WriteLine(url);
            //}
            Console.WriteLine("Done downloading");



            //Console.WriteLine("--------------------Download simulation output-------------------");
            //var runInfo = new RunInfo(proj, "a211fd95-2830-411a-a4e9-35e4ccbe4eab");
            //DownloadOutputs(runInfo, new List<string> { "results" });
            //Console.WriteLine("Done downloading");


            //Console.WriteLine("--------------------Download simulation log-------------------");
            ////@"C:\\Users\\mingo\\AppData\\Local\\Temp\\Pollination\\9936f815-25f1-40b8-a298-71091dd6b71a\\re4veore.tvs\\logs.tgz"
            //var rapi = new RunsApi();
            //var run = rapi.GetRun("mingbo","demo", "941e9e52-4f98-4dd8-87b9-16129bc38c47");
            //var simu = rapi.GetRunSteps("mingbo", "demo", "941e9e52-4f98-4dd8-87b9-16129bc38c47").Resources;
            ////var simuLog = simu.GetSimulationOutputLogAsync(Console.WriteLine).Result;

            //Console.WriteLine("Done downloading");
            ////Console.WriteLine(simuLog);
            //var entryID = run.Status.Entrypoint;
            //var log = rapi.GetRunStepLogs("mingbo", "demo", "941e9e52-4f98-4dd8-87b9-16129bc38c47", entryID);



            Console.ReadKey();

        }

       
        private static async Task<RunInfo> runSimu(Project proj, JobInfo job, Action<string> msgAction, CancellationToken token)
        {
            try
            {
                var runInfo = await job.RunJobOnCloud(proj, msgAction, token);
                msgAction($"Starting the job: {runInfo.RunID}");
                await runInfo.WatchRunStatusAsync(msgAction, token);

                //msgAction(runInfo.Logs);

                if (!token.IsCancellationRequested)
                {
                    msgAction($"Finished the job: {runInfo.RunID}");
                }

                msgAction($"Canceled by user: {token.IsCancellationRequested}");
                return runInfo;

            }
            catch (Exception e)
            {

                throw e;
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

            var rec = api.GetRecipeByTag("ladybug-tools", "annual-energy-use", "latest").Manifest;
            //var recTag = api.GetRecipeByTag("ladybug-tools", "annual-energy-use", "c2657adb0b13db6cd3ff706d9d6db59b98ef8f994d2809d23c3ed449c19b52ea");
       
            var inputs = rec.Inputs.OfType<QueenbeeSDK.GenericInput>();
            var ParamNames = inputs.Select(_ => _.Name);
            Console.WriteLine("------------------Getting Recipe Input Params---------------------");
            Console.WriteLine(string.Join("\n", ParamNames));

        }

        private static JobInfo CreateJob_AnnualDaylight()
        {
            var recipeOwner = "ladybug-tools";
            var recipeName = "annual-daylight";
            var recipeApi = new RecipesApi();
            var rec = recipeApi.GetRecipeByTag(recipeOwner, recipeName, "latest").Manifest;

            var jobInfo = new JobInfo(rec);

            //job.AddArgument(new JobArgument("sensor-grids", "[\"room\"]"));
            jobInfo.AddArgument(new JobPathArgument("model", new ProjectFolder(path: @"D:\Test\queenbeeTest\two_rooms.hbjson")));
            jobInfo.AddArgument(new JobPathArgument("wea", new ProjectFolder(path: @"D:\Test\queenbeeTest\golden_co.wea")));

            return jobInfo;

        }

        private static JobInfo CreateJob_DaylightFactor()
        {
          

            var recipeOwner = "ladybug-tools";
            var recipeName = "daylight-factor";
            var recipeApi = new RecipesApi();
            var rec = recipeApi.GetRecipeByTag(recipeOwner, recipeName, "latest").Manifest;

            var jobInfo = new JobInfo(rec);

            jobInfo.AddArgument(new JobPathArgument("model", new ProjectFolder(path: @"D:\Test\queenbeeTest\model.hbjson")));
            //job.AddArgument(new JobPathArgument("input", new ProjectFolder(path: @"D:\Test\queenbeeTest\inputs.json")));


            return jobInfo;

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
            var api = new RunsApi();
            var run = api.GetRun(proj.Owner.Name, proj.Name, simuId);

            var status = run.Status;
            var startTime = status.StartedAt.ToUniversalTime();
            while (status.Status == "Running")
            {

                await Task.Delay(1000);
                var runseconds = Math.Round((DateTime.UtcNow - startTime).TotalSeconds);
                Console.WriteLine($"{status.Status}: [{runseconds} s]");

                // update status
                status = api.GetRun(proj.Owner.Name, proj.Name, simuId).Status;

            }

            var totalSeconds = Math.Round((DateTime.UtcNow - startTime).TotalSeconds);
            Console.WriteLine($"{status.Status}: [{totalSeconds} s]");

            return true;
        }

        private static void CheckOutputLogs(Project proj, string simuId)
        {
            var api = new RunsApi();
      
            var steps = api.GetRunSteps(proj.Owner.Name, proj.Name, simuId.ToString());
            foreach (var item in steps.Resources)
            {
                var stepLog = api.GetRunStepLogs(proj.Owner.Name, proj.Name, simuId.ToString(), item.Id);
                Console.WriteLine(stepLog);
            }
           
        }

        //private async static void DownloadOutputs(RunInfo runInfo, List<string> outputNames)
        //{
        //    //var run = new Simulation(proj, simuId);
        //    var simuStatus = new PollinationSDK.Api.RunsApi().GetRun(runInfo.Project.Owner.Name, runInfo.Project.Name, runInfo.RunID).Status;

        //    var filePaths = await runInfo.DownloadOutputArtifactsAsync(outputNames);


        //}



    }


}
