using NUnit.Framework;
using System;

namespace PollinationSDK.Test
{
    [SetUpFixture]
    public class TestInit
    {

        [OneTimeSetUp]
        public void Init()
        {
            // environment
            var key = Environment.GetEnvironmentVariable("PollinationApiKey");
            if (string.IsNullOrEmpty(key))
            {
                // for local development tests, you must add Api key to ApiKey.txt
                key = System.IO.File.ReadAllText(@"../../../ApiKey.txt");
            }

            var apiAuthentication = key;
            AuthHelper.SignInWithApiAuthAsync(apiAuthentication, null, devEnv: true).Wait();
        }
    }
}
