using PollinationSDK.Api;
using QueenbeeSDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PollinationSDK.Wrapper
{
    public class JobRunner
    {

        private JobInfo JobInfo { get; set; }
        private RecipeInterface Recipe => JobInfo.Recipe;
        private Job Job => JobInfo.Job;

        public JobRunner(JobInfo job)
        {
            this.JobInfo = job;
        }
       
        public async Task<CloudJob> RunOnCloudAsync(Project project, Action<string> progressReporting, System.Threading.CancellationToken token)
        {
            
            CloudJob cloudJob = null;
            try
            {
                cloudJob = await ScheduleCloudJobAsync(project, this.Job, progressReporting, token);
                progressReporting?.Invoke(cloudJob.Status.Status);
                Helper.Logger.Information( $"RunOnCloudAsync: a new cloud job {cloudJob.Id} is started in project {project.Name}");
            }
            catch (Exception e)
            {
                if (e.Source == "Grasshopper" && e.Message == "Object reference not set to an instance of an object.")
                {
                    // Rhino instance has been closed while there was a running simulation.
                    return null;
                }
                Helper.Logger.Error(e, $"RunOnCloudAsync: error.");
                throw e;
                //this.Message = null;
                //Eto.Forms.MessageBox.Show(e.Message, Eto.Forms.MessageBoxType.Error);

            }

            return cloudJob;

        }

        /// <summary>
        /// Run and monitor the simulation on Pollination
        /// </summary>
        /// <param name="project">Pollination project</param>
        /// <param name="workflow">use </param>
        /// <param name="progressLogAction"></param>
        /// <param name="cancelFunc"></param>
        /// <param name="actionWhenDone"></param>
        /// <returns></returns>
        private async Task<CloudJob> ScheduleCloudJobAsync(
            Project project,
            Job job,
            Action<string> progressLogAction = default,
            CancellationToken cancellationToken = default,
            Action actionWhenDone = default)
        {
            // Get project
            var proj = project;
            //var job = this._Job;

            // Check if recipe can be used in this project
            CheckRecipeInProject(job.Source, proj);

            // Upload artifacts

            // check artifacts 
            var tempProjectDir = CheckArtifacts(job, this.JobInfo.SubFolderPath);

            // upload artifacts
            if (!string.IsNullOrEmpty(tempProjectDir))
            {
                Action<int> updateMessageProgress = (int p) => {
                    progressLogAction?.Invoke($"Preparing: [{p}%]");
                };
                await Helper.UploadDirectoryAsync(proj, tempProjectDir, updateMessageProgress, cancellationToken);
            }

            // suspended by user
            var emptyID = Guid.Empty;
            if (cancellationToken.IsCancellationRequested)
            {
                progressLogAction?.Invoke($"Canceled: {cancellationToken.IsCancellationRequested}");
                Helper.Logger.Information($"ScheduleRunAsync: canceled by user");
                return null;
            }

            // update Artifact to cloud's relative path after uploaded.
            var newJob = UpdateArtifactPath(job, this.JobInfo.SubFolderPath);
            //var json = newJob.ToJson();

            // create a new Simulation
            var api = new JobsApi();
            progressLogAction?.Invoke($"Start running.");
            Helper.Logger.Information($"ScheduleRunAsync: Start running.");
            try
            {
                // schedule a simulation on Pollination.Cloud
                var jobForLog = newJob.DuplicateJob();
                jobForLog.Arguments = jobForLog.Arguments.Take(3).ToList();
                Helper.Logger.Information($"ScheduleRunAsync: Scheduling a job in {proj.Owner.Name}/{proj.Name}");
                Helper.Logger.Information($"ONLY PRINTING OUT THE FIRST THREE ARGUMENTS \n{jobForLog.ToJson()}");
                var runJob = await api.CreateJobAsync(proj.Owner.Name, proj.Name, newJob);
                Helper.Logger.Information($"ScheduleRunAsync: Job scheduled\n{runJob.ToJson()}");
                progressLogAction?.Invoke($"Start running..");

                // give server a moment to start the simulation after it's scheduled.
                await Task.Delay(500);

                // monitoring the running simulation
                progressLogAction?.Invoke($"Start running...");

                // suspended by user
                if (cancellationToken.IsCancellationRequested)
                {
                    Helper.Logger.Information($"ScheduleRunAsync: canceled by user");
                    progressLogAction?.Invoke($"Canceled: {cancellationToken.IsCancellationRequested}");
                    return null;
                }
                var cloudJob = await api.GetJobAsync(proj.Owner.Name, proj.Name, runJob.Id.ToString());

                actionWhenDone?.Invoke();
                return cloudJob;
            }
            catch (Exception ex)
            {
                //Eto.Forms.MessageBox.Show(e.Message, Eto.Forms.MessageBoxType.Error);
                Helper.Logger.Error(ex, $"ScheduleRunAsync: failed to run.");
                throw ex;
            }

        }

        public string RunOnLocalMachine(int cpuNum)
        {

            //C:\Users\mingo\ladybug_tools\python\Scripts\queenbee luigi translate
            //"C:\Users\mingo\ladybug_tools\resources\recipes\daylight-factor-baked.yaml"
            //"D:\Test\queenbeeTest"
            //- i "D:\Test\queenbeeTest\inputs.json"--workers 10--run

            var program = @"C:\Users\mingo\ladybug_tools\python\Scripts\queenbee.exe";
            var recipe = @"C:\Users\mingo\ladybug_tools\resources\recipes\daylight-factor-baked.yaml";
            var modelFile = @"D:\Test\queenbeeTest\model.hbjson";
            var argsInputs = @"D:\Test\queenbeeTest\inputs.json";
            var cpuNumber = cpuNum;

            var tempProjectFolder = Path.Combine(Path.GetTempPath(), "Queenbee", "localRun"); // @"D:\Test\queenbeeTest";
            if (Directory.Exists(tempProjectFolder))
                Directory.Delete(tempProjectFolder, true);
            Directory.CreateDirectory(tempProjectFolder);
            //Copy model file
            File.Copy(modelFile, Path.Combine(tempProjectFolder, "model.hbjson"));

            var args = $"luigi translate {recipe} {tempProjectFolder} -i {argsInputs} --workers {cpuNumber} --run";
            var command = $"{program} {args}";

            RunCommand(program, tempProjectFolder, command);

            return command;

        }

        private void RunCommand(string program, string workingDir, string arg)
        {
            try
            {
                var exeProcess = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = false,
                        UseShellExecute = true,
                        FileName = "cmd",
                        WorkingDirectory = workingDir,
                        //RedirectStandardError = true,
                        //RedirectStandardOutput = true,
                        Arguments = "/c " + arg,
                    },
                    EnableRaisingEvents = true

                };
                exeProcess.Start();
                exeProcess.WaitForExit();
                string result = exeProcess.StandardOutput.ReadToEnd();
            }
            catch (System.Exception objException)
            {
                // Log the exception
            }

        }

        
        private static string CheckRecipeInProject(string recipeSource, Project project)
        {
            var found = Helper.GetRecipeFromRecipeSourceURL(recipeSource, out var recOwner, out var recName, out var recVersion);
            if (!found) 
            {
                var msg = $"CheckRecipeInProject: invalid recipe source {recipeSource}";
                Helper.Logger.Error(msg);
                throw new ArgumentException(msg);
            }

            return CheckRecipeInProject(recOwner, recName, project);

        }

        public static string CheckRecipeInProject(string recOwner, string recName, Project project)
        {
            //// Check if recipe can be used in this project
            var projAPi = new ProjectsApi();
            var recipeFilter = new ProjectRecipeFilter(recOwner, recName);
            var result = projAPi.CreateProjectRecipeFilter(project.Owner.Name, project.Name, recipeFilter);
            var status = result?.Status;
            if (string.IsNullOrEmpty(status) || status != "accepted")
            {
                var msg = $"CheckRecipeInProject: failed to add recipe [{recName}] to project {project.Name}: {status}";
                Helper.Logger.Error(msg);
                throw new ArgumentException(msg);
            }
            Helper.Logger.Information(status);
            return status;

        }

        /// <summary>
        /// check every file and files in dir, and move to temp folder.
        /// </summary>
        /// <param name="SubmitSimulation"></param>
        /// <returns></returns>
        private static string CheckArtifacts(Job job, string subFolderPath)
        {
            var temp = string.Empty;
            var arg = job.Arguments;

            var artis = arg.SelectMany(_=>_.OfType<JobPathArgument>());
            if (artis == null || !artis.Any()) return temp;

            // remove old temp files first
            var tempPollination = Path.Combine(Helper.GenTempFolder(), "prepareArtifacts");
            //Directory.CreateDirectory(tempPollination);
            //Directory.Delete(tempPollination, true);

            temp = Path.Combine(tempPollination, Path.GetRandomFileName());
            // add sub study folder under project root folder
            var studyFolder = string.IsNullOrEmpty(subFolderPath) ? temp : Path.Combine(temp, subFolderPath);
            Directory.CreateDirectory(studyFolder);

            foreach (var item in artis)
            {
                //ProjectFolderSource only
                var source = item.Source.Obj as ProjectFolder;
                if (source == null) continue;

                var fileOrFolder = source.Path;
                FileAttributes attr = File.GetAttributes(fileOrFolder);
                var isDir = attr.HasFlag(FileAttributes.Directory);
                var isExists = isDir ? Directory.Exists(fileOrFolder) : File.Exists(fileOrFolder);
                if (!isExists)
                    throw new ArgumentException($"File or Folder does not exist: {fileOrFolder}");


                // copy to temp folder
                if (isDir)
                {
                    var targetDir = Path.Combine(studyFolder, Path.GetFileName(fileOrFolder));
                    Directory.CreateDirectory(targetDir);
                    var subDirs = Directory.GetDirectories(fileOrFolder, "*", SearchOption.AllDirectories);
                    foreach (var dir in subDirs)
                    {
                        Directory.CreateDirectory(dir.Replace(fileOrFolder, targetDir));
                    }

                    var subfiles = Directory.GetFiles(fileOrFolder, "*.*", SearchOption.AllDirectories);
                    foreach (var f in subfiles)
                    {
                        var targetPath = f.Replace(fileOrFolder, targetDir);
                        File.Copy(f, targetPath, true);
                    }

                    //folders.Add(fileOrFolder);
                }
                else
                {
                    var f = fileOrFolder;
                    var targetPath = Path.Combine(studyFolder, Path.GetFileName(f));
                    File.Copy(f, targetPath, true);
                    //files.Add(fileOrFolder);
                }


            }

            return temp;

        }

        /// <summary>
        /// Update artifact's absolute path to relative path to project-folder
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        private static Job UpdateArtifactPath(Job job, string subFolderPath)
        {
            var argSets = job?.Arguments;
            if (argSets == null)
                return job;

            //var checkedArtis = new List<JobPathArgument>();
            var newJob = job.DuplicateJob();
            newJob.Arguments.Clear();

            foreach (var argSet in argSets)
            {
                //add an empty argument set.
                newJob.AddArgumentSet();
                foreach (var item in argSet)
                {
                    if (item.Obj is JobPathArgument path)
                    {
                        // only update the path for ProjectFolderSource for a relative path
                        var projFolderSource = path.Source.Obj as ProjectFolder;
                        if (projFolderSource == null) continue;

                        // update artifact arguments
                        var newFileOrDirname = Path.GetFileName(projFolderSource.Path);
                        if (!string.IsNullOrEmpty(subFolderPath)) newFileOrDirname = $"{subFolderPath}/{newFileOrDirname}";
                        var pSource = new ProjectFolder(path: newFileOrDirname);
                        var newPath = new JobPathArgument(path.Name, pSource);

                        // add it to the last available argument set.
                        newJob.AddArgument(newPath);
                    }
                    else if (item.Obj is JobArgument valueArg)
                    {
                        // add it to the last available argument set.
                        newJob.AddArgument(valueArg);
                    }
                }

               

            }

            return newJob;
        }



    }
}
