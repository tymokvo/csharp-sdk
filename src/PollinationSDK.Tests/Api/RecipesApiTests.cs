using System;
using System.Linq;
using NUnit.Framework;
using PollinationSDK.Api;
using QueenbeeSDK;

namespace PollinationSDK.Test
{
    [TestFixture]
    public class RecipesApiTests
    {
        private RecipesApi api;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            api = new RecipesApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test ListRecipeTags
        /// </summary>
        [Test]
        public void ListRecipeTagsTest()
        {
            var response = api.ListRecipeTags("ladybug-tools", "annual-energy-use").Resources;
            foreach (var item in response)
            {
                var meta = item.Manifest.Metadata;
                Console.WriteLine($"{meta.Name}: {item.Tag}");
                Assert.IsTrue(item.Tag.ToLower() != "latest");
            }
            Assert.IsTrue(response.Any());
        }
        
        /// <summary>
        /// Test ListRecipes
        /// </summary>
        [Test]
        public void ListRecipesTest()
        {
            var response = api.ListRecipes().Resources;
            foreach (var item in response)
            {
                Console.WriteLine($"{item.Owner.Name}/{item.Name}: {item.LatestTag}");
                Assert.IsTrue(item.LatestTag.ToLower() != "latest");
            }
            Assert.IsTrue(response.Any());
        }

        [Test]
        public void GetRecipeParametersTest()
        {
            var rec = api.GetRecipeByTag("ladybug-tools", "annual-energy-use", "latest").Manifest;

            var inputs = rec.Inputs.OfType<QueenbeeSDK.GenericInput>();
            foreach (var item in inputs)
            {
                Console.WriteLine($"{item.Name}: {item.Type}");
            }
            Assert.IsTrue(inputs.Any());
            

        }
    }

}
