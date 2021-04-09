
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
            var outputAssets = runInfo.GetOutputAssets(platform:"");

            // Load run's input assets to download
            var inputAssets = runInfo.GetInputAssets();
            var inputPathAssets = inputAssets.Where(_ => _.IsDownloadable());
            Assert.IsTrue(inputPathAssets.Any());


            var assets = new List<RunAssetBase>();
            assets.AddRange(outputAssets);
            assets.AddRange(inputPathAssets);

            // progress reporter
            Action<string> UpdateProgressMessage = (s) => Console.WriteLine(s);

            // if use cached data
            var useCachedAssets = false;

            // download all assets
            var task = Task.Run(async () => await runInfo.DownloadRunAssetsAsync(assets, savedPath, UpdateProgressMessage, useCachedAssets));
            task.Wait();

            //await Task.Delay(3000);
            if (task.IsFaulted && task.Exception != null)
                throw task.Exception;

         
            var filePaths = task.Result;

            foreach (var item in filePaths)
            {
                Console.WriteLine($"Asset: {item.Name}\nSaved Path: {item.LocalPath}");
                if (Directory.Exists(item.LocalPath))
                {
                    var files = Directory.GetFiles(item.LocalPath);
                    Assert.IsTrue(files.Any());
                }

            }

            Assert.IsTrue(filePaths.Any());



            // get run's value type input arguments that don't need to download
            var inputValueAssets = inputAssets.Where(_ => !_.IsDownloadable());
            foreach (var item in inputValueAssets)
            {
                Console.WriteLine($"Asset: {item.Name}\nUser input: {item.Value}");
            }

            // ISSUE: https://github.com/pollination/pollination-server/issues/146
            //Assert.IsTrue(inputValueAssets.Any());

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


        /// <summary>
        /// Test DownloadAssetTest
        /// </summary>
        [Test]
        public void DownloadAssetTest()
        {
            var instance = new ProjectsApi();
            var proj = instance.GetProject(Helper.CurrentUser.Username, "demo");


            var response = api.ListJobs(Helper.CurrentUser.Username, "demo");
            var objs = response.Resources;

            foreach (var item in objs)
            {
                Console.WriteLine($"CloudJob: {item.Id}");
            }

            var runApi = new Api.RunsApi();
            var runs = runApi.ListRuns(Helper.CurrentUser.Username, "demo", jobId: new List<string>(){ objs.First().Id }).Resources;
            var run = runs[0];

            var runInfo = new RunInfo(proj, run);


            var assets = runInfo.GetOutputAssets("grasshopper").OfType<RunAssetBase>().ToList();
            var inputs = runInfo.GetInputAssets();
            assets.AddRange(inputs);

            var task = runInfo.DownloadRunAssetsAsync(assets, useCached: true);
            var downloaded = task.Result;
            foreach (var item in downloaded)
            {
                if (item.IsDownloadable())
                {
                    Console.WriteLine($"Is Saved {item.Name}:{item.IsSaved()} to {item.LocalPath}");
                    Assert.IsTrue(item.IsSaved());
                }
                else
                {
                    var v = string.Join(",", item.Value);
                    Console.WriteLine($"Value {item.Name}: {v}");
                    Assert.IsTrue(!string.IsNullOrEmpty(v));
                }
            }

        }

        [Test]
        public void RunInputsTest()
        {
            var response = api.ListJobs(Helper.CurrentUser.Username, "demo");
            var jobs = response.Resources;

       
            var runApi = new Api.RunsApi();

            foreach (var job in jobs)
            {
                var jobId = job.Id;
                var run = runApi.ListRuns(Helper.CurrentUser.Username, "demo", jobId: new List<string>() { jobId }).Resources[0];
                var inputs = run.Recipe.Inputs.OfType<Interface.Io.Inputs.IDag>();
                var inputs2 = run.Status.Inputs.OfType<Interface.Io.Inputs.IStep>();

                var sameInputs = inputs.Count() == inputs2.Count();
                if (!sameInputs)
                {
                    Console.WriteLine($"{Helper.CurrentUser.Username}/demo/{jobId}/{run.Id}");

                    Console.WriteLine($"================Run Recipe Inputs=====================");


                    foreach (var item in inputs)
                    {
                        Console.WriteLine($"{item.Name}");
                    }



                    Console.WriteLine($"================Run Status Inputs=====================");
                    foreach (var item in inputs2)
                    {
                        var v = item.IsValueType() ? string.Join(",", item.GetInputValue()) : item.GetInputPath();
                        Console.WriteLine($"{item.Name}: {v}");
                    }
                }

                Assert.IsTrue(sameInputs);

            }


       

        }
    }

}
