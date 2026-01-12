using Moq;
using Samples.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Samples.Tests.Patterns
{
    public class MediatorTests
    {
        [Fact]
        public void AlertMediatorTest()
        {
            var alertManager = new Mock<IAlert>();
            alertManager.Setup(f => f.DoAlert()).Verifiable();
            var swither = new Switcher();
            var mediator = new AlertMediator(swither, alertManager.Object);

            swither.SetOn();

            alertManager.Verify();
        }
    }
}