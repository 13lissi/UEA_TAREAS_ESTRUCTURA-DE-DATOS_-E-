using System;
using System.Collections.Generic;

namespace TareaSemana7
{
    class TorresHanoi
    {
        /// <summary>
        /// Algoritmo recursivo para resolver Torres de Hanoi usando pilas
        /// </summary>
        public static void Resolver(
            int n,
            Stack<int> origen,
            Stack<int> auxiliar,
            Stack<int> destino,
            string o,
            string a,
            string d)
        {
            if (n == 1)
            {
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {o} a {d}");
                return;
            }

            Resolver(n - 1, origen, destino, auxiliar, o, d, a);

            int discoMovido = origen.Pop();
            destino.Push(discoMovido);
            Console.WriteLine($"Mover disco {discoMovido} de {o} a {d}");

            Resolver(n - 1, auxiliar, origen, destino, a, o, d);
        }
    }
}
