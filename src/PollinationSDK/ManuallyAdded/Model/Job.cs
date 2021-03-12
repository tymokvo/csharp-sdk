using System.Linq;
using System.Collections.Generic;

namespace PollinationSDK
{
    public partial class Job
    {
        public void AddArgumentSet(List<AnyOf<JobArgument, JobPathArgument>> arg = default)
        {
            this.Arguments = Arguments ?? new List<List<AnyOf<JobArgument, JobPathArgument>>>();
            var argSet = arg ?? new List<AnyOf<JobArgument, JobPathArgument>>();
            this.Arguments.Add(argSet);
        }
        public void AddArgument(JobArgument arg)
        {
            this.Arguments = Arguments ?? new List<List<AnyOf<JobArgument, JobPathArgument>>>();
            var argSet = this.Arguments.LastOrDefault();
            if (argSet == null)
            {
                argSet = new List<AnyOf<JobArgument, JobPathArgument>>();
                this.Arguments.Add(argSet);
            }

            var existing = argSet.OfType<JobArgument>().FirstOrDefault(_ => _.Name == arg.Name);
            if (existing == null)
                argSet.Add(arg);
            else
                existing.Value = arg.Value;

        }
        public void AddArgument(JobPathArgument arg)
        {
            this.Arguments = Arguments ?? new List<List<AnyOf<JobArgument, JobPathArgument>>>();
            var argSet = this.Arguments.LastOrDefault();
            if (argSet == null)
            {
                argSet = new List<AnyOf<JobArgument, JobPathArgument>>();
                this.Arguments.Add(argSet);
            }
           
            var existing = argSet.OfType<JobPathArgument>().FirstOrDefault(_ => _.Name == arg.Name);
            if (existing == null)
                argSet.Add(arg);
            else
                existing.Source = arg.Source;

        }
    }
}