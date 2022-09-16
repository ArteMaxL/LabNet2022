using System.Collections.Generic;

namespace EjercicioPooTransporte
{    
    public abstract class TransportePublico
    {
        public TransportePublico(int numero, int pasajeros)
        {
            Numero = numero;
            Pasajeros = pasajeros;
        }
        public int Numero { get; private set; }
        public int Pasajeros { get; }
        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
