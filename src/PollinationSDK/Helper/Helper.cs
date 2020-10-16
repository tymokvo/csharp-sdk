using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;
using PollinationSDK.Wrapper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PollinationSDK
{
    public static class Helper
    {
        public static UserPrivate CurrentUser { get; set; }

        public static UserPrivate GetUser()
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
        public static Project GetAProject(string userName, string projectName)
        {
            var api = new ProjectsApi();
            try
            {
                var d = api.GetProject(userName, projectName);
                return d;
            } 
            catch (ApiException e)
            {
                // Project not found and person account, create a default demo project.
                if (e.ErrorCode == 404 && userName == Helper.CurrentUser.Username)
                {
                    var ifPublic = projectName == "demo";
                    var res = api.CreateProject(userName, new ProjectCreate(projectName, _public: ifPublic));
                    return GetAProject(userName, projectName);
                }
                throw e;
            }
           
            
            //var d = GetProjects(user).FirstOrDefault(_ => _.Name == projectName);
            //return d;
        }

        public static async Task<bool> UploadDirectoryAsync(Project project, string directory, Action<int> reportProgressAction = default, CancellationToken cancellationToken = default)
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
        public static async Task<bool> UploadArtifaceAsync(Project project, string fullPath, string relativePath)
        {
            var filePath = fullPath;
            var fileRelativePath = relativePath.Replace('\\', '/');
            if (fileRelativePath.StartsWith("/")) 
                fileRelativePath = fileRelativePath.Substring(1);

            //fileRelativePath = "project_folder/" + fileRelativePath;
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
                Console.WriteLine($"Done uploading: {fileRelativePath}");
                return true;
            }
            return false;


        }

        /// <summary>
        /// check every file and files in dir, and move to temp folder.
        /// </summary>
        /// <param name="SubmitSimulation"></param>
        /// <returns></returns>
        private static string CheckArtifacts(SubmitSimulation SubmitSimulation)
        {
            var arg = SubmitSimulation.Inputs;

            var artis = arg.Artifacts;
            //var files = new List<string>();
            //var folders = new List<string>();
            var temp = string.Empty;

            // remove old temp files first
            var tempPollination = Path.Combine(GenTempFolder(), "prepareArtifacts");
            Directory.CreateDirectory(tempPollination);
            Directory.Delete(tempPollination, true);


            if (artis != null)
            {
                temp = Path.Combine(tempPollination, Path.GetRandomFileName());
                Directory.CreateDirectory(temp);

                foreach (var item in artis)
                {
                    //ProjectFolderSource only
                    var source = item.Source.Obj as ProjectFolderSource;
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
        /// <param name="SubmitSimulation"></param>
        /// <returns></returns>
        public static SubmitSimulation UpdateArtifactPath(SubmitSimulation SubmitSimulation)
        {
            var simu = SubmitSimulation;

            if (simu?.Inputs?.Artifacts == null)
                return simu;

            var artis = simu.Inputs.Artifacts;
            var checkedArtis = new List<SimulationInputArtifact>();
            foreach (var item in artis)
            {
                // only update the path for ProjectFolderSource for a relative path
                var projFolderSource = item.Source.Obj as ProjectFolderSource;
                if (projFolderSource == null) continue;

                // update artifact arguments
                var newFileOrDirname = Path.GetFileName(projFolderSource.Path);
                // TODO: this is a temporary fix before Queenbee updates the type value
                var pSource = new ProjectFolderSource(newFileOrDirname) { Type = "project-folder" };
                checkedArtis.Add(new SimulationInputArtifact(item.Name, pSource));
            }
            var simuInputs = new SimulationInputs(checkedArtis, simu.Inputs.Parameters);
            var newSimu = new SubmitSimulation(simu.Recipe, simuInputs);

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
            Project project, 
            SubmitSimulation workflow, 
            Action<string> progressLogAction = default,
            CancellationToken cancellationToken = default,
            Action actionWhenDone = default)
        {

            // Get project
            var proj = project;

            // Check if recipe can be used in this project
            var recipe = workflow.Recipe;
            var projAPi = new ProjectsApi();
            //var res = projAPi.GetProjectRecipeFilters(proj.Owner.Name, proj.Name);
            var result = projAPi.CreateProjectRecipeFilter(proj.Owner.Name, proj.Name, new ProjectRecipeFilter(recipe.Name, recipe.Owner, recipe.Tag));
            var status = result?.Status;
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
            var json = newWorkflow.ToJson();

            // create a new Simulation
            var api = new SimulationsApi();
            progressLogAction?.Invoke($"Start running."); 

            try
            {
                // schedule a simulation on Pollination.Cloud
                var ret = await api.CreateSimulationAsync(proj.Owner.Name, proj.Name, newWorkflow);
                var simuId = ret.Id;
                progressLogAction?.Invoke($"Start running..");

                // give server a moment to start the simulation after it's scheduled.
                await Task.Delay(500);

                // monitoring the running simulation
                var runningSimulaiton = new Wrapper.Simulation(proj, simuId.ToString());
                progressLogAction?.Invoke($"Start running...");

                //Action<string> updateMessageProgressForStatus = (string p) => { progressLogAction?.Invoke(p); };
                //await runningSimulaiton.CheckStatusAsync(updateMessageProgressForStatus, cancellationToken);


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
                var dir = string.IsNullOrEmpty(saveAsDir) ? GenTempFolder() : saveAsDir;
                var simuID = simu.SimulationID.Substring(0, 8);
                dir = Path.Combine(dir, simuID, "outputs");

                var tasks = artifacts.Select(_ => DownloadArtifact(simu, _, dir)).ToList();
                //var tasks = artifacts.SelectMany(_ => DownloadArtifactWithItems(simu, _, saveAsDir)).ToList();

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

            if (filePaths.Count == 1)
            {
                //if folder, then return items in folder
                var path = filePaths[0];
                if (Directory.Exists(path))
                {
                    var items = Directory.EnumerateFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly);
                    filePaths = items.Any() ? items.ToList() : filePaths;
                }
            }
            return filePaths;
            //return finished;
        }
    
        private static async Task<List<string>> Download(string url, string dir)
        {

            try
            {
                // downloaded folder
                var task = DownloadFromUrlAsync(url, dir);
                var finishedTask = await Task.WhenAny(new[] { task });
                var downloadedFileFolder = finishedTask.Result;

                var filePaths = new List<string>();
                if (Directory.Exists(downloadedFileFolder))
                {
                    var items = Directory.EnumerateFileSystemEntries(downloadedFileFolder, "*", SearchOption.TopDirectoryOnly);
                    filePaths = items.Any() ? items.ToList() : filePaths;
                }
                else
                {
                    filePaths.Add(downloadedFileFolder);
                }
                return filePaths;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<List<string>> DownloadArtifactZip(Simulation simu, string zipFileName, string saveAsDir = default, Action<int> reportProgressAction = default)
        {
            try
            {
                var simuApi = new PollinationSDK.Api.SimulationsApi();

                var url = simuApi.DownloadSimulationArtifact(simu.Project.Owner.Name, simu.Project.Name, simu.SimulationID, zipFileName).ToString();

                var dir = string.IsNullOrEmpty(saveAsDir) ? GenTempFolder() : saveAsDir;
                var simuID = simu.SimulationID.Substring(0, 8);
                dir = Path.Combine(dir, simuID);
                // downloaded folder
                return await Download(url, dir);
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public static async Task<List<string>> DownloadSimulationInputAssets(Simulation simu, string saveAsDir = default, Action<int> reportProgressAction = default)
        {
            try
            {
                var simuApi = new PollinationSDK.Api.SimulationsApi();
                var url = simuApi.GetSimulationInputs(simu.Project.Owner.Name, simu.Project.Name, simu.SimulationID).ToString();

                var dir = string.IsNullOrEmpty(saveAsDir) ? GenTempFolder() : saveAsDir;
                var simuID = simu.SimulationID.Substring(0, 8);
                dir = Path.Combine(dir, simuID, "inputs");
                // downloaded folder
                return await Download(url, dir);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static async Task<string> DownloadFromUrlAsync(string url, string saveAsDir)
        {
            var file = string.Empty;
            var outputDirOrFile = string.Empty;

            Console.WriteLine($"Simulation output link url: {url}");
            var request = new RestRequest(Method.GET);
            var client = new RestClient(url.ToString());
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Unable to download file");

            // prep file path
            var fileName = Path.GetFileName(url).Split(new[] { '?' })[0];

            Directory.CreateDirectory(saveAsDir);
            file = Path.Combine(saveAsDir, fileName);

            var b = response.RawBytes;
            File.WriteAllBytes(file, b);

            if (!File.Exists(file)) throw new ArgumentException($"Failed to download {fileName}");
            outputDirOrFile = file;

            // unzip
            try
            {
                if (file.ToLower().EndsWith(".zip")) outputDirOrFile = Helper.Unzip(file, saveAsDir, true);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Failed to unzip file {Path.GetFileName(file)}.\n -{e.Message}");
            }

            Console.WriteLine($"Finished downloading: {url} to {outputDirOrFile}");
            return outputDirOrFile;

        }
        /// <summary>
        /// Download an artifact with one call. It'd be a zip file if the artifact is a folder
        /// </summary>
        /// <param name="simu"></param>
        /// <param name="artifact"></param>
        /// <param name="saveAsDir"></param>
        /// <returns></returns>
        private static Task<string> DownloadArtifact(Simulation simu, OutputArtifact artifact, string saveAsDir)
        {
            var file = string.Empty;
            var outputDirOrFile = string.Empty;
            try
            {
                var api = new PollinationSDK.Api.SimulationsApi();
                var url = api.GetSimulationOutputArtifact(simu.Project.Owner.Name, simu.Project.Name, simu.SimulationID, artifact.Name).ToString();
                
                var task = DownloadFromUrlAsync(url, saveAsDir);
                return task;

            }
            catch (Exception e)
            {
                throw new ArgumentException($"Failed to download artifact {artifact.Name}.\n -{e.Message}");
            }
        }
        /// <summary>
        /// Download an artifact(file/folder) items independently.
        /// </summary>
        /// <param name="simu"></param>
        /// <param name="artifact"></param>
        /// <param name="saveAsDir"></param>
        /// <returns></returns>
        public static List<Task<string>> DownloadArtifactWithItems(Simulation simu, OutputArtifact artifact, string saveAsDir)
        {
            var file = string.Empty;
            var outputDirOrFile = string.Empty;
            try
            {
                var api = new PollinationSDK.Api.SimulationsApi();
                var files = api.ListSimulationArtifacts(simu.Project.Owner.Name, simu.Project.Name, simu.SimulationID, page: 1, perPage: 100);
                var found = files.FirstOrDefault(_ => _.FileName == artifact.Name);
                if (found == null) throw new ArgumentException($"{artifact.Name} doesn't exist in {simu.Project.Owner.Name}/{simu.Project.Name}/{simu.SimulationID}");

                var dir = string.IsNullOrEmpty(saveAsDir) ? GenTempFolder() : saveAsDir;
                var simuID = simu.SimulationID.Substring(0, 8);

                var tasks = new List<Task<string>>();
                dir = Path.Combine(dir, simuID);
                ListFilesFromFolder(ref tasks, dir, simu.Project.Owner.Name, simu.Project.Name, simu.SimulationID, found, api);

                return tasks;

               

            }
            catch (Exception e)
            {
                throw new ArgumentException($"Failed to download artifact {artifact.Name}.\n -{e.Message}");
            }

            // loop through files in folder
            void ListFilesFromFolder(ref List<Task<string>> ts, string saveDir, string owner, string projName, string simuID,  FileMeta artfact, SimulationsApi simulationsApi )
            {
                var dir = saveDir;
                var api = simulationsApi;
                if (artfact.Type == "file")
                {
                    var url = api.DownloadSimulationArtifact(owner, projName, simuID, artfact.Key).ToString();
                    var task = DownloadFromUrlAsync(url, dir);
                    ts.Add(task);
                }
                else if (artfact.Type == "folder")
                {
                    dir = Path.Combine(dir, artfact.FileName);
                    var files = api.ListSimulationArtifacts(owner, projName, simuID, page: 1, perPage: 100, path: new[] { artifact.Name }.ToList());
                    foreach (var item in files)
                    {
                        // get all files in folder
                        if (item.Type == "folder")
                        {
                            ListFilesFromFolder(ref ts, dir, owner, projName, simuID, item, api);
                            continue;
                        }
                        // item is file
                        var url = api.DownloadSimulationArtifact(owner, projName, simuID, item.Key).ToString();
                        var task = DownloadFromUrlAsync(url, dir);

                        ts.Add(task);
                    }
                }
            }

        }

        /// <summary>
        /// Return the Pollination directory saved in Temp folder
        /// </summary>
        /// <returns></returns>
        public static string GenTempFolder()
        {
            var tempDir = Path.Combine(Path.GetTempPath(), "Pollination");
            Directory.CreateDirectory(tempDir);
            return tempDir;
        }

        internal static string Unzip(string zipFilePath, string saveAsDir, bool removeZip)
        {
            if (!File.Exists(zipFilePath)) throw new ArgumentException($"{Path.GetFileName(zipFilePath)} does not exist!");
            var tempDir = new DirectoryInfo(Path.Combine(GenTempFolder(), Path.GetRandomFileName()));
            // Directory.CreateDirectory(tempDir.FullName);
            ZipFile.ExtractToDirectory(zipFilePath, tempDir.FullName);


            //copy folder
            try
            {
                if (removeZip)
                    File.Delete(zipFilePath);
                CopyDirectory(tempDir.FullName, saveAsDir);
                
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Failed to save files to: {saveAsDir}.\n -{e.Message}");
            }

            var outputDirOrFile = saveAsDir;


            var subItems = tempDir.GetFileSystemInfos("*", SearchOption.TopDirectoryOnly);

            if (subItems.Count() == 1 )
            {
                // if there is only one file/folder inside
                var f = subItems[0];
                if (f.Exists) outputDirOrFile = Path.Combine(saveAsDir, f.Name);
            }

            return outputDirOrFile;
        }

        //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories?redirectedfrom=MSDN
        private static void CopyDirectory(string sDir, string dDir)
        {
            if (!Directory.Exists(sDir)) return;
            var dir = new DirectoryInfo(sDir);

            if (!Directory.Exists(dDir)) Directory.CreateDirectory(dDir);

            // copy files
            var files = dir.GetFiles();
            foreach (var f in files)
            {
                string t = Path.Combine(dDir, f.Name);
                f.CopyTo(t, true);
            }

            // copy dirs
            var dirs = dir.GetDirectories();
            foreach (var subdir in dirs)
            {
                string t = Path.Combine(dDir, subdir.Name);
                if (Directory.Exists(t)) Directory.Delete(t, true);
                CopyDirectory(subdir.FullName, t);
            }
        }


    }
}
