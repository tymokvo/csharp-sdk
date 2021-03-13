
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PollinationSDK.Api;
using PollinationSDK.Wrapper;
using System.Threading.Tasks;

namespace PollinationSDK.Test
{
    [TestFixture]
    public class JobsApiTests
    {
        private JobsApi api;
        private string NewProject = $"{Guid.NewGuid().ToString().Substring(0, 8)}";
        private Project Project;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            api = new JobsApi();
            Project = CreateProject(NewProject);
           
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [OneTimeTearDown]
        public void Cleanup()
        {
            DeleteProject(NewProject);
        }

        
        public Project CreateProject(string projName)
        {
            var instance = new ProjectsApi();
            var projs = instance.ListProjects(owner: new List<string>() { Helper.CurrentUser.Username }).Resources;
            var found = projs.FirstOrDefault(_ => _.Name == this.NewProject);

            var owner = Helper.CurrentUser.Username;
            var projectCreate = new ProjectCreate(projName);
            var response = instance.CreateProject(owner, projectCreate);
            var proj = instance.GetProject(owner, projName);
            return proj;
        }

        public void DeleteProject(string projName)
        {
            var instance = new ProjectsApi();
            var owner = Helper.CurrentUser.Username;
            instance.DeleteProject(owner, projName);
        }


        ScheduledJobInfo ScheduledJob;
        [Test, Order(1)]
        public void CreateJobTest()
        {
            var recipeOwner = "ladybug-tools";
            var recipeName = "daylight-factor";
            var recipeApi = new RecipesApi();
            var rec = recipeApi.GetRecipeByTag(recipeOwner, recipeName, "latest").Manifest;

            var jobInfo = new JobInfo(rec);

            jobInfo.AddArgument(new JobPathArgument("model", new ProjectFolder(path: @"../../../TestSample/two_rooms.hbjson")));

            jobInfo.SetJobSubFolderPath("round1/test");
            jobInfo.SetJobName("A new daylight simulation");

            // run a job
            var task = jobInfo.RunJobOnCloud(Project, (s) => Console.WriteLine(s));

            //cts.CancelAfter(60000);
            ScheduledJob = task.Result;

            Assert.IsTrue(!string.IsNullOrEmpty(ScheduledJob.CloudJob.Id));

        }

        [Test, Order(2)]
        public void WatchJobTest()
        {
            // watch status
            var watchTask = this.ScheduledJob.WatchJobStatusAsync((s) => Console.WriteLine(s));
            watchTask.Wait();
            var result = watchTask.Result;

            Assert.IsTrue(result.Contains("Completed"));
        }


        [Test, Order(3)]
        public void CheckJobResultTest()
        {
            var runApi = new PollinationSDK.Api.RunsApi();
            var proj = this.Project;

            var firstRun = runApi.ListRuns(proj.Owner.Name, proj.Name, page: 1, perPage: 1).Resources.First();
            var runInfo = new RunInfo(proj, firstRun);

            // get all output assets to download
            var outputNames = runInfo.Recipe.Outputs
                .OfType<PollinationSDK.Interface.Io.Outputs.IDag>()
                .Select(_ => _.Name).ToList();

            var savedPath = System.IO.Path.GetTempPath();

            // Load run's input arguments data // Don't download inputs for now
            var inputAssetPathes =  new Dictionary<string, string>();

            // download run's output assets
            var outputAssetNames = outputNames ?? new List<string>();

            // progress reporter
            Action<string> UpdateProgressMessage = (s) => Console.WriteLine(s);

            // if use cached data
            var useCachedAssets = false;

            // download all assets
            var task = Task<Dictionary<string, string>>.Run(async () => await runInfo.DownloadRunAssetsAsync(inputAssetPathes, outputAssetNames, savedPath, UpdateProgressMessage, useCachedAssets));
            task.Wait();

            //await Task.Delay(3000);
            if (task.IsFaulted && task.Exception != null)
                throw task.Exception;

         
            var filePaths = task.Result;

            foreach (var item in filePaths)
            {
                Console.WriteLine($"Asset: {item.Key}\nSaved Path: {item.Value}");
                if (Directory.Exists(item.Value))
                {
                    var files = Directory.GetFiles(item.Value);
                    Assert.IsTrue(files.Any());
                }

            }

            Assert.IsTrue(filePaths.Any());
        }

        /// <summary>
        /// Test ListProjects
        /// </summary>
        [Test]
        public void ListJobsTest()
        {
            var response = api.ListJobs(Helper.CurrentUser.Username, "demo");
            var objs = response.Resources;

            foreach (var item in objs)
            {
                Console.WriteLine($"CloudJob: {item.Id}");
            }
            Assert.IsTrue(objs.Count > 1);

        }
        
        
    }

}
