using Newtonsoft.Json;
using PollinationSDK.Client;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PollinationSDK
{
    public static class AuthHelper
    {

        private static string LoginURL => "https://app.pollination.cloud/sdk-login";
        private static string LoginURL_Dev => "https://app.staging.pollination.cloud/sdk-login";

        public static string ApiURL => "https://api.pollination.cloud/";
        public static string ApiURL_Dev => "https://api.staging.pollination.cloud/";

        /// <summary>
        /// Token from previous sign in if any, otherwise this is an empty string. Call SignIn() first for users to login from browser.
        /// </summary>
        private static string ID_TOKEN { get; set; } = string.Empty;
        public static async Task SignInAsync(Action ActionWhenDone = default, bool devEnv = false)
        {
            //OutputMessage = string.Empty;
            var task = PollinationSignIn(devEnv);
            try
            {
                var token = await task;
                if (!string.IsNullOrEmpty(token))
                {
                    Configuration.Default.BasePath = devEnv ? ApiURL_Dev : ApiURL;
                    Configuration.Default.AddDefaultHeader("Authorization", $"Bearer {token}");
                    Helper.CurrentUser = Helper.GetUser();
                }

                if (ActionWhenDone != default)
                {
                    ActionWhenDone();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        public static async Task<string> PollinationSignIn(bool devEnv = false)
        {
            var redirectUrl = "http://localhost:8645/";
            var loginUrl = devEnv ? LoginURL_Dev : LoginURL;

            var listener = new System.Net.HttpListener();

            try
            {
                listener.Prefixes.Add(redirectUrl);
                listener.Start();

            }
            catch (HttpListenerException e)
            {
                // it is already listening the port, but users didn't login
                if (e.ErrorCode == 183)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }

                throw;

            }

            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = loginUrl,
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);

            // wait for the authorization response.
            var context = await listener.GetContextAsync();

            var request = context.Request;
            var response = context.Response;

            var returnUrl = request.RawUrl.Contains("?token=") ? request.RawUrl : request.UrlReferrer?.PathAndQuery;
            if (string.IsNullOrEmpty(returnUrl)) throw new ArgumentException($"Failed to authorize the login: \n{request.RawUrl}");

            //sends an HTTP response to the browser.
            string responseString = string.Format($"<html><head></head><body style=\"text-align: center; font-family: Lato, Helvetica, Arial, sans-serif\">Succesfully Logged in! You can close this browser window.</body></html>");
            var buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            responseOutput.Write(buffer, 0, buffer.Length);
            responseOutput.Close();


            return returnUrl.Split('=').LastOrDefault();
        }
    }
}
