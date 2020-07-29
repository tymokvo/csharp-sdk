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
        private static string Auth0ClientID_GH => "Q566EJGvOncgZIQRDzxHrxBsG4TXCGrR";
        private static string Auth0URL => "https://pollination.auth0.com/";
        /// <summary>
        /// Token from previous sign in if any, otherwise this is an empty string. Call SignIn() first for users to login from browser.
        /// </summary>
        private static string ID_TOKEN { get; set; } = string.Empty;
        public static async Task SignInAsync(Action ActionWhenDone = default)
        {
            //OutputMessage = string.Empty;
            var task = Auth0SignIn();
            try
            {
                var token = await task;
                if (!string.IsNullOrEmpty(token))
                {
                    Configuration.Default.BasePath = "https://api.pollination.cloud/";
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

        public static async Task<string> Auth0SignIn()
        {

            // create a redirect URI using an available port on the loopback address.
            //string redirectUri = string.Format("https://app.pollination.cloud/callback");
            string redirectUri = string.Format("http://localhost:3000/");
            Console.WriteLine("redirect URI: " + redirectUri);
            Console.WriteLine("-----------------------------------");



            // create an HttpListener to listen for requests on that redirect URI.
            var listener = new System.Net.HttpListener();
            try
            {
                listener.Prefixes.Add(redirectUri);
                listener.Start(); 
                Console.WriteLine($"Listening..{redirectUri}");

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
           


            var verifier = GenVerifier();
            var codeChallenge = GenCodeChallenge(verifier);
            //var verifier = state.CodeVerifier;
            Console.WriteLine("Verifier: " + verifier);
            Console.WriteLine("-----------------------------------");

            var state = GenState();
            Console.WriteLine("state: " + state);


            //var loginURL = state.StartUrl;
            // Build URL
            var loginURL = Auth0URL;
            loginURL += $"authorize?response_type=code";
            loginURL += $"&code_challenge={codeChallenge}";
            loginURL += $"&code_challenge_method=S256";
            loginURL += $"&client_id={Auth0ClientID_GH}";
            loginURL += $"&scope=openid";
            loginURL += $"&redirect_uri={redirectUri}";
            loginURL += $"&state={state}";


            Console.WriteLine($"Start login URL: {loginURL}");

            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = loginURL,
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);

            // wait for the authorization response.
            var context = await listener.GetContextAsync();

            var request = context.Request;
            var response = context.Response;


            Console.WriteLine("-----------------------------------");
            //Console.WriteLine($"AUTHORIZATION_CODE: ");
            var returnUrl = request.RawUrl.Contains("?code=") ? request.RawUrl : request.UrlReferrer?.PathAndQuery;
            if (string.IsNullOrEmpty(returnUrl)) throw new ArgumentException($"Failed to authorize the login: \n{request.RawUrl}");
            var AUTHORIZATION_CODE = returnUrl.Split('&').FirstOrDefault(_ => _.StartsWith("/?code=")).Split('=').Last().Trim();
            //Console.WriteLine(AUTHORIZATION_CODE);

            //Console.WriteLine($"State: ");
            var returnState = request.RawUrl.Split('&').FirstOrDefault(_ => _.StartsWith("state=")).Split('=').Last().Trim();
            //Console.WriteLine(returnState);
            var IsAuthorized = returnState.Equals(state);
            IsAuthorized &= !string.IsNullOrEmpty(AUTHORIZATION_CODE);
            Console.WriteLine($"IsAuthorized: {IsAuthorized}");
            Console.WriteLine("-----------------------------------");

            var responseMessage = "This is not an authorized request!";

            // Request Tokens
            if (IsAuthorized)
            {
                var restClient = new RestClient($"{Auth0URL}oauth/token");
                var restRequest = new RestRequest( Method.POST);
                //restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddParameter(
                    "application/x-www-form-urlencoded", 
                    $"grant_type=authorization_code&client_id={Auth0ClientID_GH}&code_verifier={verifier}&code={AUTHORIZATION_CODE}&redirect_uri={redirectUri}", 
                    ParameterType.RequestBody
                    );
        
                var restResponse = restClient.Execute(restRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = restResponse.Content;
                    var id_token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(responseContent)["id_token"].ToString();
                    ID_TOKEN = id_token;
                    Console.WriteLine("Successful login!");
                    //Console.WriteLine("id_token: " + id_token);
                    Console.WriteLine("-----------------------------------");
                    responseMessage = "Signed in!. \n\nYou can close this window, and return to the Grasshopper.";

                }


            }

            //sends an HTTP response to the browser.
            string responseString = string.Format($"<html><head></head><body>{responseMessage}</body></html>");
            var buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            await responseOutput.WriteAsync(buffer, 0, buffer.Length);
            responseOutput.Close();

            listener.Stop();

            return ID_TOKEN;

        }

        public static string GenVerifier() => GenCode(32);
        public static string GenState() => GenCode(16);

        public static string GenCode(int length)
        {
            Random rnd = new Random();
            Byte[] b = new Byte[length];
            rnd.NextBytes(b);
            var verifier = Base64UrlEncode(b);
            return verifier;
        }
        public static string GenCodeChallenge(string verifier)
        {
            var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(verifier));
            var codeChallenge = Base64UrlEncode(bytes);
            return codeChallenge;

        }

        private static string Base64UrlEncode(Byte[] inputBytes)
        {
            var encoded = Convert.ToBase64String(inputBytes)
                .TrimEnd(new[] { '=' })
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
            return encoded;
        }
    }


}
