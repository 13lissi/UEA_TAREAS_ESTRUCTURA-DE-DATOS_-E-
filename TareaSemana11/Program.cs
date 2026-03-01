using System;

namespace TareaSemana11;

// Punto de entrada del programa.
// Su única responsabilidad es iniciar la aplicación.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("------¡Bienvenido al Traductor Español-Inglés!------");
        TranslatorApp app = new TranslatorApp();
        app.Run();
    }
}