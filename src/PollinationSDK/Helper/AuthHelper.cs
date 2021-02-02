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

        public static async Task SignInAsync(Action ActionWhenDone = default, bool devEnv = false)
        {
            //OutputMessage = string.Empty;
           
            try
            {
                var task = PollinationSignInAsync(devEnv);
                var token = await task;
                if (!string.IsNullOrEmpty(token))
                {
                    Configuration.Default.BasePath = devEnv ? ApiURL_Dev : ApiURL;
                    Configuration.Default.AddDefaultHeader("Authorization", $"Bearer {token}");
                    Helper.CurrentUser = Helper.GetUser();
                    Helper.Logger.Information($"SignInAsync: logged in as {Helper.CurrentUser.Username}");
                }
                else
                {
                    Helper.Logger.Warning($"SignInAsync: Failed to get the Auth token");
                }

                ActionWhenDone?.Invoke();
            }
            catch (Exception e)
            {
                Helper.Logger?.Error(e, "Failed to sign in");
                //Console.WriteLine(e.Message);
                throw e;
            }

        }

        private static async Task<string> PollinationSignInAsync(bool devEnv = false)
        {
            if (!HttpListener.IsSupported) {
                Helper.Logger.Error($"PollinationSignInAsync: HttpListener is not supported on this system");
                throw new ArgumentException("PollinationSignIn is not supported on this system");
            }
               
            var redirectUrl = "http://localhost:8645/";
            var loginUrl = devEnv ? LoginURL_Dev : LoginURL;

            var listener = new System.Net.HttpListener();

            try
            {
               
                listener.Prefixes.Add(redirectUrl);
                listener.Start();
                //listener.TimeoutManager.IdleConnection = TimeSpan.FromSeconds(30);
                //listener.TimeoutManager.HeaderWait = TimeSpan.FromSeconds(30);

            }
            catch (HttpListenerException e)
            {
                //it is already listening the port, but users didn't login
                if (e.ErrorCode == 183)
                {
                    Console.WriteLine(e.Message);
                    Helper.Logger.Warning($"PollinationSignInAsync: it is still waiting for users to login from last time.\n{e.Message}");
                }
                else
                {
                    Helper.Logger.Error($"PollinationSignInAsync: Failed to start the listener.\n{e.Message}");
                    throw e;
                }

            }

            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = loginUrl,
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
            Helper.Logger.Information($"PollinationSignInAsync: loggin from {loginUrl}");

            // wait for the authorization response.
            var context = await listener.GetContextAsync();

            var request = context.Request;
            var response = context.Response;

            var returnUrl = request.RawUrl.Contains("?token=") ? request.RawUrl : request.UrlReferrer?.PathAndQuery;
            if (string.IsNullOrEmpty(returnUrl)) {
                Helper.Logger.Error($"PollinationSignInAsync: Failed to authorize the login: \n{request.RawUrl}");
                throw new ArgumentException($"Failed to authorize the login: \n{request.RawUrl}");
            }

            //sends an HTTP response to the browser.
            string responseString = string.Format($"<html><head></head><body style=\"text-align: center; font-family: Lato, Helvetica, Arial, sans-serif\">Succesfully Logged in! You can close this browser window.</body></html>");
            var buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            await responseOutput.WriteAsync(buffer, 0, buffer.Length);
            await Task.Delay(1000);
            responseOutput.Flush();
            responseOutput.Close();
            listener.Stop();

            Helper.Logger.Information($"PollinationSignInAsync: closing the listener");
            return returnUrl.Split('=').LastOrDefault();
        }
    }
}
