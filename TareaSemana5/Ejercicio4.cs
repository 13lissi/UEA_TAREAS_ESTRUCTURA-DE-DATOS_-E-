using System;
using System.Collections.Generic;

namespace TareaSemana5
{
    class Ejercicio4
    {
        public static void Ejecutar()
        {
            List<int> numeros = new List<int>();

            Console.WriteLine("Ingrese 6 números de la lotería:");

            // Lectura de los números
            for (int i = 0; i < 6; i++)
            {
                numeros.Add(int.Parse(Console.ReadLine()));
            }

            // Ordena de menor a mayor
            numeros.Sort();

            Console.WriteLine("Números ordenados:");
            foreach (int n in numeros)
            {
                Console.Write(n + " ");
            }

            Console.WriteLine("\n");
        }
    }
}
