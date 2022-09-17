using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Poo2ExcepcionesUnitTest
{
    public class MensajeCustom
    {
        public MensajeCustom() {}
        public static List<String> ExcepcionDivisionPorCero(DivideByZeroException dex)
        {
            var mensaje = $"Excepcion de tipo: {dex.GetType()}";
            var chuckFact = "Solo Chuck Norris divide por cero!";
            List<String> result = new List<String>() { mensaje, dex.Message, chuckFact };
            return result;
        }
        public static List<String> ExcepcionFormato(FormatException fex)
        {
            var mensaje = $"Excepcion de tipo: {fex.GetType()}";
            var mensajeCustom = "Seguro Ingreso una letra o no ingreso nada!";
            List<String> result = new List<String>() { mensaje, fex.Message, mensajeCustom };
            return result;
        }
        public static List<String> ExcepcionCustom(Exception ex)
        {
            var mensaje = $"Excepcion de tipo: {ex.GetType()}";
            var chuckFact = "Cuando Chuck Norris lanza excepciones, es al otro lado de la habitacion!";
            List<String> result = new List<String>() { mensaje, ex.Message, chuckFact };
            return result;
        }
        public static void ImprimeExcepcion(List<String> listaExcepcion)
        {
            foreach (var item in listaExcepcion)
            {
                Console.WriteLine($"{item}\n");
            }
        }
    }
}
