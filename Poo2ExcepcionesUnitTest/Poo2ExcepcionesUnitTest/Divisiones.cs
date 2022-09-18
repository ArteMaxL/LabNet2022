using System;

namespace Poo2ExcepcionesUnitTest
{
    public class Divisiones
    {
        private int dividendo;
        private int divisor;
        public Divisiones() { }
        public int Dividendo { get; set; }
        public int Divisor { get; private set; }

        /// <summary>
        /// Recibe un entero como dividendo y opcionalmente recibe un divisor.
        /// El valor por defecto del divisor es cero para que lance una excepcion.
        /// </summary>
        /// <param name="dividendo"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static double Division(int dividendo, int divisor = 0)
        {
            return dividendo / divisor;
        }
        public static decimal Division(decimal dividendo, decimal divisor = 0)
        {
            var resultado = Math.Round(dividendo / divisor, 2);
            return resultado;
        }
    }
}
