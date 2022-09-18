using System;
using System.Collections.Generic;

namespace Poo2ExcepcionesUnitTest
{
    public class MensajeCustom
    {
        public MensajeCustom() {}
        public static List<String> ExcepcionDivisionPorCero(DivideByZeroException e)
        {
            var mensaje = $"Excepcion de tipo: {e.GetType()}";
            var chuckFact = "Solo Chuck Norris divide por cero!";
            List<String> result = new List<String>() { mensaje, e.Message, chuckFact };
            return result;
        }
        public static List<String> ExcepcionFormato(FormatException e)
        {
            var mensaje = $"Excepcion de tipo: {e.GetType()}";
            var mensajeCustom = "Seguro Ingreso una letra o no ingreso nada!";
            List<String> result = new List<String>() { mensaje, e.Message, mensajeCustom };
            return result;
        }
        public static List<String> ExcepcionOverflow(OverflowException e)
        {
            var mensaje = $"Excepcion de tipo: {e.GetType()}";
            var chuckFact = "Chuck Norris contó hasta el infinito...dos veces!";
            List<String> result = new List<String>() { mensaje, e.Message, chuckFact };
            return result;
        }
        public static List<String> ExcepcionCustom(CustomException e)
        {
            var mensaje = $"Excepcion de tipo: {e.GetType()}";
            var chuckFact = "Cuando Chuck Norris lanza excepciones, es al otro lado de la habitacion!";
            List<String> result = new List<String>() { mensaje, e.Message, chuckFact };
            return result;
        }

        public static List<String> ExcepcionCustom(Exception e)
        {
            var mensaje = $"Excepcion de tipo: {e.GetType()}";            
            List<String> result = new List<String>() { mensaje, e.Message };
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
