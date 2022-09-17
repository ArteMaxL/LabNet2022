using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poo2ExcepcionesUnitTest
{
    public class Logic
    {
        public static void DisparaExcepcion(Exception ex)
        {
            Console.WriteLine("Disparada desde la Clase Logic\n");
            MensajeCustom.ExcepcionCustom(ex);
        }
    }
}
