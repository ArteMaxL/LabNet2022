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

            Console.WriteLine("A continuación cargaremos 10 Transportes Públicos, 5 Omnibus y 5 Taxis\n");
            Console.WriteLine("Presione 'q' si desea salir.");

            string seleccion = null;
            bool esValido = false;

            do
            {
                Console.Write("Para comenzar por Omnibus presione 1, para Taxis presione 2: ");
                seleccion = Console.ReadLine();
                esValido = seleccion == "1" || seleccion == "2";
                if (seleccion.ToLower() == "q")
                {
                    seleccion = "q";
                    break;
                }

                if (!esValido)
                {
                    Console.WriteLine($"El valor ingresado '{seleccion}' no es una opción válida.\n");
                }
            } while (!esValido);


            switch (seleccion)
            {
                case "1":
                    CargaCincoOmnibus();
                    CargaCincoTaxis();

                    ImprimeOmnibus(omnibuses);
                    ImprimeTaxis(taxis);

                    break;

                case "2":
                    CargaCincoTaxis();
                    CargaCincoOmnibus();

                    ImprimeTaxis(taxis);
                    ImprimeOmnibus(omnibuses);

                    break;
                case "q":
                    Console.WriteLine("Ha salido del programa.");
                    break;
                default:
                    Console.WriteLine("La opción ingresada no es válida.");
                    break;
            }

            Console.WriteLine("\n=========================================");
            Console.WriteLine("Presione cualquier tecla para terminar...");
            Console.ReadKey();

            void CargaCincoOmnibus()
            {
                int contador = 5;
                int numVehiculo = 1;
                Console.WriteLine("\nA continuación cargaremos los pasajeros de 5 Omnibus");
                while (contador != 0)
                {
                    Console.Write($"\nOmnibus {numVehiculo}: ");
                    if (!int.TryParse(Console.ReadLine(), out int num))
                    {
                        Console.WriteLine("El valor ingresado no es un número entero válido.");
                        continue;
                    }
                    else if (num <= 0)
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
                Console.WriteLine("\nA continuación cargaremos los pasajeros de 5 Taxis");
                while (contador != 0)
                {
                    Console.Write($"\nTaxi {numVehiculo}: ");
                    if (!int.TryParse(Console.ReadLine(), out int num))
                    {
                        Console.WriteLine("El valor ingresado no es un número entero válido.");
                        continue;
                    }
                    else if (num <= 0)
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

            void ImprimeOmnibus(List<Omnibus> om)
            {
                Console.WriteLine("\nLista de Omnibus: ");
                om.ForEach(Print);
            }

            void ImprimeTaxis(List<Taxi> tx)
            {
                Console.WriteLine("\nLista de Taxis: ");
                tx.ForEach(Print);
            }

            void Print(TransportePublico tp)
            {
                Console.WriteLine(tp);
            }
        }
    }
}
