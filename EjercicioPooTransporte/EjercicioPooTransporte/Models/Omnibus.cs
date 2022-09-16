using System;
using System.Collections.Generic;

namespace EjercicioPooTransporte
{
    public class Omnibus : TransportePublico
    {       
        public Omnibus(int numero, int pasajeros) : base(numero, pasajeros)
        {
        }       
        public override string Avanzar()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };

            if (Pasajeros > 1)
            {
                return $"Omnibus {Numero} avanzando, con {Pasajeros} {singularPlural[1]} a bordo...";
            }
            
            return $"Omnibus {Numero} avanzando, con {Pasajeros} {singularPlural[0]} a bordo...";
        }

        public override string Detenerse()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };

            if (Pasajeros > 1)
            {
                return $"Omnibus {Numero} deteniéndose, con {Pasajeros} {singularPlural[1]} a bordo...";
            }
            
            return $"Omnibus {Numero} deteniéndose, con {Pasajeros} {singularPlural[0]} a bordo...";
        }

        public static void CargaCincoOmnibus(List<TransportePublico> omnibuses)
        {
            int contador = 5;
            int numVehiculo = 1;
            Console.WriteLine("\nA continuación cargaremos los pasajeros de 5 Omnibus");
            while (contador != 0)
            {
                Console.Write($"\nOmnibus {numVehiculo}: ");
                if (!int.TryParse(Console.ReadLine(), out int pasajeros))
                {
                    Console.WriteLine("El valor ingresado no es un número entero válido.");
                    continue;
                }
                else if (pasajeros <= 0)
                {
                    Console.WriteLine("El número debe ser mayor a cero.");
                    continue;
                }
                else
                {
                    omnibuses.Add(new Omnibus(numVehiculo, pasajeros));
                    contador--;
                    numVehiculo++;
                }
            }
        }       
        public override string ToString()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };
            if (Pasajeros > 1)
            {
                return $"Omnibus #{Numero}, con {Pasajeros} {singularPlural[1]}";
            }
            return $"Omnibus #{Numero}, con {Pasajeros} {singularPlural[0]}";
        }        
    }
}
