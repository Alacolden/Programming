using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Laba1;

namespace Laba1Tests
{
    [TestClass]
    public class ComputerTechnologyTests
    {
        [TestMethod]
        public void Constructor_ValidManufacturer_SetsProperty()
        {
            string manufacturer = "Dell";
            var tech = new ComputerTechnology(manufacturer);

            Assert.AreEqual(manufacturer, tech.Manufacturer);
        }

        [TestMethod]
        public void Print_ValidObject_PrintsManufacturer()
        {
            var tech = new ComputerTechnology("HP");
            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            tech.Print();
            string result = stringWriter.ToString();

            Assert.IsTrue(result.Contains("HP"));
            Assert.IsTrue(result.Contains("Manufacturer"));
        }

        [TestMethod]
        public void Manufacturer_Property_CanBeSetInDerivedClasses()
        {
            var derived = new TestDerivedClass("TestManufacturer");

            Assert.AreEqual("TestManufacturer", derived.Manufacturer);
        }

        private class TestDerivedClass : ComputerTechnology
        {
            public TestDerivedClass(string manufacturer) : base(manufacturer) { }
        }
    }
}