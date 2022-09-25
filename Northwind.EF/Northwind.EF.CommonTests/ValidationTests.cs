using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Common.Tests
{
    [TestClass()]
    public class ValidationTests
    {
        [TestMethod()]
        public void IsValidTestError()
        {
            // Arrange
            var validation = new Validation();
            var input = "Test Validation";
            bool expectedResult = false;
            bool result;

            // Act
            result = validation.IsValid(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void IsValidTestOk()
        {
            // Arrange
            var validation = new Validation();
            var input = "12345";
            bool expectedResult = true;
            bool result;

            // Act
            result = validation.IsValid(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void IsValidStringError()
        {
            // Arrange
            var validation = new Validation();
            string input = null;
            bool expectedResult = false;
            bool result;

            // Act
            result = validation.IsValidString(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void IsValidStringOk()
        {
            // Arrange
            var validation = new Validation();
            string input = "Test Validation";
            bool expectedResult = true;
            bool result;

            // Act
            result = validation.IsValidString(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void NameLongError()
        {
            // Arrange
            var validation = new Validation();
            string input = "Test Validation If Not Specified Length Default = 15 Characters";
            bool expectedResult = false;
            bool result;

            // Act
            result = validation.NameLong(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void NameLongOk()
        {
            // Arrange
            var validation = new Validation();
            var input = "Test Validation";
            bool expectedResult = true;
            bool result;

            // Act
            result = validation.NameLong(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void NameLongOkWithLength()
        {
            // Arrange
            var validation = new Validation();
            string input = "Test Validation If Not Specified Length Default = 15 Characters";
            int length = 100;
            bool expectedResult = true;
            bool result;

            // Act
            result = validation.NameLong(input, length);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GenerateStringIDOk()
        {
            // Arrange
            var validation = new Validation();
            var expectedResult = "";
            string result;

            // Act
            result = validation.GenerateStringID();

            // Assert
            Assert.AreNotEqual(expectedResult, result);
        }
    }
}