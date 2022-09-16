using System;
using System.Collections.Generic;

namespace EjercicioPooTransporte
{
    public class Program
    { 
        static void Main(string[] args)
        {
            List<TransportePublico> transportes = new List<TransportePublico>();

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
                    Omnibus.CargaCincoOmnibus(transportes);
                    Taxi.CargaCincoTaxis(transportes);
                    
                    break;
                case "2":
                    Taxi.CargaCincoTaxis(transportes);
                    Omnibus.CargaCincoOmnibus(transportes);

                    break;
                case "q":
                    Console.WriteLine("Ha salido del programa.");
                    break;
                default:
                    Console.WriteLine("La opción ingresada no es válida.");
                    break;
            }

            Console.WriteLine("\nCargaste: ");
            foreach (TransportePublico transportePublico in transportes)
            {
                Console.WriteLine(transportePublico.ToString());
            }

            do { 
            Console.Write("\nPara avanzar con Omnibus presione 1, para Taxis presione 2: ");
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

                Console.WriteLine("\n=========================================");
            Console.WriteLine("Presione cualquier tecla para terminar...");
            Console.ReadKey();
        }
    }
}
