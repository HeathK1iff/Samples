using Moq;
using Samples.Bridge.Abstractions;
using Samples.Bridge.Implemetations;
using Samples.Bridge.Implemetator;
using Samples.Bridge.Interfaces;

namespace Samples.Tests.Patterns
{
    [TestFixture()]
    public class BridgeTests
    {
        [Test()]
        public void BridgeTest()
        {
            var uriBuilder = new UriBuilder()
            {
                Host = "local"
            };

            var client = new Mock<IClient>();
            client.Setup(f => f.Write(It.IsAny<string>()));
            client.Setup(f => f.Connect(It.IsAny<Uri>()));
            client.Setup(f => f.Disconnect());
            client.Setup(f => f.Read()).Returns("{\"Success\":\"Test\"}");
            ServiceClient serviceClient = new CustomerServiceClient(uriBuilder.Uri, client.Object, new JsonSerializator());
            var response = serviceClient.Send(new CustomerServiceRequest()
            {
                UserName = "Test",
                Password = "password"
            });
            serviceClient.


            Assert.That(response, Is.Not.Null);
            Assert.That(response is CustomerServiceResponse, Is.True);
            Assert.That((response as CustomerServiceResponse).Success.Equals("Test"), Is.True);
        }
    }
}