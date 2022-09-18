using System;
using System.Collections.Generic;

namespace Poo2ExcepcionesUnitTest
{
    public class Logic
    {
        public static Exception DisparaExcepcion()
        {
            throw new Exception("Disparada desde la Clase Logic\n");
        }
        public static Exception DisparaExcepcionCustom()
        {
            throw new CustomException("Disparada desde la Clase Logic\n");
        }

        public static bool QuiereContinuar()
        {
            Console.Write("\nDesea ejecutar otro Ejercicio?(S/N): ");
            var seleccion = Console.ReadLine().ToLower();
            return (seleccion == "s") ? true : false;
        }

        public static string ChuckNorrisFacts()
        {
            List<string> list = new List<string>() {
            "Todas las matrices que Chuck Norris declara son de tamaño infinito, porque Chuck Norris no conoce límites",
            "Chuck Norris no tiene latencia de disco porque el disco duro sabe apurar el infierno.",
            "Chuck Norris escribe código que se optimiza a sí mismo.",
            "Chuck Norris no puede hacer Test.equality porque no tiene igual.",
            "Chuck Norris no necesita recolección de basura porque no llama. Dispose(), él llama. DropKick().",
            "Chuck Norris reventó la burbuja de las puntocom.",
            "Todos los navegadores admiten las definiciones hexadecimales #chuck y #norris para los colores negro y azul.",
            "MySpace en realidad no es tu espacio, es el de Chuck (solo te deja usarlo...de la vieja escuela).",
            "Chuck Norris puede escribir infinitas funciones de recursión... y que regresen.",
            "Chuck Norris puede resolver las Torres de Hanoi en un solo movimiento.",
            "Chuck Norris terminó World of Warcraft.",
            "Chuck Norris no utiliza estándares web ya que la web se ajustará a él.",
            "\"Funciona en mi máquina\" siempre es cierto para Chuck Norris.",
            "Chuck Norris puede eliminar la papelera de reciclaje.",
            "La barba de Chuck Norris puede escribir 140 palabras por minuto.",
            "Chuck Norris puede probar unitariamente aplicaciones enteras con una sola afirmación.",
            "El teclado de Chuck Norris no tiene una tecla Ctrl porque nada controla a Chuck Norris.",
            "Cuando Chuck Norris navega por la web, los sitios web reciben el mensaje \"Advertencia: Internet Explorer ha considerado que este usuario es malicioso o peligroso. ¿Proceder?\"."
            };

            int randIndex = rnd.Next(list.Count);

            return list[randIndex];
        }
        private static Random rnd = new Random();
    }
}
