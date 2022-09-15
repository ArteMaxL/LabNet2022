namespace EjercicioPooTransporte
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros) : base(pasajeros)
        {
        }

        public override string Avanzar()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };

            if (Pasajeros > 1)
            {
                return $"Omnibus avanzando, con {Pasajeros} {singularPlural[1]} a bordo...";
            }
            
            return $"Omnibus avanzando, con {Pasajeros} {singularPlural[0]} a bordo...";
        }

        public override string Detenerse()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };

            if (Pasajeros > 1)
            {
                return $"Omnibus deteniéndose, con {Pasajeros} {singularPlural[1]} a bordo...";
            }
            
            return $"Omnibus deteniéndose, con {Pasajeros} {singularPlural[0]} a bordo...";
        }

        public override string ToString()
        {
            string[] singularPlural = { "pasajero", "pasajeros" };
            if (Pasajeros > 1)
            {
                return $"Omnibus con {Pasajeros} {singularPlural[1]}";
            }
            return $"Omnibus con {Pasajeros} {singularPlural[0]}";
        }
    }
}
