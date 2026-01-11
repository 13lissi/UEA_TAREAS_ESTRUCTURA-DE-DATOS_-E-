using System;
using System.Collections.Generic;
using System.Linq;

namespace TareaSemana5
{
    class Ejercicio13
    {
        public static void Ejecutar()
        {
            Console.Write("Ingrese números separados por comas: ");
            string entrada = Console.ReadLine() ?? "0";

            // Convierte la entrada en una lista de números
            List<double> numeros = entrada.Split(',').Select(double.Parse).ToList();

            // Cálculo de la media
            double media = numeros.Average();

            // Cálculo de la desviación típica
            double sumaCuadrados = 0;
            foreach (double n in numeros)
            {
                sumaCuadrados += Math.Pow(n - media, 2);
            }

            double desviacion = Math.Sqrt(sumaCuadrados / numeros.Count);

            Console.WriteLine($"Media: {media}");
            Console.WriteLine($"Desviación típica: {desviacion}");
            Console.WriteLine();
        }
    }
}
