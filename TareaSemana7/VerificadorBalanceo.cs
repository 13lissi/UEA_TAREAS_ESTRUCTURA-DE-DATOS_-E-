using System;
using System.Collections.Generic;

namespace TareaSemana7
{
    class VerificadorBalanceo
    {
        /// Verifica si los símbolos están correctamente balanceados
       
        public static bool EstaBalanceada(string expresion)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char c in expresion)
            {
                // Push: símbolos de apertura
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                // Verificación de símbolos de cierre
                else if (c == ')' || c == '}' || c == ']')
                {
                    // Si no hay apertura previa
                    if (pila.Count == 0)
                    {
                        Console.WriteLine($"Error: cierre '{c}' sin apertura previa.");
                        return false;
                    }

                    // Peek: observamos sin eliminar
                    char tope = pila.Peek();

                    if (!SonPareja(tope, c))
                    {
                        Console.WriteLine($"Error: '{tope}' no coincide con '{c}'.");
                        return false;
                    }

                    // Pop solo si es correcto
                    pila.Pop();
                }
            }

            // Si quedaron símbolos sin cerrar
            if (pila.Count > 0)
            {
                Console.WriteLine($"Error: símbolo '{pila.Peek()}' sin cerrar.");
                return false;
            }

            return true;
        }

        static bool SonPareja(char apertura, char cierre)
        {
            return (apertura == '(' && cierre == ')') ||
                   (apertura == '[' && cierre == ']') ||
                   (apertura == '{' && cierre == '}');
        }
    }
}
