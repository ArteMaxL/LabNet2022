using System;
using System.Collections.Generic;

namespace EjercicioPooTransporte
{
    public class App
    {
        private string seleccion = null;
        private bool esValido = false;

        private string Seleccion { get; set; }

        private static List<TransportePublico> CrearLista()
        {
            List<TransportePublico> lista = new List<TransportePublico>();
            return lista;
        }
        public List<TransportePublico> InicioCarga()
        {
            List<TransportePublico> transportes = CrearLista();
            do
            {
                Console.WriteLine("A continuación cargaremos 10 Transportes Públicos, 5 Omnibus y 5 Taxis\n");
                Console.WriteLine("Presione 'q' si desea salir.");
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
            return transportes;
        }

        public void AvanzaTransporte(List<TransportePublico> tp)
        {
            Console.WriteLine("\nAhora que tenemos pasajeros avancemos...");
            Console.WriteLine("Presione cualquier tecla para continuar...\n");
            Console.ReadKey();

            foreach (TransportePublico item in tp)
            {
                Console.WriteLine($"{item.Avanzar()}\n");
            }

            Console.WriteLine("\nHemos llegado!!. Es hora de detenerse...");
            Console.WriteLine("Presione cualquier tecla para continuar...\n");
            Console.ReadKey();

            foreach (TransportePublico item in tp)
            {
                Console.WriteLine($"{item.Detenerse()}\n");
            }
        }
        public void ImprimeLista(List<TransportePublico> tp)
        {
            Console.WriteLine("\nCargaste: ");
            foreach (TransportePublico transportePublico in tp)
            {
                Console.WriteLine(transportePublico.ToString());
            }
        }
        public void FinPrograma()
        {
            Console.WriteLine("\n=============Fin del Programa=============");
            Console.WriteLine("Presione cualquier tecla para continuar...\n");
            Console.ReadKey();
        }
    }
}
