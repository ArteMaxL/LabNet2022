using Northwind.EF.UI;
using Northwind.Linq.Entities;
using Northwind.Linq.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Linq.UI
{
    public class App
    {
        public App() { }

        public void MainMenu()
        {
            Start();
        }

        private static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════════════════════╗");
                Console.WriteLine("║======== Querys con LINQ ========║");
                Console.WriteLine("╠═════════════════════════════════╣");
                Console.WriteLine("║ 1 - Ejercicios Obligatorios.    ║");
                Console.WriteLine("╠═════════════════════════════════╣");
                Console.WriteLine("║ 2 - Ejercicios Opcionales.      ║");
                Console.WriteLine("╠═════════════════════════════════╣");
                Console.WriteLine("║ 0 - Salir.                      ║");
                Console.WriteLine("╚═════════════════════════════════╝");
                Console.Write("\nChoice: ");

                var choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Obligatorios();
                        break;
                    case "2":
                        Opcionales();
                        break;
                    case "0":
                        Console.WriteLine("\n========== Programa Finalizado ============");
                        Thread.Sleep(1500);
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        private static void Obligatorios()
        {
            var obligatorios = new ObligatoriosUI();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║===================================== Ejercicios Obligatorios Consultas con LINQ =====================================║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 1 - Objeto customer.                                                                                                 ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 2 - Todos los productos sin stock.                                                                                   ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 3 - Todos los productos que tienen stock y que cuestan más de 3 por unidad.                                          ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 4 - Todos los customers de la Región WA.                                                                             ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 5 - Primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789.                        ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 6 - Nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.                                                 ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 7 - Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997. ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 0 - Volver al Menu Principal.                                                                                                            ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.Write("\nChoice: ");

                var choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        obligatorios.Ejercicio1();
                        break;
                    case "2":
                        obligatorios.Ejercicio2();
                        break;
                    case "3":
                        obligatorios.Ejercicio3();
                        break;
                    case "4":
                        obligatorios.Ejercicio4();
                        break;
                    case "5":
                        obligatorios.Ejercicio5();
                        break;
                    case "6":
                        obligatorios.Ejercicio6();
                        break;
                    case "7":
                        obligatorios.Ejercicio7();
                        break;
                    case "0":
                        Start();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void Opcionales()
        {
            var opcionales = new OpcionalesUI();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║===================================== Ejercicios Opcionales Consultas con LINQ =====================================║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 1 - Primeros 3 Customers de la Región WA.                                                                          ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 2 - Lista de productos ordenados por nombre.                                                                       ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 3 - Lista de productos ordenados por unit in stock de mayor a menor.                                               ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 4 - Categorías asociadas a los productos.                                                                          ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 5 - Primer elemento de una lista de productos.                                                                     ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 6 - Devolver los Customer con la cantidad de ordenes asociadas.                                                    ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 0 - Volver al Menu Principal.                                                                                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.Write("\nChoice: ");

                var choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        opcionales.Ejercicio1();
                        break;
                    case "2":
                        opcionales.Ejercicio2();
                        break;
                    case "3":
                        opcionales.Ejercicio3();
                        break;
                    case "4":
                        opcionales.Ejercicio4();
                        break;
                    case "5":
                        opcionales.Ejercicio5();
                        break;
                    case "6":
                        opcionales.Ejercicio6();
                        break;
                    case "0":
                        Start();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
