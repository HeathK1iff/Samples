using AutoFixture;
using AutoFixture.Kernel;
using Moq;
using Samples.Bridge.Abstractions;
using Samples.Bridge.Dto;
using Samples.Bridge.Implemetations;
using Samples.Bridge.Implemetator;
using System.Text;
using Xunit;

namespace Samples.Tests.Patterns;

public class BridgeTests
{
    [Fact]
    public async Task AuthenticateAsync_CheckReturnValueIfSuccess_ShouldBeTrue()
    {
        //Arrange
        var fixture = new Fixture();
        const string ResponseJson = "{ \"Success\":\"success\" }";
        var mockClientImp = new Mock<ServiceClientImpl>();
        mockClientImp.Setup(m => m.IsAvailableService())
            .Returns(true);
        mockClientImp.Setup(m => m.SendAsync(It.Is<CheckCredentialRequest>(a => a.UserName == "Login" && a.Password == "Password")))
            .ReturnsAsync((CheckCredentialRequest _) => new MemoryStream(Encoding.UTF8.GetBytes(ResponseJson)));

        fixture.Freeze<ServiceClientImpl>(c => c.FromFactory(() => mockClientImp.Object));
        fixture.Freeze<Serializator>(_ => _.FromFactory(() => new JsonSerializator()));

        var request = fixture
            .Build<CheckCredentialRequest>()
            .With(p => p.UserName, "Login")
            .With(p => p.Password, "Password")
            .Create();

        var mockSerializator = fixture.Freeze<Mock<Serializator>>();
        mockSerializator.Setup(p => p.Deserialize<ServiceResponseBase>(ResponseJson))
            .Returns(new ServiceResponseBase() { Success = "success" });

        var sut = fixture.Create<ServiceClient>();

        //Act
        var actual = await sut.AuthenticateAsync(request);

        //Assert
        mockClientImp.Verify();
        Xunit.Assert.True(actual);
    }

    [Fact]
    public async Task AuthenticateAsync_CheckIfServiceUnavailable_ShouldException()
    {
        //Arrange
        var fixture = new Fixture();
        const string ResponseJson = "{ \"Success\":\"success\" }";
        var mockClientImp = new Mock<ServiceClientImpl>();
        mockClientImp.Setup(m => m.IsAvailableService())
            .Returns(false);
        mockClientImp.Setup(m => m.SendAsync(It.Is<CheckCredentialRequest>(a => a.UserName == "Login" && a.Password == "Password")))
            .ReturnsAsync((CheckCredentialRequest _) => new MemoryStream(Encoding.UTF8.GetBytes(ResponseJson)));

        fixture.Freeze<ServiceClientImpl>(c => c.FromFactory(() => mockClientImp.Object));
        fixture.Freeze<Serializator>(_ => _.FromFactory(() => new JsonSerializator()));

        var request = fixture
            .Build<CheckCredentialRequest>()
            .With(p => p.UserName, "Login")
            .With(p => p.Password, "Password")
            .Create();

        var mockSerializator = fixture.Freeze<Mock<Serializator>>();
        mockSerializator.Setup(p => p.Deserialize<ServiceResponseBase>(ResponseJson))
            .Returns(new ServiceResponseBase() { Success = "success" });

        var sut = fixture.Create<ServiceClient>();

        //Act
        var actual = await Record.ExceptionAsync(async () => await sut.AuthenticateAsync(request));

        //Assert
        Assert.True(actual is InvalidOperationException);
    }
}