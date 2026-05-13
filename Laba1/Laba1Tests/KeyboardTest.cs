using Laba1;

namespace Laba1Tests
{
    [TestClass]
    public class KeyboardTests
    {
        [TestMethod]
        public void Constructor_ValidParameters_SetsAllProperties()
        {
            var keyboard = new Keyboard("Logitech", "Black", "mechanical", "wired", true);

            Assert.AreEqual("Logitech", keyboard.Manufacturer);
            Assert.AreEqual("Black", keyboard.Color);
            Assert.IsTrue(keyboard.HasBacklight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidColor_ThrowsException()
        {
            var keyboard = new Keyboard("Logitech", "Black123", "mechanical", "wired", true);
        }

        [TestMethod]
        public void Constructor_AllKeyTypes_ParsedCorrectly()
        {
            var membrane = new Keyboard("A", "B", "membrane", "wired", true);
            var mechanical = new Keyboard("A", "B", "mechanical", "wired", true);
            var optical = new Keyboard("A", "B", "optical", "wired", true);
            var none = new Keyboard("A", "B", "invalid", "wired", true);
        }

        [TestMethod]
        public void Constructor_AllConnectionTypes_ParsedCorrectly()
        {
            var wired = new Keyboard("A", "B", "mechanical", "wired", true);
            var wireless = new Keyboard("A", "B", "mechanical", "wireless", true);
            var none = new Keyboard("A", "B", "mechanical", "invalid", true);
        }

        [TestMethod]
        [DataRow("membrane")]
        [DataRow("mechanical")]
        [DataRow("optical")]
        [DataRow("MEMBRANE")]
        [DataRow("Mechanical")]
        public void Constructor_ValidKeyTypes_WorksCorrectly(string keyType)
        {
            var keyboard = new Keyboard("Test", "Black", keyType, "wired", true);
            Assert.IsNotNull(keyboard);
        }

        [TestMethod]
        [DataRow("wired")]
        [DataRow("wireless")]
        [DataRow("WIRED")]
        [DataRow("Wireless")]
        public void Constructor_ValidConnectionTypes_WorksCorrectly(string connectionType)
        {
            var keyboard = new Keyboard("Test", "Black", "mechanical", connectionType, true);
            Assert.IsNotNull(keyboard);
        }

        [TestMethod]
        public void Color_PropertySetter_ValidColor_SetsCorrectly()
        {
            var keyboard = new Keyboard("Test", "Red", "mechanical", "wired", true);
            Assert.AreEqual("Red", keyboard.Color);
        }

        [TestMethod]
        public void HasBacklight_Property_CanBeSetInConstructor()
        {
            var withBacklight = new Keyboard("A", "B", "mechanical", "wired", true);
            var withoutBacklight = new Keyboard("A", "B", "mechanical", "wired", false);

            Assert.IsTrue(withBacklight.HasBacklight);
            Assert.IsFalse(withoutBacklight.HasBacklight);
        }
    }
}