using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using PollinationSDK;

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

            var runTask = SignIn();
            runTask.Wait();
            var me = Helper.CurrentUser;
            Console.WriteLine($"You are: {me.Username}");


            Console.WriteLine("--------------------Get a project-------------------");
            var proj = Helper.GetAProject(me, "My new project93659");
            Console.WriteLine($"Getting the project. \n Found this project ID: {proj.Id}");


            //Console.WriteLine("--------------------UploadArtifaces-------------------");
            //var dir = @"C:\Users\mingo\Downloads\Compressed\project_folder\project_folder";
            //UploadDirectory(proj, dir);

            //Console.WriteLine("--------------------Getting Recipe Params-------------------");
            //GetRecipeParameters();


            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine("Creating a project");
            //var proj = CreateAProject(me);

            //Console.WriteLine("--------------------Upload a directory-------------------");
            //var dir = @"C:\Users\mingo\Downloads\Compressed\project_folder\project_folder";
            ////var project = new ProjectDto()
            //UploadDirectory(proj, dir);


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
            //CreateSimulation(proj);

            Console.WriteLine("--------------------Simulation status-------------------");
            var id = "f13b6c0d-7c42-420a-884c-f6010e954b8b";
            //CheckSimulationStatus(proj, id);
            CheckOutputLogs(proj, id);



            Console.ReadKey();

        }


        private static async Task<bool> SignIn()
        {
            //OutputMessage = string.Empty;

            var token = await AuthHelper.SignIn();


            //var config = new Configuration();
            //config.AccessToken = token;
            //config.BasePath = "https://api.pollination.cloud/";
            //config.AddDefaultHeader("Bearer", token);


            //Configuration.Default.AccessToken = token;
            Configuration.Default.BasePath = "https://api.pollination.cloud/";
            //Configuration.Default.AddDefaultHeader("Bearer", token);
            Configuration.Default.AddDefaultHeader("Authorization", $"Bearer {token}");
            Helper.CurrentUser = Helper.GetUser();

            return true;

        }
        //private static PrivateUserDto GetUser()
        //{
        //    var api = new UserApi();
        //    //var config = api.Configuration;
        //    var me = api.GetMe();
        //    return me;
        //}

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
            var d = api.ListRecipes(owner: new[]{ "ladybug-tools" }.ToList()).Resources.First(_ => _.Name == "daylight-factor");

            
            var recTag = api.GetRecipeByTag(d.Owner.Name, d.Name, d.LatestTag);
            //TODO: ask Antoine to fix why Manifest returns Recipe 
            var mani = recTag.Manifest;
            //TODO: ask Antoine to fix why Flow returns DAG 
            var flow = mani.Flow.First();
            var inputs = flow.Inputs;
            var ParamNames = inputs.Parameters.Select(_=>_.Name);
            Console.WriteLine("------------------Getting Recipe Input Params---------------------");
            Console.WriteLine(string.Join("\n", ParamNames));

            var artifactNames = inputs.Artifacts.Select(_ => _.Name);
            Console.WriteLine("------------------Getting Recipe Input artifacts---------------------");
            Console.WriteLine(string.Join("\n", artifactNames));

            //return inputs.ToString();
            //return recipes;
        }

        private static void CreateSimulation(ProjectDto project)
        {
            // Get project
            var proj = project;


            //Recipe
            var recipeApi = new RecipesApi();
            // why Recipe returns repository
            RepositoryAbridgedDto recipe = recipeApi.ListRecipes(owner: new []{ "ladybug-tools" }.ToList(), _public: true).Resources.First(_ => _.Name == "daylight-factor");


            // create a recipeSelection
            var rec = new RecipeSelection(recipe.Owner.Name, recipe.Name);

            // Upload artifacts
            var dir = @"C:\Users\mingo\Downloads\Compressed\project_folder\project_folder";
            //UploadDirectory(proj, dir);

            // create a recipe argument
            var arg = new Arguments()
            {
                Parameters = new List<ArgumentParameter>()
                {
                    new ArgumentParameter("radiance-parameters", "-I -ab 1 -h"),
                    new ArgumentParameter("sensor-grid-count", "10")
                },
                Artifacts = new List<ArgumentArtifact>()
                {
                    new ArgumentArtifact("input-grid", new ArtifaceSourcePath("model/grid/room.pts")),
                    new ArgumentArtifact("model", new ArtifaceSourcePath("model/"))
                }
            };

            Console.WriteLine("-------------------Arguments:-------------------------");
            Console.WriteLine(arg.ToJson());


            // create a new Simulation
            var api = new SimulationsApi();
            var simu = new SubmitSimulationDto(rec, arg);

            var ret = api.CreateSimulation(proj.Owner.Name, proj.Name, simu);
            Console.WriteLine(ret.Id);
            Console.WriteLine(ret.Message);


            // check simulation status
            var done = CheckSimulationStatus(proj, ret.Id.ToString()).Result;

            var outputs = api.GetSimulationLogs(proj.Owner.Name, proj.Name, ret.Id.ToString());

            //return recipes;
        }


        //private static ProjectDto GetAProject(PrivateUserDto user, string projectName)
        //{
        //    var api = new ProjectsApi();

        //    var d = api.GetProject(user.Username, projectName);
        //    //var d = GetProjects(user).FirstOrDefault(_ => _.Name == projectName);
        //    return d;
        //}

        private static IEnumerable<ProjectDto> GetProjects(PrivateUserDto user)
        {
            var api = new ProjectsApi();
            var d = api.ListProjects(_public: true, owner: new List<string>() { user.Username});
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

        private static async void UploadDirectory(ProjectDto project , string directory)
        {
            var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            var tasks = files.Select(_ =>  Helper.UploadArtifaceAsync(project, _, _.Replace(directory, ""))).ToList();

            while (tasks.Count() >0)
            {
                var finishedTask = await Task.WhenAny(tasks);
                //Console.WriteLine("done!");
                tasks.Remove(finishedTask);

            }
            //await Task.WaitAll(tasks.ToArray());

            //var item = files.First();
            //UploadArtiface(project, item, item.Replace(directory, ""));

            //var tasks = new List<Task>();
            //var ts = files.Select(_ => new Task( ()=> UploadArtiface(project, _, _.Replace(directory, "")))).ToArray();
            //Task.WaitAll(ts);
            //Console.WriteLine("Finished uploading directory");

            //var tasks = files.AsParallel().Select(_ => UploadArtifaceAsync(project, _, _.Replace(directory, "")));

            //foreach (var item in files)
            //{
            //    var relativePath = item.Replace(directory, "");
            //    var t  = UploadArtifaceAsync(project, item, relativePath);
            //    //tasks.Add(t);
            //    //if (t.IsCompleted && t.Result)
            //    //{
            //    //    Console.WriteLine($"Done with {relativePath}");
            //    //}
            //    //var t = new Task(UploadArtiface(projectName, item, item.Replace(directory, "")))
            //    //var t = UploadArtiface(projectName, item, item.Replace(directory, ""));

            //    //Console.WriteLine(item);
            //    //Console.WriteLine(Path.Combine(directory, "ddddd"));
            //}

            //Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Finished uploading directory");
        }

        //private static HttpClient _client;
        //public static HttpClient Client { 
        //    get {
        //        if (_client == null)
        //            new HttpClient();
        //        return _client;
        //    } 
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullPath">something like: "C:\Users\mingo\Downloads\Compressed\project_folder\project_folder\model\grid\room.pts"</param>
        /// <param name="relativePath">"model\grid\room.pts"</param>
        private static async Task<bool> UploadArtifaceAsync(ProjectDto project, string fullPath, string relativePath)
        {
            var filePath = fullPath;
            var fileRelativePath = "project_folder"+ relativePath.Replace('\\','/');

            var api =new ArtifactsApi();
            var artf = await api.CreateArtifactAsync(project.Owner.Name, project.Name, new KeyRequest(fileRelativePath));

            var url = artf.Url;

            using (var client = new HttpClient())
            {
                var byteArrayContent = new ByteArrayContent(File.ReadAllBytes(filePath));

                var content = new System.Net.Http.MultipartFormDataContent(){
                    { new StringContent(artf.Fields["AWSAccessKeyId"]), "\"AWSAccessKeyId\""},
                     { new StringContent(artf.Fields["policy"]), "\"policy\""},
                      { new StringContent(artf.Fields["signature"]), "\"signature\""},
                       { new StringContent(artf.Fields["key"]), "\"key\""},
                        { byteArrayContent, "\"file\""}
                };
               
                var postResponse = await client.PostAsync(url, content);
                if (postResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine($"Done uploading: {relativePath}");
                    return true;
                }
                return false;
            }


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

        private static void DownloadArtiface()
        {
            var api = new ArtifactsApi();
            //api.

        }



    }

   
}
