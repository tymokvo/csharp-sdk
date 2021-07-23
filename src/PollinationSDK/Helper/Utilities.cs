using PollinationSDK.Client;
using RestSharp;
using System;
using System.Linq;

namespace PollinationSDK
{
    public static class Utilities
    {
        /// <summary>
        /// Download a translated recipe for luigi
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="recipeName"></param>
        /// <param name="tag"></param>
        /// <returns>zip file path</returns>
        public static string GetCompiledRecipe(string owner, string recipeName, string tag = "latest")
        {
            var request = new RestRequest(Method.GET);
            //https://utilities.staging.pollination.cloud/luigi-archive
            var url = $"{Configuration.Default.BasePath}/luigi-archive".Replace("https://api.", "https://utilities.");

            // add Authorization JWT
            request.AddHeaders(Configuration.Default.DefaultHeader); 

            // add API key
            var apiKey = Configuration.Default.GetApiKeyWithPrefix("x-pollination-token");
            if (!string.IsNullOrEmpty(apiKey))
            {
                request.AddHeader("x-pollination-token", apiKey);
            }
            
            request.AddParameter("owner", owner);
            request.AddParameter("name", recipeName);
            request.AddParameter("tag", tag);

            var client = new RestClient(url);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var e = new ArgumentException($"{(int)response.StatusCode}: Failed to download {recipeName}");
                Helper.Logger.Error(e, $"GetCompiledRecipe: error");
                throw e;
            }

            //{Content-Disposition=attachment; filename=annual-daylight-0.6.4.zip}
            var filename = response.Headers.First(_=>_.Name == "Content-Disposition")?.Value.ToString()?.Split('=')?.LastOrDefault();

            // prep file path
            var saveAsDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Pollination", "Recipes");
            var fileName = string.IsNullOrEmpty(filename)? $"{owner}_{recipeName}_{tag}.zip" : $"{owner}_{filename}";

            System.IO.Directory.CreateDirectory(saveAsDir);
            var file = System.IO.Path.Combine(saveAsDir, fileName);

            var b = response.RawBytes;
            System.IO.File.WriteAllBytes(file, b);
            if (!System.IO.File.Exists(file))
            {
                var e = new ArgumentException($"Failed to save {fileName} to {file}");
                Helper.Logger.Error(e, $"GetCompiledRecipe: error");
                throw e;
            }
            return file;
        }


    }
}
