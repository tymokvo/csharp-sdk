
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

        public bool IsInputAsset => this is RunInputAsset;

        public abstract RunAssetBase Duplicate();

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
  
        public bool CheckIfAssetCached(string dir)
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

        public string GetCachedAsset(string dir)
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

    }

}
