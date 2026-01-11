using System;

namespace TareaSemana5
{
    class Ejercicio8
    {
        public static void Ejecutar()
        {
            Console.Write("Ingrese una palabra: ");
            string palabra = (Console.ReadLine() ?? "").ToLower();
            // Invierte la palabra
            char[] letras = palabra.ToCharArray();
            Array.Reverse(letras);
            string palabraInvertida = new string(letras);

            // Verifica si es palíndromo
            if (palabra == palabraInvertida)
                Console.WriteLine("Es un palíndromo");
            else
                Console.WriteLine("No es un palíndromo");

            Console.WriteLine();
        }
    }
}
