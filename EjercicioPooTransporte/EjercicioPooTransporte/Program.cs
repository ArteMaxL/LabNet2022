using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPooTransporte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Omnibus> omnibuses = new List<Omnibus>();
            List<Taxi> taxis = new List<Taxi>();

            Console.WriteLine("A continuación cargaremos 10 Transportes Públicos, 5 Omnibus y 5 Taxis");
            Console.Write("Para comenzar por Omnibus presione 1, para Taxis presione 2: ");
            string seleccion = Console.ReadLine();

            switch (seleccion)
            {
                case "1":
                    CargaCincoOmnibus();
                    CargaCincoTaxis();                    
                    Console.WriteLine("\nLista de Omnibus: ");
                    omnibuses.ForEach(Print);                    
                    Console.WriteLine("\nLista de Taxis: ");
                    taxis.ForEach(Print);
                    break;
                case "2":
                    CargaCincoTaxis();
                    CargaCincoOmnibus();
                    Console.WriteLine("\nLista de Taxis: ");
                    taxis.ForEach(Print);
                    Console.WriteLine("\nLista de Omnibus: ");
                    omnibuses.ForEach(Print);
                    break;
                default:
                    Console.WriteLine("La opción ingresada no es válida.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("==========================");
            Console.WriteLine("Presione cualquier tecla para terminar...");
            Console.ReadKey();

            void CargaCincoOmnibus()
            {
                int contador = 5;
                int numVehiculo = 1;
                Console.WriteLine();
                Console.WriteLine("A continuación cargaremos los pasajeros de 5 Omnibus");
                while (contador!= 0)
                {
                    Console.WriteLine();
                    Console.Write($"Omnibus {numVehiculo}: ");
                    if (!int.TryParse(Console.ReadLine(), out int num))
                    {
                        Console.WriteLine("El valor ingresado no es un número entero válido.");
                        continue;
                    }
                    else if (num == 0)
                    {
                        Console.WriteLine("El número debe ser mayor a cero.");
                        continue;
                    }
                    else
                    {
                        omnibuses.Add(new Omnibus(num));
                        contador--;
                        numVehiculo++;
                    }
                }
            }

            void CargaCincoTaxis()
            {
                int contador = 5;
                int numVehiculo = 1;
                Console.WriteLine();
                Console.WriteLine("A continuación cargaremos los pasajeros de 5 Taxis");
                while (contador != 0)
                {
                    Console.WriteLine();
                    Console.Write($"Taxi {numVehiculo}: ");
                    if (!int.TryParse(Console.ReadLine(), out int num))
                    {
                        Console.WriteLine("El valor ingresado no es un número entero válido.");
                        continue;
                    }
                    else if (num == 0)
                    {
                        Console.WriteLine("El número debe ser mayor a cero.");
                        continue;
                    }
                    else
                    {
                        taxis.Add(new Taxi(num));
                        contador--;
                        numVehiculo++;
                    }
                }
            }

            void Print(TransportePublico tp)
            {
                Console.WriteLine(tp);
            }
        }
    }
}
