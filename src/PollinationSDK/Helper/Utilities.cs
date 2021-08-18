using PollinationSDK.Client;
using RestSharp;
using System;
using System.IO;
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

            if (!request.Parameters.Any())
            {
                var e = new ArgumentException("Please login first for downloading recipes!");
                Helper.Logger.Error(e, $"GetCompiledRecipe: error");
                throw e;
            }

            request.AddParameter("owner", owner);
            request.AddParameter("name", recipeName);
            request.AddParameter("tag", tag);

            var client = new RestClient(url);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var e = new ArgumentException($"HttpCode {(int)response.StatusCode}: Failed to download {recipeName}");
                Helper.Logger.Error(e, $"GetCompiledRecipe: error");
                throw e;
            }

            //{Content-Disposition=attachment; filename=annual-daylight-0.6.4.zip}
            var filename = response.Headers.FirstOrDefault(_ => _.Name.ToLower() == "content-disposition")?.Value?.ToString()?.Split('=')?.LastOrDefault();

            // prep file path
            var saveAsDir = RecipeCacheFolder;
            var fileName = string.IsNullOrEmpty(filename) ? $"{owner}_{recipeName}-{tag}.zip" : $"{owner}_{filename}";

            System.IO.Directory.CreateDirectory(saveAsDir);
            var file = System.IO.Path.Combine(saveAsDir, fileName);
            if (File.Exists(file))
                File.Delete(file);

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

        public static string GetLocalRecipe(string owner, string recipeName, string tag)
        {
            if (tag == "latest")
                throw new ArgumentException("Recipe tag cannot be [latest], please use version number");

            var dir = RecipeCacheFolder;
            var search = $"{owner}_{recipeName}-{tag}";
            var files = Directory.GetFiles(dir, $"*{search}*", SearchOption.TopDirectoryOnly);

            var zipPath = string.Empty;
            // download from server
            if (!files.Any())
                zipPath = GetCompiledRecipe(owner, recipeName, tag);
            else
                zipPath = files.FirstOrDefault();
            // use local cache

            var localRecipe = new FileInfo(zipPath);
            var days = (System.DateTime.UtcNow - localRecipe.CreationTimeUtc).Days;
            if (days > 14) // re-download the recipe
            {
                Helper.Logger.Information("Re-downloading the recipe from server as the local cache has been expired");
                zipPath = GetCompiledRecipe(owner, recipeName, tag);
            }

            if (!File.Exists(zipPath))
            {
                var e = new ArgumentException($"Failed to find {zipPath}");
                Helper.Logger.Error(e, $"GetLocalRecipe: error");
                throw e;
            }
            var unzipTo = Path.Combine(dir, Path.GetFileNameWithoutExtension(zipPath));
            var outputDir = Helper.Unzip(zipPath, unzipTo, false);
            return outputDir;

        }

        public static bool IsMac => System.Environment.OSVersion.Platform == PlatformID.Unix;
        public static string LadybugToolRoot { get; set; }
        public static string PythonRoot { get; set; }
        public static string RecipeCacheFolder
        {
            get { 
                var p = Path.Combine(Path.GetTempPath(), "Pollination", "Recipes");
                Directory.CreateDirectory(p);
                return p;
            }
        }

        //public static string ApplicationRoot => IsMac ?
        //  Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(typeof(Utilities).Assembly.Location))))) :
        //  Path.GetDirectoryName(Path.GetDirectoryName(typeof(Utilities).Assembly.Location));



        public static void SetPaths(string LBTFolder)
        {
            if (!Directory.Exists(LBTFolder))
                throw new ArgumentException($"{LBTFolder} doesn't exist!");
            LadybugToolRoot = LBTFolder;

            PythonRoot = Path.Combine(LadybugToolRoot, "python");
            if (!Directory.Exists(PythonRoot))
                throw new ArgumentException($"{PythonRoot} doesn't exist!");
        }

        public static string GetEnvArgForRadiance()
        {
            var radiance = Path.Combine(LadybugToolRoot, "radiance");
            var radBin = Path.Combine(radiance, "bin");
            var radLib = Path.Combine(radiance, "lib");

            if (Directory.Exists(radBin) && Directory.Exists(radLib))
            {
                var envArg = $" --env PATH=\"{radBin}\"";
                envArg += $" --env RAYPATH=\"{radLib}\"";
                return envArg;
            }
            return string.Empty;

        }


    }
}
