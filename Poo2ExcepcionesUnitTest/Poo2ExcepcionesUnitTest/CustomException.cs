using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo2ExcepcionesUnitTest
{
    public class CustomException : Exception
    {
        public CustomException(string mensaje) : base(mensaje)
        {
        }
    }
}
