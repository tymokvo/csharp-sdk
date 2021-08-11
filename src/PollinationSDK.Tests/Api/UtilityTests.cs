using NUnit.Framework;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Wrapper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PollinationSDK.Test
{
    [TestFixture]
    public class UtilityTests
    {
        [Test]
        public void DownloadRecipeTest()
        {
            //public recipe
            var zipfile = Utilities.GetCompiledRecipe("ladybug-tools", "annual-daylight", "latest");
            Assert.IsTrue(System.IO.File.Exists(zipfile));

            //private recipe
            var privatefile = Utilities.GetCompiledRecipe("pollination", "leed-daylight-illuminance", "latest");
            Assert.IsTrue(System.IO.File.Exists(privatefile));
        }

        [Test]
        public void GetLocalRecipeTest()
        {
            var recipeOwner = "ladybug-tools";
            var recipeName = "annual-daylight";
            var recipeApi = new RecipesApi();
            var rec = recipeApi.GetRecipeByTag(recipeOwner, recipeName, "latest").Manifest;

            //public recipe
            var recipeFolder = Utilities.GetLocalRecipe(recipeOwner, recipeName, rec.Metadata.Tag);
            Assert.IsTrue(System.IO.Directory.GetFiles(recipeFolder).Any());
        }

        [Test]
        public void RunLocalTest()
        {

            var recipeOwner = "ladybug-tools";
            var recipeName = "daylight-factor";
            var recipeApi = new RecipesApi();
            var rec = recipeApi.GetRecipeByTag(recipeOwner, recipeName, "latest").Manifest;

            var jobInfo = new JobInfo(rec);

            var model = Path.GetFullPath(@"../../../TestSample/two_rooms.hbjson");
            if (!File.Exists(model))
                throw new ArgumentException("Input doesn't exist");
            jobInfo.AddArgument(new JobPathArgument("model", new ProjectFolder(path: model)));

            jobInfo.SetJobSubFolderPath("round1/test");
            jobInfo.SetJobName("A new daylight simulation");


            // run a job
            var path = @"C:\Users\mingo\simulation";
            var lbt = @"C:\Users\mingo\ladybug_tools";
            Utilities.SetPaths(lbt);
            var job = jobInfo.RunJobOnLocal(path, 5);


            //Assert.IsTrue(!string.IsNullOrEmpty(ScheduledJob.CloudJob.Id));


        }

      

    }

}
