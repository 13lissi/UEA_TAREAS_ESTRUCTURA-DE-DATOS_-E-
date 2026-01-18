using System;

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Agregamos datos de prueba
        lista.AgregarFinal(10);
        lista.AgregarFinal(20);
        lista.AgregarFinal(30);
        lista.AgregarFinal(40);

        Console.WriteLine("================================");
        Console.WriteLine("   EJERCICIO 2: INVERTIR LISTA");
        Console.WriteLine("================================");
        
        Console.WriteLine("Lista original:");
        lista.Mostrar();

        // Ejecutamos el algoritmo de inversión
        lista.Invertir();

        Console.WriteLine("\nLista invertida:");
        lista.Mostrar();
        Console.WriteLine("================================");
    }
}