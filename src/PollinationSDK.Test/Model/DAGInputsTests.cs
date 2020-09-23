
using NUnit.Framework;
using System.Linq;
using PollinationSDK.Model;

namespace PollinationSDK.Test
{
    public class DAGInputsTests
    {
        private DAGInputs instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            var path = @"..\..\..\testResources\DAGInputs.json";
            string text = System.IO.File.ReadAllText(path);
            instance = DAGInputs.FromJson(text);
        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of DAGInputs
        /// </summary>
        [Test]
        public void DAGInputsInstanceTest()
        {
            Assert.IsInstanceOf(typeof(DAGInputs), instance);
        }


        /// <summary>
        /// Test the property 'Parameters'
        /// </summary>
        [Test]
        public void ParametersTest()
        {
            Assert.IsTrue(this.instance.Parameters.First().Name == "north");
        }
        /// <summary>
        /// Test the property 'Artifacts'
        /// </summary>
        [Test]
        public void ArtifactsTest()
        {
            Assert.IsTrue(this.instance.Artifacts.First().Name == "model");
        }

        [Test]
        public void DuplicateTest()
        {
            Assert.IsTrue(this.instance.DuplicateDAGInputs().Equals(this.instance));
        }
    }

}
