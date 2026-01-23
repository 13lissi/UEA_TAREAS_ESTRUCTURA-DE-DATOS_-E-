using System;
using System.Collections.Generic;

namespace TareaSemana7
{
    class TorresHanoi
    {
       
        /// Algoritmo recursivo para resolver Torres de Hanoi usando pilas
        
        public static void Resolver(
            int n,
            Stack<int> origen,
            Stack<int> auxiliar,
            Stack<int> destino,
            string o,
            string a,
            string d)
        {
            // Caso base: si solo hay un disco, se mueve directamente
            if (n == 1)
            {
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {o} a {d}");
                return;
            }

            // Pamos n-1 discos a la torre auxiliar
            Resolver(n - 1, origen, destino, auxiliar, o, d, a);

            // Mover el disco restante a la torre destino
            int discoMovido = origen.Pop();
            destino.Push(discoMovido);
            Console.WriteLine($"Mover disco {discoMovido} de {o} a {d}");

            // Mover los n-1 discos desde la torre auxiliar a la torre destino
            Resolver(n - 1, auxiliar, origen, destino, a, o, d);
        }
    }
}
