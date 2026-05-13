using Laba1;

namespace Laba1Tests
{
    [TestClass]
    public class MonitorTechTests
    {
        [TestMethod]
        public void Constructor_ValidParameters_SetsAllProperties()
        {
            var resolution = new List<uint> { 1920, 1080 };
            var monitor = new MonitorTech("Samsung", resolution, 27.0f, 144);

            Assert.AreEqual("Samsung", monitor.Manufacturer);
            CollectionAssert.AreEqual(new List<uint> { 1920, 1080 }, monitor.Resolution);
            Assert.AreEqual(27.0f, monitor.ScreenSize);
            Assert.AreEqual(144, monitor.RefreshRate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidResolutionCount_ThrowsException()
        {
            var invalidResolution = new List<uint> { 1920 };
            var monitor = new MonitorTech("Samsung", invalidResolution, 27.0f, 144);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidResolutionValues_ThrowsException()
        {
            var invalidResolution = new List<uint> { 0, 1080 };
            var monitor = new MonitorTech("Samsung", invalidResolution, 27.0f, 144);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidScreenSize_ThrowsException()
        {
            var resolution = new List<uint> { 1920, 1080 };
            var monitor = new MonitorTech("Samsung", resolution, -1.0f, 144);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidRefreshRate_ThrowsException()
        {
            var resolution = new List<uint> { 1920, 1080 };
            var monitor = new MonitorTech("Samsung", resolution, 27.0f, 0);
        }

        [TestMethod]
        public void Resolution_PropertySetter_ValidValue_SetsCorrectly()
        {
            var monitor = new MonitorTech("LG", new List<uint> { 1920, 1080 }, 24.0f, 60);
            var newResolution = new List<uint> { 2560, 1440 };
            monitor.Resolution = newResolution;

            CollectionAssert.AreEqual(newResolution, monitor.Resolution);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Resolution_PropertySetter_InvalidValue_ThrowsException()
        {
            var monitor = new MonitorTech("LG", new List<uint> { 1920, 1080 }, 24.0f, 60);
            var invalidResolution = new List<uint> { 2560, 1440, 2160 };
            monitor.Resolution = invalidResolution;
        }

        [TestMethod]
        public void SetResolution_ValidParameters_SetsCorrectly()
        {
            var monitor = new MonitorTech("Dell", new List<uint> { 1920, 1080 }, 24.0f, 60);
            monitor.SetResolution(3840, 2160);

            CollectionAssert.AreEqual(new List<uint> { 3840, 2160 }, monitor.Resolution);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetResolution_InvalidWidth_ThrowsException()
        {
            var monitor = new MonitorTech("Dell", new List<uint> { 1920, 1080 }, 24.0f, 60);
            monitor.SetResolution(0, 1080);
        }

        [TestMethod]
        public void ScreenSize_PropertySetter_ValidValue_SetsCorrectly()
        {
            var monitor = new MonitorTech("ASUS", new List<uint> { 1920, 1080 }, 24.0f, 60);
            monitor.ScreenSize = 32.5f;

            Assert.AreEqual(32.5f, monitor.ScreenSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ScreenSize_PropertySetter_InvalidValue_ThrowsException()
        {
            var monitor = new MonitorTech("ASUS", new List<uint> { 1920, 1080 }, 24.0f, 60);
            monitor.ScreenSize = 0f;
        }

        [TestMethod]
        public void RefreshRate_PropertySetter_ValidValue_SetsCorrectly()
        {
            var monitor = new MonitorTech("Acer", new List<uint> { 1920, 1080 }, 24.0f, 60);
            monitor.RefreshRate = 240;

            Assert.AreEqual(240, monitor.RefreshRate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RefreshRate_PropertySetter_InvalidValue_ThrowsException()
        {
            var monitor = new MonitorTech("Acer", new List<uint> { 1920, 1080 }, 24.0f, 60);

            monitor.RefreshRate = 0;
        }

        [TestMethod]
        public void Resolution_Property_ReturnsCopyNotReference()
        {
            var originalResolution = new List<uint> { 1920, 1080 };
            var monitor = new MonitorTech("Test", originalResolution, 24.0f, 60);

            var retrievedResolution = monitor.Resolution;
            retrievedResolution[0] = 9999;

            Assert.AreEqual(1920u, monitor.Resolution[0]);
        }
    }
}