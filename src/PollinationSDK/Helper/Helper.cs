using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;
using PollinationSDK.Wrapper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PollinationSDK
{
    public static class Helper
    {
        public static PrivateUserDto CurrentUser { get; set; }

        public static PrivateUserDto GetUser()
        {
            var api = new UserApi();
            //var config = api.Configuration;
            var me = api.GetMe();
            return me;
        }

        /// <summary>
        /// Get a project by current user and name. If not found, then create a new project.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public static ProjectDto GetAProject(PrivateUserDto user, string projectName)
        {
            var api = new ProjectsApi();
            try
            {
                var d = api.GetProject(user.Username, projectName);
                return d;
            }
            catch (ApiException e)
            {
                // Project not found
                if (e.ErrorCode == 404)
                {
                    var ifPublic = projectName == "unnamed";
                    var res = api.CreateProject(user.Username, new PatchProjectDto(projectName, _public: ifPublic));
                    return GetAProject(user, projectName);
                }
                throw e;
            }
           
            
            //var d = GetProjects(user).FirstOrDefault(_ => _.Name == projectName);
            //return d;
        }

        public static async Task<bool> UploadDirectoryAsync(ProjectDto project, string directory, Action<int> reportProgressAction = default, CancellationToken cancellationToken = default)
        {

            var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            var tasks = files.Select(_ => UploadArtifaceAsync(project, _, _.Replace(directory, ""))).ToList();
            var total = files.Count();


            var finishedPercent = 0;
            reportProgressAction?.Invoke(finishedPercent);
            while (tasks.Count() > 0)
            {
                // canceled by user
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Canceled uploading by user");
                    break;
                }

                var finishedTask = await Task.WhenAny(tasks);

                tasks.Remove(finishedTask);

                var unfinishedUploadTasksCount = tasks.Count();
                finishedPercent = (int)((total - unfinishedUploadTasksCount) / (double)total * 100);
                reportProgressAction?.Invoke(finishedPercent);

            }

            // canceled by user
            if (cancellationToken.IsCancellationRequested) return false;

            Console.WriteLine("Finished uploading directory");
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullPath">something like: "C:\Users\mingo\Downloads\Compressed\project_folder\project_folder\model\grid\room.pts"</param>
        /// <param name="relativePath">"model\grid\room.pts"</param>
        public static async Task<bool> UploadArtifaceAsync(ProjectDto project, string fullPath, string relativePath)
        {
            var filePath = fullPath;
            var fileRelativePath = "project_folder" + relativePath.Replace('\\', '/');

            var api = new ArtifactsApi();
            var artf = await api.CreateArtifactAsync(project.Owner.Name, project.Name, new KeyRequest(fileRelativePath));

            var url = artf.Url;


            //Use RestSharp
            RestClient restClient = new RestClient(url);
            RestRequest restRequest = new RestRequest();
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Method = Method.POST;
            restRequest.AddHeader("Content-Type", "multipart/form-data");
            restRequest.AddParameter("AWSAccessKeyId", artf.Fields["AWSAccessKeyId"]);
            restRequest.AddParameter("policy", artf.Fields["policy"]);
            restRequest.AddParameter("signature", artf.Fields["signature"]);
            restRequest.AddParameter("key", artf.Fields["key"]);
            restRequest.AddFile("file", filePath);
            var response = restClient.Execute(restRequest);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                Console.WriteLine($"Done uploading: {relativePath}");
                return true;
            }
            return false;


        }

        /// <summary>
        /// check every file and files in dir, and move to temp folder.
        /// </summary>
        /// <param name="submitSimulationDto"></param>
        /// <returns></returns>
        private static string CheckArtifacts(SubmitSimulationDto submitSimulationDto)
        {
            var arg = submitSimulationDto.Inputs;

            var artis = arg.Artifacts;
            //var files = new List<string>();
            //var folders = new List<string>();
            var temp = string.Empty;

            // remove old temp files first
            var tempPollination = Path.Combine(Path.GetTempPath(), "Pollination");
            Directory.CreateDirectory(tempPollination);
            Directory.Delete(tempPollination, true);


            if (artis != null)
            {
                temp = Path.Combine(tempPollination, Path.GetRandomFileName());
                Directory.CreateDirectory(temp);

                foreach (var item in artis)
                {
                    var fileOrFolder = item.Source.ToString();
                    FileAttributes attr = File.GetAttributes(fileOrFolder);
                    var isDir = attr.HasFlag(FileAttributes.Directory);
                    var isExists = isDir ? Directory.Exists(fileOrFolder) : File.Exists(fileOrFolder);
                    if (!isExists)
                        throw new ArgumentException($"File or Folder does not exist: {fileOrFolder}");


                    // copy to temp folder
                    if (isDir)
                    {
                        var targetDir = Path.Combine(temp, Path.GetFileName(fileOrFolder));
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
                        var targetPath = Path.Combine(temp, Path.GetFileName(f));
                        File.Copy(f, targetPath, true);
                        //files.Add(fileOrFolder);
                    }


                }

            }

            return temp;

        }


        /// <summary>
        /// Update artifact's absolute path to relative path to project-folder
        /// </summary>
        /// <param name="submitSimulationDto"></param>
        /// <returns></returns>
        public static SubmitSimulationDto UpdateArtifactPath(SubmitSimulationDto submitSimulationDto)
        {
            var simu = submitSimulationDto;

            if (simu?.Inputs?.Artifacts == null)
                return simu;

            var artis = simu.Inputs.Artifacts;
            var checkedArtis = new List<ArgumentArtifact>();
            foreach (var item in artis)
            {
                // update artifact arguments
                var newFileOrDirname = Path.GetFileName(item.Source.ToString());
                checkedArtis.Add(new ArgumentArtifact(item.Name, new ArtifaceSourcePath(newFileOrDirname)));
            }
            var newArgs = new Arguments(simu.Inputs.Parameters, checkedArtis);
            var newSimu = new SubmitSimulationDto(simu.Recipe, newArgs);

            return newSimu;
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
        public static async Task<Wrapper.Simulation> RunSimulationAsync(
            ProjectDto project, 
            SubmitSimulationDto workflow, 
            Action<string> progressLogAction = default,
            CancellationToken cancellationToken = default,
            Action actionWhenDone = default)
        {

            // Get project
            var proj = project;


            // Upload artifacts

            // check artifacts 
            var tempProjectDir = CheckArtifacts(workflow);

            // upload artifacts
            if (!string.IsNullOrEmpty(tempProjectDir))
            {
                Action<int> updateMessageProgress = (int p) => {
                    progressLogAction?.Invoke($"Preparing: [{p}%]");
                };
                await Helper.UploadDirectoryAsync(proj, tempProjectDir, updateMessageProgress, cancellationToken);
            }

            // suspended by user
            if (cancellationToken.IsCancellationRequested)
            {
                progressLogAction?.Invoke($"Canceled: {cancellationToken.IsCancellationRequested}");
                return null;
            }

            // update Artifact to cloud's relative path after uploaded.
            var newWorkflow = UpdateArtifactPath(workflow);

            // create a new Simulation
            var api = new SimulationsApi();
            progressLogAction?.Invoke($"Start running."); 

            try
            {
                // schedule a simulation on Pollination.Cloud
                var ret = await api.CreateSimulationAsync(proj.Owner.Name, proj.Name, newWorkflow);
                var simuId = ret.Id;
                progressLogAction?.Invoke($"Start running..");
                // monitoring the running simulation
                var runningSimulaiton = new Wrapper.Simulation(proj, simuId.ToString());
                Action<string> updateMessageProgressForStatus = (string p) => { progressLogAction?.Invoke(p); };

                progressLogAction?.Invoke($"Start running...");
                await runningSimulaiton.CheckStatusAsync(updateMessageProgressForStatus, cancellationToken);


                // suspended by user
                if (cancellationToken.IsCancellationRequested)
                {
                    progressLogAction?.Invoke($"Canceled: {cancellationToken.IsCancellationRequested}");
                    return null;
                }

                actionWhenDone?.Invoke();
                return runningSimulaiton;
            }
            catch (Exception)
            {
                //Eto.Forms.MessageBox.Show(e.Message, Eto.Forms.MessageBoxType.Error);
                throw;
            }

       
           
        }

        /// <summary>
        /// Download a list of OutputArtifacts from a simulation.
        /// </summary>
        /// <param name="simu"></param>
        /// <param name="artifacts"></param>
        /// <param name="saveAsDir"></param>
        /// <param name="reportProgressAction"></param>
        /// <returns></returns>
        public static async Task<List<string>> DownloadOutputArtifactsAsync(Simulation simu, List<OutputArtifact> artifacts, string saveAsDir = default, Action<int> reportProgressAction = default)
        {
            //_filePaths = new List<string>();
            var downloadedFiles = new List<string>();
            try
            {
                var api = new PollinationSDK.Api.SimulationsApi();
                var tasks = artifacts.Select(_ => DownloadArtifact(simu, _, saveAsDir)).ToList();
        

                var total = tasks.Count();
                while (tasks.Count() > 0)
                {
                    var finishedTask = await Task.WhenAny(tasks);
                    downloadedFiles.Add(finishedTask.Result);
                    tasks.Remove(finishedTask);

                    var left = tasks.Count();
                    var finishedPercent = (total - left) / (double)total * 100;
                    reportProgressAction?.Invoke((int)finishedPercent);

                }


            }
            catch (Exception)
            {
                throw;
            }

            var artifactNames = artifacts.Select(_ => _.Name.ToUpper()).ToList();
            var filePaths = downloadedFiles.OrderBy(_ => artifactNames.IndexOf(Path.GetFileNameWithoutExtension(_).ToUpper())).ToList();
            return filePaths;
            //return finished;
        }

        public static async Task<string> DownloadArtifact(Simulation simu, OutputArtifact artifact, string saveAsDir)
        {
            var file = string.Empty;

            try
            {
                var api = new PollinationSDK.Api.SimulationsApi();
                var url = api.GetSimulationOutputArtifact(simu.Project.Owner.Name, simu.Project.Name, simu.SimulationID, artifact.Name).ToString();



                Console.WriteLine($"Simulation output link url: {url}");
                var request = new RestRequest(Method.GET);
                var client = new RestClient(url.ToString());
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"Unable to download file");

                // prep file path
                var fileName = Path.GetFileName(url).Split(new[] { '?' })[0];
                var tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                var dir = string.IsNullOrEmpty(saveAsDir) ? tempDir : saveAsDir;
                Directory.CreateDirectory(dir);
                file = Path.Combine(dir, fileName);

                var b = response.RawBytes;
                File.WriteAllBytes(file, b);

                if (!File.Exists(file)) throw new ArgumentException($"Failed to download {fileName}");
            }
            catch (Exception)
            {
                //Eto.Forms.MessageBox.Show(e.Message, Eto.Forms.MessageBoxType.Error);
                throw;
            }


            Console.WriteLine($"Finished downloading: {file}");
            //_filePath = file;
            return file;
        }


    }
}
