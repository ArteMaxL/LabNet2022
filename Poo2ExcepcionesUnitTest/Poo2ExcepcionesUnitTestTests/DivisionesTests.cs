using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Poo2ExcepcionesUnitTest.Tests
{
    [TestClass()]
    public class DivisionesTests
    {
        [TestMethod()]
        public void DivisionTestEnteroOk()
        {
            // Arrange
            int numero1 = 8;
            int numero2 = 4;
            int resultadoEsperado = 2;
            double resultado = 0;

            // Act
            resultado = Divisiones.Division(numero1, numero2);

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod()]
        public void DivisionTestEnteroFailed()
        {
            // Arrange
            int numero1 = 8;
            int numero2 = 4;
            int resultadoEsperado = 3;
            double resultado = 0;

            // Act
            resultado = Divisiones.Division(numero1, numero2);

            // Assert
            Assert.AreNotEqual(resultadoEsperado, resultado);
        }

        [TestMethod()]
        public void DivisionTestDecimalOk()
        {
            // Arrange
            decimal numero1 = 18.62M;
            decimal numero2 = 2.5M;
            decimal resultadoEsperado = 7.45M;
            decimal resultado = 0;

            // Act
            resultado = Divisiones.Division(numero1, numero2);

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod()]
        public void DivisionTestDecimalFailed()
        {
            // Arrange
            decimal numero1 = 18.62M;
            decimal numero2 = 2.5M;
            decimal resultadoEsperado = 7.15M;
            decimal resultado = 0;

            // Act
            resultado = Divisiones.Division(numero1, numero2);

            // Assert
            Assert.AreNotEqual(resultadoEsperado, resultado);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionPorCero()
        {
            // Arrange
            int numero1 = 3;
            double resultado;

            // Act
            resultado = Divisiones.Division(numero1);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void DivisionPorCeroFormato()
        {
            // Arrange
            string numero1 = "cuatro";
            double resultado;

            // Act
            resultado = Divisiones.Division(Convert.ToInt32(numero1));
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void DivisionIngresoOverflow()
        {
            // Arrange
            string numero1 = "327946397485289572984758925";
            double resultado;

            // Act
            resultado = Divisiones.Division(Convert.ToInt32(numero1));
        }
    }
}