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
            bool salida = false;
            while (!salida)
            {
                Console.Clear();
                Console.WriteLine("\tPractica ExtensionMethods + Exceptions + Unit Test\n");
                Console.WriteLine("Elija el ejercicio que quiere iniciar (1-4):\n");
                Console.WriteLine("Ejercicio 1\nEjercicio 2\nEjercicio 3\nEjercicio 4");
                Console.Write("\nSeleccion: ");
                var seleccion = Console.ReadLine();
                bool esEntero = true;

                switch (seleccion)
                {
                    case "1":
                        Console.WriteLine("1 - Division por cero\n");
                        Console.Write("Ingresa el Dividendo: \n");
                        seleccion = Console.ReadLine();

                        char[] seleccionTipo = seleccion.ToCharArray();

                        for (int i = 0; i < seleccionTipo.Length; i++)
                        {
                            if (seleccionTipo[i] == '.')
                            {
                                esEntero = false;
                            }
                            else if (seleccionTipo[i] == ',')
                            {
                                esEntero = false;
                            }
                        }

                        try
                        {
                            if (esEntero)
                            {
                                var numero = Convert.ToInt32(seleccion);
                                Console.WriteLine("\nIngresaste un numero entero!\n");
                                Divisiones.Division(numero);
                            }
                            else
                            {
                                var numero = Convert.ToDecimal(seleccion);
                                Console.WriteLine("\nIngresaste un numero decimal!\n");
                                var a = Divisiones.Division(numero);
                                Console.WriteLine(a);
                            }
                        }
                        catch (FormatException e)
                        {
                            var mensaje = MensajeCustom.ExcepcionFormato(e);
                            MensajeCustom.ImprimeExcepcion(mensaje);
                        }
                        catch (DivideByZeroException e)
                        {
                            var mensaje = MensajeCustom.ExcepcionDivisionPorCero(e);
                            MensajeCustom.ImprimeExcepcion(mensaje);
                        }
                        catch (OverflowException e)
                        {
                            var mensaje = MensajeCustom.ExcepcionOverflow(e);
                            MensajeCustom.ImprimeExcepcion(mensaje);
                        }
                        catch (Exception e)
                        {
                            var mensaje = MensajeCustom.ExcepcionCustom(e);
                            MensajeCustom.ImprimeExcepcion(mensaje);
                        }
                        
                        salida = !Logic.QuiereContinuar();
                        break;

                    case "2":
                        Console.WriteLine("2 - Division con dos ingresos\n");
                        Console.Write("Ingresa el Dividendo: \n");
                        seleccion = Console.ReadLine();
                        Console.Write("Ingresa el Divisor: \n");
                        var seleccion2 = Console.ReadLine();

                        if (seleccion.Contains("."))
                        {
                            seleccion = seleccion.Replace(".", ",");
                        }

                        if (seleccion2.Contains("."))
                        {
                            seleccion2 = seleccion2.Replace(".", ",");
                        }

                        try
                        {
                            var numero1 = Convert.ToDecimal(seleccion);
                            var numero2 = Convert.ToDecimal(seleccion2);
                            var a = Divisiones.Division(numero1, numero2);
                            Console.WriteLine($"El resultado de dividir {numero1} / {numero2} es = {a}");                            
                        }
                        catch (FormatException e)
                        {
                            var mensaje = MensajeCustom.ExcepcionFormato(e);
                            MensajeCustom.ImprimeExcepcion(mensaje);
                        }
                        catch (DivideByZeroException e)
                        {
                            var mensaje = MensajeCustom.ExcepcionDivisionPorCero(e);
                            MensajeCustom.ImprimeExcepcion(mensaje);
                        }
                        catch (OverflowException e)
                        {
                            var mensaje = MensajeCustom.ExcepcionOverflow(e);
                            MensajeCustom.ImprimeExcepcion(mensaje);
                        }
                        catch (Exception e)
                        {
                            var mensaje = MensajeCustom.ExcepcionCustom(e);
                            MensajeCustom.ImprimeExcepcion(mensaje);
                        }

                        salida = !Logic.QuiereContinuar();
                        break;

                    case "3":
                        Console.WriteLine("3 - Dispara Excepcion desde clase Logic\n");

                        try
                        {
                            Logic.DisparaExcepcion();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        salida = !Logic.QuiereContinuar();
                        break;

                    case "4":
                        Console.WriteLine("4 - Dispara Excepcion Custom desde clase Logic\n");

                        try
                        {
                            Logic.DisparaExcepcionCustom();
                        }
                        catch (CustomException e)
                        {
                            var mensaje = MensajeCustom.ExcepcionCustom(e);
                            MensajeCustom.ImprimeExcepcion(mensaje);
                        }

                        salida = !Logic.QuiereContinuar();
                        break;

                    default:
                        Console.WriteLine("No te conviene hace enojar a Chuck Norris!.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }

            }
            Console.WriteLine("\n===========Fin del Programa=============");
            Console.WriteLine("Presione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}