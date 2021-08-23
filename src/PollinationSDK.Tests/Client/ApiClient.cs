using NUnit.Framework;
using System.Runtime.Serialization;
using PollinationSDK.Client;
using Newtonsoft.Json.Converters;

namespace PollinationSDK.Test
{
    [TestFixture]
    public class SerializationTests
    {
        private enum TestEnum
        {
            /// <summary>
            /// Enum Created for value: created
            /// </summary>
            [EnumMember(Value = "created")]
            Created = 0,

            /// <summary>
            /// Enum Scheduled for value: scheduled
            /// </summary>
            [EnumMember(Value = "scheduled")]
            Scheduled = 1,

            /// <summary>
            /// Enum Running for value: running
            /// </summary>
            [EnumMember(Value = "running")]
            Running = 2,

        }

        private Configuration Configuration { get; set; }


        [SetUp]
        public void InitConfig()
        {
            this.Configuration = new PollinationSDK.Client.Configuration { BasePath = "http://test.com" };
        }

        [Test]
        public void SerializeEnum()
        {
            const TestEnum createdEnum = TestEnum.Running;

            var parametersLength = 0;
            var parameters = this.Configuration.ApiClient.ParameterToKeyValuePairs("single", "foo", createdEnum);

            foreach (var item in parameters)
            {
                parametersLength += 1;
                Assert.IsTrue(item.Key == "foo", "Header should equal foo");
                Assert.IsTrue(item.Value == "running", "It should be a serialized string");
            }

            Assert.IsFalse(parametersLength == 0, "There should only be one parameter");
        }
    }
}