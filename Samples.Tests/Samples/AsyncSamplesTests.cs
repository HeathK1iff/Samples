using Moq;
using Newtonsoft.Json.Linq;
using Samples.Async;
using System.Diagnostics;
using Xunit;

namespace Samples.Tests.Async
{
    public class AsyncSamplesTests
    {
        [Fact]
        public void SomeWork10SecAsync_ReadWith6SecReadTimeOut_Throw()
        {
            var worker = new AsyncTimeOutWorker();
            Assert.Throws<TimeoutException>(() => {

                try
                {
                    int result = worker.SomeWork10SecAsync(TimeSpan.FromSeconds(6)).Result;
                } catch (AggregateException ex)
                {
                    throw ex.InnerException ?? new Exception();
                }
                
            });
        }
        [Fact]
        public async Task SomeWork10SecAsync_ReadWith11SecReadTimeOut_True()
        {
            var reader = new AsyncTimeOutWorker();

            Stopwatch sw = new Stopwatch();
            sw.Start(); 
            int value = await reader.SomeWork10SecAsync(TimeSpan.FromSeconds(12));
            sw.Stop();

            Assert.True(value == 999);
            Assert.True(sw.ElapsedMilliseconds > TimeSpan.FromSeconds(10).Milliseconds);
        }

        [Fact]
        public async Task GetWorkDataAsync_ReturnValueFromInterface_True()
        {
            var mock = new Mock<IAsyncTimeOutWorker>();
            mock.Setup(f=>f.SomeWork10SecAsync(It.IsAny<TimeSpan>())).Returns(Task<int>.FromResult(999));
            var service = new TimeOutService(mock.Object);

            int result = await service.GetWorkDataAsync();

            Assert.True(result == 999);
        }

        [Fact]
        public async Task GetWorkDataAsync_ThrowTimeOutExceptionFromInterface_Throw()
        {
            var mock = new Mock<IAsyncTimeOutWorker>();
            mock.Setup(f => f.SomeWork10SecAsync(It.IsAny<TimeSpan>()))
                .Returns(Task<int>.FromException<int>(new TimeoutException()));
            var service = new TimeOutService(mock.Object);
           
            Assert.Throws<AggregateException>(() => service.GetWorkDataAsync().Wait());
        }

    }
}
