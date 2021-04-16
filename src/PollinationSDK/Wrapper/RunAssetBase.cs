
using Newtonsoft.Json;
using PollinationSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PollinationSDK.Wrapper
{
    public abstract class RunAssetBase
    {
        [JsonProperty]
        public string Name { get; protected set; }

        [JsonProperty]
        public string Description { get; protected set; }

        [JsonProperty]
        /// <summary>
        /// This is valid only if the asset is non-path type: string, int, double, etc
        /// </summary>
        public List<object> Value { get; protected set; }

        [JsonProperty]
        /// <summary>
        /// Original Run source for redownloading the asset. Formated as CLOUD:mingbo/demo/1D725BD1-44E1-4C3C-85D6-4D98F558DE7C
        /// </summary>
        public string CloudRunSource { get; protected set; }

        [JsonProperty]
        /// <summary>
        /// For input asset: a relative path to the cloud project root that this asset belongs to.
        /// For output asset: same as asset name
        /// </summary>
        public string CloudPath { get; protected set; }

        [JsonProperty]
        public string LocalPath { get; set; }

        /// <summary>
        /// Load the content of from LacalPath,
        /// This property is not serialize-able and will not be duplicated.
        /// </summary>
        public object PreloadedPath { get; set; }

        public bool IsInputAsset => this is RunInputAsset;

        public abstract RunAssetBase Duplicate();

        /// <summary>
        /// Check if a path type asset saved to local drive (LocalPath).
        /// </summary>
        /// <returns></returns>
        public bool IsSaved()
        {
            var path = this.LocalPath;
            if (string.IsNullOrEmpty(path))
                return false;

            var attr = File.GetAttributes(path);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                return Directory.Exists(path);
            else
                return File.Exists(path);
        }

        /// <summary>
        /// Check if this asset is value type or path type asset. If it is path type, then check if its CloudRunSource is valid.
        /// Lastly, if it is an input asset, check if CloudPath is valid.
        /// </summary>
        /// <returns></returns>
        public bool IsDownloadable()
        {
            if (this.Value != null && this.Value.Any())
                return false;

            if (string.IsNullOrEmpty(CloudRunSource))
                return false;

            if (this.IsInputAsset)
                return !string.IsNullOrEmpty(CloudPath);
            else
                return true;

        }
  
        internal bool CheckIfAssetCached(string dir)
        {
            var assetName = this.Name;
         

            var assetDir = Path.Combine(dir, assetName);
            if (!Directory.Exists(assetDir))
                return false;

            // check if folder is empty
            var cached = Directory.EnumerateFileSystemEntries(assetDir, "*", SearchOption.TopDirectoryOnly).ToList();
            if (!cached.Any())
                return false;

            if (this.IsInputAsset)
            {
                var assetPath = this.CloudPath;
                // folder asset is a zip file, assetDir has all unzipped files
                if (assetPath.EndsWith(".zip"))
                    return true;
                else // file asset
                    return File.Exists(Path.Combine(assetDir, Path.GetFileName(assetPath)));
            }

            return true;

        }

        internal string GetCachedAsset(string dir)
        {
            var assetName = this.Name;
            var assetPath = this.CloudPath;


            var cachedPath = string.Empty;
            var assetDir = Path.Combine(dir, assetName);

            if (this.IsInputAsset)
            {
                // folder asset is a zip file 
                if (assetPath.EndsWith(".zip"))
                {
                    // assetDir has all unzipped files
                    cachedPath = assetDir;
                }
                else // file asset
                {
                    var assetFile = Path.Combine(assetDir, Path.GetFileName(assetPath));
                    if (File.Exists(assetFile))
                        cachedPath = assetFile;
                }
            }
            else
            {
                cachedPath = assetDir;
            }
          
            return cachedPath;
        }


        public override string ToString()
        {
            if (this.Value != null && this.Value.Any())
                return base.ToString();

            var v = $"{CloudRunSource}/{Name}";

            if (this is RunOutputAsset outputAsset)
            {
                v = $"{v}#{outputAsset.AliasName}";
            }
            return v;
        }



        public Run GetRun()
        {
            string[] items = CheckRunSource();
            var source = new { owner = items[0], proj = items[1], runId = items[2] };

            var api = new Api.RunsApi();
            var run = api.GetRun(source.owner, source.proj, source.runId);
            //run.Status.JobId
            return run;
        }

        private string[] CheckRunSource()
        {
            //CLOUD:mingbo/demo/1D725BD1-44E1-4C3C-85D6-4D98F558DE7C
            var runID = this.CloudRunSource;
            if (string.IsNullOrEmpty(runID))
                throw new ArgumentException($"Not valid cloud run source");
            if (runID.StartsWith("CLOUD:"))
                runID = runID.Substring(6);

            var items = runID.Split('/');
            return items;
        }

        public Project GetRoject()
        {
            string[] items = CheckRunSource();
            var source = new { owner = items[0], proj = items[1], runId = items[2] };

            var api = new Api.ProjectsApi();
            var proj = api.GetProject(source.owner, source.proj);
       
            return proj;
        }

        public RunInfo GetRunInfo()
        {
            var run = GetRun();
            var proj = GetRoject();
      
            var runInfo = new RunInfo(proj, run);
            return runInfo;
        }


        public virtual object CheckOutputWithHandler(object inputData, HandlerChecker handlerChecker)
        {
            return inputData;
        }

    }

}
