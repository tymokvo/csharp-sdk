using NUnit.Framework;
using PollinationSDK.Api;
using PollinationSDK.Client;
using RestSharp;
using System.Collections.Generic;

namespace PollinationSDK.Test
{
    [TestFixture]
    public class UtilityTests
    {
        [Test]
        public void IsLadybugTest()
        {
            //public recipe
            var zipfile = Utilities.GetCompiledRecipe("ladybug-tools", "annual-daylight", "latest");
            Assert.IsTrue(System.IO.File.Exists(zipfile));

            //private recipe
            var privatefile = Utilities.GetCompiledRecipe("pollination", "leed-daylight-illuminance", "latest");
            Assert.IsTrue(System.IO.File.Exists(privatefile));
        }

        //[Test]
        //public void IsLadybugTest()
        //{
            

        //    //var signTask = AuthHelper.SignInAsync(devEnv: true);
        //    //signTask.Wait();
        //    //var config = Configuration.Default;

        //    //var url = "https://utilities.pollination.cloud/to-luigi-archive";
        //    //var url2 = "https://utilities.staging.pollination.cloud/luigi-archive";
        //    //var url3 = "https://utilities.staging.pollination.cloud/luigi-archive?owner=ladybug-tools&name=annual-daylight&tag=latest";


        //    var request = new RestRequest(Method.GET);
        //    var url = $"{Configuration.Default.BasePath}/luigi-archive";
     
        //    //request.AddParameter("owner", "ladybug-tools");
        //    //request.AddParameter("name", "annual-daylight");
        //    request.AddParameter("owner", "pollination");
        //    request.AddParameter("name", "leed-daylight-illuminance");
        //    request.AddParameter("tag", "latest");
            
        //    var client = new RestClient(url.ToString());
        //    var response = client.Execute(request);
        //    if (response.StatusCode != System.Net.HttpStatusCode.OK)
        //    {
              
        //    }


        //    // prep file path
        //    var saveAsDir = System.IO.Path.GetTempPath();
        //    var fileName = "annual-daylight.zip";

        //    System.IO.Directory.CreateDirectory(saveAsDir);
        //    var file = System.IO.Path.Combine(saveAsDir, fileName);

        //    var b = response.RawBytes;
        //    System.IO.File.WriteAllBytes(file, b);

        //    Assert.IsTrue(System.IO.File.Exists(file));
        //    if (!System.IO.File.Exists(file))
        //    {
        //        //var e = new ArgumentException($"Failed to download {fileName}");
        //        //Helper.Logger.Error(e, $"DownloadFromUrlAsync: error");
        //        //throw e;
                
        //    }

        //}



    }

}
