namespace EjercicioPooTransporte
{
    public abstract class TransportePublico
    {
        public TransportePublico(int pasajeros)
        {
            Pasajeros = pasajeros;
        }
        public int Pasajeros { get; }
        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
