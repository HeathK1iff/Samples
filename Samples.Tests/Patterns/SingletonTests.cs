using Samples.Singleton;
using Xunit;

namespace Samples.Tests.Patterns
{
    public class SingletonTests
    {
        [Fact]
        public void PlusTest()
        {
            double expected = 15.0;
            double actual = Calculator.Instance.Plus(10, 5);

            Assert.Equal(expected, actual);
        }
    }
}