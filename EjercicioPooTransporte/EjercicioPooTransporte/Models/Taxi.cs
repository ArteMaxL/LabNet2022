using System;
using System.Collections.Generic;

namespace EjercicioPooTransporte
{
    internal class Taxi : TransportePublico
    {
        public Taxi(int numero, int pasajeros) : base(numero, pasajeros)
        {
        }

        public override string Avanzar()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };

            if (Pasajeros > 1)
            {
                return $"Taxi #{Numero} avanzando, con {Pasajeros} {singularPlural[1]} a bordo...";
            }

            return $"Taxi #{Numero} avanzando, con {Pasajeros} {singularPlural[0]} a bordo...";
        }

        public override string Detenerse()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };

            if (Pasajeros > 1)
            {
                return $"Taxi #{Numero} deteniéndose, con {Pasajeros} {singularPlural[1]} a bordo...";
            }

            return $"Taxi #{Numero} deteniéndose, con {Pasajeros} {singularPlural[0]} a bordo...";
        }

        public static void CargaCincoTaxis(List<TransportePublico> taxis)
        {
            int contador = 5;
            int numVehiculo = 1;
            int maxPasajeros = 4;
            Console.WriteLine("\nA continuación cargaremos los pasajeros de 5 Taxis");
            while (contador != 0)
            {
                Console.Write($"\nTaxi {numVehiculo}: ");
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
                else if (pasajeros > 4)
                {
                    Console.WriteLine($"Exediste la capacidad máxima de {maxPasajeros} pasajeros!");
                }
                else
                {
                    taxis.Add(new Taxi(numVehiculo, pasajeros));
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
                return $"Taxi #{Numero} con {Pasajeros} {singularPlural[1]}";
            }
            return $"Taxi #{Numero} con {Pasajeros} {singularPlural[0]}";
        }
    }
}
