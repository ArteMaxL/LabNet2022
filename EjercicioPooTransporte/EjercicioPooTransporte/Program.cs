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
                Console.WriteLine();
                Console.WriteLine("A continuación cargaremos los pasajeros de 5 Omnibus");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine();
                    Console.Write($"Omnibus {i + 1}: ");
                    var entradaUsuario = int.Parse(Console.ReadLine());
                    omnibuses.Add(new Omnibus(entradaUsuario));
                }
            }

            void CargaCincoTaxis()
            {
                Console.WriteLine();
                Console.WriteLine("A continuación cargaremos los pasajeros de 5 Taxis");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine();
                    Console.Write($"Taxi {i + 1}: ");
                    var entradaUsuario = int.Parse(Console.ReadLine());
                    taxis.Add(new Taxi(entradaUsuario));
                }
            }

            void Print(TransportePublico tp)
            {
                Console.WriteLine(tp);
            }
        }
    }
}
