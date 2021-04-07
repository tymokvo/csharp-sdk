
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

            var savedPath = System.IO.Path.GetTempPath();

            // get the first runInfo from a job
            var runInfo = ScheduledJob.GetRunInfo(0);

            // get all output assets to download
            var outputNames = runInfo.GetOutputAssets();


            // Load run's input arguments data 
            var inputAssetPathes = runInfo.GetInputPathAssets();

            // progress reporter
            Action<string> UpdateProgressMessage = (s) => Console.WriteLine(s);

            // if use cached data
            var useCachedAssets = false;

            // download all assets
            var task = Task<Dictionary<string, string>>.Run(async () => await runInfo.DownloadRunAssetsAsync(inputAssetPathes, outputNames, savedPath, UpdateProgressMessage, useCachedAssets));
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



            // get run's value type input arguments that don't need to download
            var inputValueAssets = runInfo.GetInputValueAssets();
            foreach (var item in inputValueAssets)
            {
                Console.WriteLine($"Asset: {item.Key}\nUser input: {item.Value}");
            }

            Assert.IsTrue(inputValueAssets.Any());

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
