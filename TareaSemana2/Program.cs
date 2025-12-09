using System;

// Clase principal desde donde se ejecuta el programa
namespace TareaSemana2
{
    class Program
    {    
        static void Main(string[] args)
        {
            Console.WriteLine("=== TAREA SEMANA 2 ===");

            Cuadrado miCuadrado = new Cuadrado(5.0);
            Console.WriteLine("\n--- CUADRADO ---");
            Console.WriteLine($"Área: {miCuadrado.CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {miCuadrado.CalcularPerimetro():F2}");

            Triangulo miTriangulo = new Triangulo(3.0, 4.0);
            Console.WriteLine("\n--- TRIÁNGULO ---");
            Console.WriteLine($"Área: {miTriangulo.CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {miTriangulo.CalcularPerimetro():F2}");

            Console.ReadKey();
        }
    }
}
