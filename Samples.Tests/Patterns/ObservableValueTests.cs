using Moq;
using Samples.Observer;
using Xunit;

namespace Samples.Tests.Patterns
{
    public class ObservableValueTests
    {
        [Fact]
        public void SubscribeTest()
        {
            var observer = new Mock<IObserver<ObservableValue>>();
            observer.Setup(f => f.OnNext(It.IsAny<ObservableValue>())).Verifiable();
            var obj = new ObservableValue();
            obj.Subscribe(observer.Object);

            obj.CurrentValue = 1;

            observer.Verify();
        }
    }
}