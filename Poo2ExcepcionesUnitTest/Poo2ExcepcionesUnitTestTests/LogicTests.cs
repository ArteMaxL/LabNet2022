using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Poo2ExcepcionesUnitTest.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DisparaExcepcionTest()
        {
            // Act
            Logic.DisparaExcepcion();
        }

        [TestMethod()]
        [ExpectedException(typeof(CustomException))]
        public void DisparaExcepcionCustom()
        {
            // Act
            Logic.DisparaExcepcionCustom();
        }

        [TestMethod()]
        public void ChuckNorrisFactsTest()
        {
            // Arrange
            string resultadoEsperado = "";
            string resultado;

            // Act
            resultado = Logic.ChuckNorrisFacts();

            // Assert
            Assert.IsInstanceOfType(resultadoEsperado, typeof(string));
        }
    }
}