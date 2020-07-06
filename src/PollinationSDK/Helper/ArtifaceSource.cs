using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollinationSDK
{

    public class ArtifaceSourcePath
    {
        //public enum SourceType
        //{
        //    http,
        //    s3,
        //    "project-folder"
        //}
        public string type => "project-folder";
        public string path { get; set; }
        public ArtifaceSourcePath(string relativePath)
        {
            // "type": "project-folder";
            // "path": "project_folder/asset/grid/room.pts"
            //this.type = type;
            this.path = "project_folder/" + relativePath.Replace('\\', '/');
        }

        public string ToJson() => JsonConvert.SerializeObject(this);

        public override string ToString() => ToJson();
    }


}
