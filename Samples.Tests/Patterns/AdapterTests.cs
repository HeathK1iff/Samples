
using Samples.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Samples.Tests.Patterns
{
    public class AdapterTests
    {
        [Fact]
        public void AdapterTest()
        {
            const string expected = "Test";
            string actual = string.Empty;

            using (Stream stream = new MemoryStream())
            {
                IExternalDevice converter = new StreamExternalDeviceAdapter(stream);
                converter.Write(expected);

                actual = converter.Read();
            }

            Assert.Equal(expected, actual);
        }


    }
}