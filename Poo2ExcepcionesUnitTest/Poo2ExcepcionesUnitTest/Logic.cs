using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poo2ExcepcionesUnitTest
{
    public class Logic
    {
        public static Exception DisparaExcepcion()
        {
            throw new Exception("Disparada desde la Clase Logic\n");
        }
        public static Exception DisparaExcepcionCustom()
        {
            throw new CustomException("Disparada desde la Clase Logic\n");
        }

        public static bool QuiereContinuar()
        {
            Console.Write("\nDesea ejecutar otro Ejercicio?(S/N): ");
            var seleccion = Console.ReadLine().ToLower();
            return (seleccion == "s") ? true : false;
        }
    }
}
