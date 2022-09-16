using System;

namespace EjercicioPooTransporte
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            var carga = app.InicioCarga();

            if (carga.Count > 0)
            {
                app.ImprimeLista(carga);

                Console.WriteLine("\nAhora que tenemos pasajeros avancemos...");
                Console.WriteLine("Presione cualquier tecla para continuar...\n");
                Console.ReadKey();

                foreach (TransportePublico item in carga)
                {
                    Console.WriteLine($"{item.Avanzar()}\n");
                }

                Console.WriteLine("\nHemos llegado!!. Es hora de detenerse...");
                Console.WriteLine("Presione cualquier tecla para continuar...\n");
                Console.ReadKey();

                foreach (TransportePublico item in carga)
                {
                    Console.WriteLine($"{item.Detenerse()}\n");
                }

                app.FinPrograma();
            }
            else
            {
                app.FinPrograma();
            }
        }
    }
}
