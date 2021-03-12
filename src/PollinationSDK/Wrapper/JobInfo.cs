using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PollinationSDK.Wrapper
{
    public class JobInfo
    {
        public RecipeInterface Recipe { get; private set; }
        public Job Job { get; private set; }
        public string SubFolderPath { get; private set; }


        public JobInfo(RecipeInterface recpie)
        {
            //this.ProjectName = projName;
            this.Recipe = recpie;

            this.Job = new Job(recpie.Source);
            this.Job.Arguments = new List<List<AnyOf<JobArgument, JobPathArgument>>>();
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

        //public RunInfo RunJobOnLocal(int cpuNum = 2)
        //{
        //    var runner = new JobRunner(this);
        //    var projPath = runner.RunOnLocalMachine(cpuNum);
        //    return new RunInfo(projPath);
        //}
        public async Task<ScheduledJobInfo> RunJobOnCloud(Project proj, Action<string> progressReporting = default, System.Threading.CancellationToken token = default)
        {
            var runner = new JobRunner(this);
            var cloudJob =  await runner.RunOnCloudAsync(proj, progressReporting, token);
            return new ScheduledJobInfo(proj, cloudJob);


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

        public void SetJobKeywords(List<string> keywords)
        {
            if (keywords == null) return;
            this.Job.Labels = new Dictionary<string, string>() { { "keywords", string.Join(",", keywords) } };
        }
        public void SetJobDescription(string description)
        {
            this.Job.Description = description;
        }


    }
}
