namespace EjercicioPooTransporte
{
    internal class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros)
        {
        }

        public override string Avanzar()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };

            if (Pasajeros > 1)
            {
                return $"Taxi avanzando, con {Pasajeros} {singularPlural[1]} a bordo...";
            }

            return $"Taxi avanzando, con {Pasajeros} {singularPlural[0]} a bordo...";
        }

        public override string Detenerse()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };

            if (Pasajeros > 1)
            {
                return $"Taxi deteniéndose, con {Pasajeros} {singularPlural[1]} a bordo...";
            }

            return $"Taxi deteniéndose, con {Pasajeros} {singularPlural[0]} a bordo...";
        }
        public override string ToString()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };
            if (Pasajeros > 1)
            {
                return $"Taxi con {Pasajeros} {singularPlural[1]}";
            }
            return $"Taxi con {Pasajeros} {singularPlural[0]}";
        }
    }
}
