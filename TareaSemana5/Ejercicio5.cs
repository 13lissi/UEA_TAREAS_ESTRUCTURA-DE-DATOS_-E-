using System;
using System.Collections.Generic;

namespace TareaSemana5
{
    class Ejercicio5
    {
        public static void Ejecutar()
        {
            List<int> numeros = new List<int>();

            // Guarda los números del 1 al 10
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }

            // Invierte el orden de la lista
            numeros.Reverse();

            Console.WriteLine("Números en orden inverso:");
            Console.WriteLine(string.Join(", ", numeros));
            Console.WriteLine();
        }
    }
}
