using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;
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

        public static async Task<bool> UploadDirectoryAsync(ProjectDto project, string directory, Action<int> reportProgressAction = default)
        {
            var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            var tasks = files.Select(_ => UploadArtifaceAsync(project, _, _.Replace(directory, ""))).ToList();

            var total = files.Count();
            while (tasks.Count() > 0)
            {
                var left = tasks.Count();
                var finishedTask = await Task.WhenAny(tasks);
                //Console.WriteLine("done!");

                tasks.Remove(finishedTask);
                var finishedPercent = (total - left) / (double)total * 100;
                reportProgressAction?.Invoke((int)finishedPercent);

            }
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
    }
}
