using Moq;
using Samples.Command;
using Xunit;

namespace Samples.Tests.Patterns
{   
    public class CommandTests
    {
        [Fact]
        public void CommandTest()
        {
            var lamp = new Mock<ILamp>();
            lamp.Setup(f => f.SetOn()).Verifiable();

            var invoker = new CommandInvoker();
            invoker.SetCommand(new LedOnCommand(lamp.Object));
            invoker.InvokeAll();
            
            lamp.Verify();
        }
    }
}