using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo2ExcepcionesUnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Divisiones.Division(10);
                throw new Exception();
            }
            catch (DivideByZeroException dex)
            {
                var error = MensajeCustom.ExcepcionDivisionPorCero(dex);
                MensajeCustom.ImprimeExcepcion(error);
            }

            Console.WriteLine("===========Fin del Programa=============");
            Console.WriteLine("Presione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}
