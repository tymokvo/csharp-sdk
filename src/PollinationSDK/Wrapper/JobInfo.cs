using Newtonsoft.Json;
using PollinationSDK.Api;
using QueenbeeSDK;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace PollinationSDK.Wrapper
{
    public class JobInfo
    {
        public RecipeInterface Recipe { get; set; }
        public Job Job { get; set; }
        public string SubFolderPath { get; set; }


        public JobInfo(RecipeInterface recpie)
        {
            //this.ProjectName = projName;
            this.Recipe = recpie;

            this.Job = new Job(recpie.Source);
            this.Job.Arguments = new List<AnyOf<JobArgument, JobPathArgument>>();
        }

       

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static JobInfo FromJson(string json)
        {
            var obj =  JsonConvert.DeserializeObject<JobInfo>(json);
            return obj;
        }

        public JobInfo Duplicate()
        {
            return FromJson(this.ToJson());
        }

        public RunInfo RunJobOnLocal(int cpuNum = 2)
        {
            var runner = new JobRunner(this);
            var projPath = runner.RunOnLocalMachine(cpuNum);
            return new RunInfo(projPath);
        }
        public async Task<RunInfo> RunJobOnCloud(Project proj, Action<string> progressReporting = default, System.Threading.CancellationToken token = default)
        {
            var runner = new JobRunner(this);
            return await runner.RunOnCloudAsync(proj, progressReporting, token);
        }

        public void AddArgument(JobArgument arg) => this.Job.AddArgument(arg);
        public void AddArgument(JobPathArgument arg) => this.Job.AddArgument(arg);

        public void SetJobName(string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            this.Job.Name = name;
        }

        public void SetJobSubFolderPath(string path)
        {
            if (string.IsNullOrEmpty(path)) return;
            path = path.Replace('\\', '/').Replace(' ', '_');
            this.SubFolderPath = path;
        }
    }
}
