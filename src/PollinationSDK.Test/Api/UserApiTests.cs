/* 
 * Pollination Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.5.28
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using PollinationSDK.Client;
using PollinationSDK.Api;
using PollinationSDK.Model;

namespace PollinationSDK.Test
{
    /// <summary>
    ///  Class for testing UserApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
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
        /// Test an instance of UserApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' UserApi
            //Assert.IsInstanceOf(typeof(UserApi), instance);
        }

        
        /// <summary>
        /// Test ChangePassword
        /// </summary>
        [Test]
        public void ChangePasswordTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //EmailRequest emailRequest = null;
            //var response = instance.ChangePassword(emailRequest);
            //Assert.IsInstanceOf(typeof(Object), response, "response is Object");
        }
        
        /// <summary>
        /// Test GetMe
        /// </summary>
        [Test]
        public void GetMeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetMe();
            //Assert.IsInstanceOf(typeof(PrivateUserDto), response, "response is PrivateUserDto");
        }
        
        /// <summary>
        /// Test GetRoles
        /// </summary>
        [Test]
        public void GetRolesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetRoles();
            //Assert.IsInstanceOf(typeof(List<string>), response, "response is List<string>");
        }
        
        /// <summary>
        /// Test ListRefreshTokens
        /// </summary>
        [Test]
        public void ListRefreshTokensTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.ListRefreshTokens();
            //Assert.IsInstanceOf(typeof(List<RefreshTokenDto>), response, "response is List<RefreshTokenDto>");
        }
        
        /// <summary>
        /// Test Login
        /// </summary>
        [Test]
        public void LoginTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //LoginDto loginDto = null;
            //var response = instance.Login(loginDto);
            //Assert.IsInstanceOf(typeof(LoginToken), response, "response is LoginToken");
        }
        
        /// <summary>
        /// Test Signup
        /// </summary>
        [Test]
        public void SignupTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //SignUpDto signUpDto = null;
            //var response = instance.Signup(signUpDto);
            //Assert.IsInstanceOf(typeof(Object), response, "response is Object");
        }
        
        /// <summary>
        /// Test UpsertRefreshToken
        /// </summary>
        [Test]
        public void UpsertRefreshTokenTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //CreateTokenDto createTokenDto = null;
            //var response = instance.UpsertRefreshToken(createTokenDto);
            //Assert.IsInstanceOf(typeof(string), response, "response is string");
        }
        
    }

}
