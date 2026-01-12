using Samples.Factory;
using Samples.Factory.Device;
using Samples.Factory.Exception;
using Xunit;

namespace Samples.Tests.Patterns
{
    public class FactoryTests
    {
        [Fact]
        public void CreateDevice_PutEmptyModel_ThrowArgumentException()
        {
            IDeviceFactory factory = new XiaomiDeviceFactory();

            Assert.Throws<ArgumentException>(() => factory.CreateDevice(string.Empty));
            Assert.Throws<ArgumentException>(() => factory.CreateDevice(" "));
        }


        [Fact]
        public void CreateDevice_PutNotExistedModel_ThrowClassNotFoundException()
        {
            IDeviceFactory factory = new XiaomiDeviceFactory();

            Assert.Throws<ClassNotFoundException>(() => factory.CreateDevice("XYZ"));
        }

        [Fact]
        public void CreateDevice_PutCorrectModel_True()
        {
            IDeviceFactory factory = new XiaomiDeviceFactory();

            var device = factory.CreateDevice(MCCGQ11LM.ModelName);

            Assert.Equal(XiaomiBaseDevice.VendorName, device.Vendor);
            Assert.Equal(MCCGQ11LM.ModelName, device.Model);
            Assert.True(device is MCCGQ11LM);
        }


    }
}