using NUnit.Framework;
using PollinationSDK.Api;
using System.Collections.Generic;

namespace PollinationSDK.Test
{
    [TestFixture]
    public class UserApiTests
    {
        private UserApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new UserApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }


        /// <summary>
        /// Test GetMe
        /// </summary>
        [Test]
        public void GetMeTest()
        {
            var response = instance.GetMe();
            Assert.IsInstanceOf(typeof(UserPrivate), response, "response is UserPrivate");
            Assert.IsTrue(!string.IsNullOrEmpty(response.Username));
        }
        
        /// <summary>
        /// Test GetRoles
        /// </summary>
        [Test]
        public void GetRolesTest()
        {
            var response = instance.GetRoles();
            Assert.IsTrue(response.Count > 0);
        }
        
        
        
    }

}
