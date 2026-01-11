using System;

namespace TareaSemana5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("       TAREA DE ESTRUCTURA DE DATOS        ");
        Console.WriteLine("===========================================\n");

        // --- EJERCICIO 2 ---
        Console.WriteLine(">>> EJERCICIO 2: Materias de estudio");
        Ejercicio2.Ejecutar();
        Console.WriteLine("\n-------------------------------------------");

        // --- EJERCICIO 4 ---
        Console.WriteLine(">>> EJERCICIO 4: Lotería Primitiva");
        Ejercicio4.Ejecutar();
        Console.WriteLine("\n-------------------------------------------");

        // --- EJERCICIO 5 ---
        Console.WriteLine(">>> EJERCICIO 5: Números en orden inverso");
        Ejercicio5.Ejecutar();
        Console.WriteLine("\n-------------------------------------------");

        // --- EJERCICIO 8 ---
        Console.WriteLine(">>> EJERCICIO 8: Verificador de Palíndromos");
        Ejercicio8.Ejecutar();
        Console.WriteLine("\n-------------------------------------------");

        // --- EJERCICIO 13 ---
        Console.WriteLine(">>> EJERCICIO 13: Estadística (Media y Desviación)");
        Ejercicio13.Ejecutar();
        Console.WriteLine("\n===========================================");
        
        Console.WriteLine("Tarea completada.");
        Console.ReadKey();
    }
}

