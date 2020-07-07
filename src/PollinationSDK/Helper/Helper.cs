using Newtonsoft.Json;
using PollinationSDK.Api;
using PollinationSDK.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public static ProjectDto GetAProject(PrivateUserDto user, string projectName)
        {
            var api = new ProjectsApi();
            var d = api.GetProject(user.Username, projectName);
            //var d = GetProjects(user).FirstOrDefault(_ => _.Name == projectName);
            return d;
        }

        public static async Task<bool> UploadDirectory(ProjectDto project, string directory, Action<int> progressAction)
        {
            var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);

            var tasks = files.Select(_ => Helper.UploadArtifaceAsync(project, _, _.Replace(directory, ""))).ToList();
            var total = files.Count();
            while (tasks.Count() > 0)
            {
                var left = tasks.Count();
                var finishedTask = await Task.WhenAny(tasks);
                //Console.WriteLine("done!");

                tasks.Remove(finishedTask);
                var finishedPercent = (total - left) / (double)total * 100;
                progressAction((int)finishedPercent);
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

            using (var client = new HttpClient())
            {
                var byteArrayContent = new ByteArrayContent(File.ReadAllBytes(filePath));

                var content = new System.Net.Http.MultipartFormDataContent(){
                    { new StringContent(artf.Fields["AWSAccessKeyId"]), "\"AWSAccessKeyId\""},
                     { new StringContent(artf.Fields["policy"]), "\"policy\""},
                      { new StringContent(artf.Fields["signature"]), "\"signature\""},
                       { new StringContent(artf.Fields["key"]), "\"key\""},
                        { byteArrayContent, "\"file\""}
                };

                var postResponse = await client.PostAsync(url, content);
                if (postResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine($"Done uploading: {relativePath}");
                    return true;
                }
                return false;
            }


        }
    }
}
