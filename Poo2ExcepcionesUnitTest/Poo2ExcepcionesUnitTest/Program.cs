using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poo2ExcepcionesUnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tPractica ExtensionMethods + Exceptions + Unit Test\n");
            Console.WriteLine("Elija el ejercicio que quiere iniciar (1-4):\n");
            Console.WriteLine("Ejercicio 1\nEjercicio 2\nEjercicio 3\nEjercicio 4");
            Console.Write("\nSeleccion: ");
            var seleccion = Console.ReadLine();
            double real = 0;
            int entero = 0;

            switch (seleccion)
            {
                case "1":
                    Console.WriteLine("1 - Division por cero\n");
                    Console.Write("Ingresa el Dividendo: \n");
                    seleccion = Console.ReadLine();

                    if (double.TryParse(seleccion, out double resultDouble) && (seleccion.Contains(",") || seleccion.Contains(".")))
                    {
                        real = resultDouble;
                        Console.WriteLine(real.GetType());                        
                    }
                    else if (int.TryParse(seleccion, out int resultInt))
                    {
                        entero = resultInt;                        
                    }
                    else
                    {
                        Console.WriteLine("Ingresate un caracter no válido!");
                    }

                    try
                    {
                        Divisiones.Division(entero);
                        var a = 2.1 / 0;
                    }
                    catch (DivideByZeroException dex)
                    {
                        var mensaje = MensajeCustom.ExcepcionDivisionPorCero(dex);
                        MensajeCustom.ImprimeExcepcion(mensaje);
                    }

                    break; 
                default:
                    break;
            }

                

            /*
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
            */
            Console.WriteLine("===========Fin del Programa=============");
            Console.WriteLine("Presione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}
