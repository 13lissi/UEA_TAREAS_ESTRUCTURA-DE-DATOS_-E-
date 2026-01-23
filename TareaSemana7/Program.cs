using System;
using System.Collections.Generic;

namespace TareaSemana7
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1. Verificar fórmula de ejemplo");
                Console.WriteLine("2. Ingresar fórmula para verificar");
                Console.WriteLine("3. Resolver Torres de Hanoi");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        VerificarFormulaEjemplo();
                        break;

                    case 2:
                        VerificarFormulaUsuario();
                        break;

                    case 3:
                        ResolverHanoi();
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 4)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 4);
        }

        // ===== OPCIÓN 1 =====
        static void VerificarFormulaEjemplo()
        {
            string expresion = "{8 + (15 * 7) - [(13 - 7) + (20 + 1)]}";

            Console.WriteLine("Entrada: " + expresion);

            if (VerificadorBalanceo.EstaBalanceada(expresion))
                Console.WriteLine("Salida: Fórmula balanceada.");
            else
                Console.WriteLine("Salida: Fórmula NO balanceada.");
        }

        // ===== OPCIÓN 2 =====
        static void VerificarFormulaUsuario()
        {
            Console.Write("Ingrese la expresión matemática: ");
            string expresion = Console.ReadLine();

            if (VerificadorBalanceo.EstaBalanceada(expresion))
                Console.WriteLine("Salida: Fórmula balanceada.");
            else
                Console.WriteLine("Salida: Fórmula NO balanceada.");
        }

        // ===== OPCIÓN 3 =====
        static void ResolverHanoi()
        {
            Console.Write("Ingrese el número de discos: ");
            int discos = int.Parse(Console.ReadLine());

            Stack<int> origen = new Stack<int>();
            Stack<int> auxiliar = new Stack<int>();
            Stack<int> destino = new Stack<int>();

            for (int i = discos; i >= 1; i--)
                origen.Push(i);

            Console.WriteLine("\nResolución de las Torres de Hanoi:\n");

            TorresHanoi.Resolver(discos, origen, auxiliar, destino,
                                 "Origen", "Auxiliar", "Destino");
        }
    }
}

