using System;

namespace TareaSemana11;

// Esta clase gestiona la interacción con el usuario.
// Se encarga únicamente del menú y de comunicarse
// con el DictionaryManager para realizar las traducciones y gestionar el diccionario.
public class TranslatorApp
{
    // Objeto que contiene la lógica del diccionario
    private readonly DictionaryManager dictionaryManager;

   
    public TranslatorApp()
    {
        dictionaryManager = new DictionaryManager();
    }

    // Método principal que mantiene activo el programa
    // hasta que el usuario decida salir.
    public void Run()
    {
        int option;

        do
        {
            Console.Clear(); // Limpia la consola para que el menú se vea ordenado
            ShowMenu();

            string input = Console.ReadLine() ?? string.Empty;

            // Validación segura para evitar errores si el usuario escribe letras
            if (int.TryParse(input, out option))
            {
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Translate();
                        Pause();
                        break;

                    case 2:
                        Console.Clear();
                        AddNewWord();
                        Pause();
                        break;

                    case 3:
                        Console.Clear();
                        ShowDictionary();
                        Pause();
                        break;

                    case 0:
                        Console.WriteLine("\nGracias por usar el traductor!");
                        break;

                    default:
                        Console.WriteLine("\nOpción inválida.");
                        Pause();
                        break;
                }
            }
            else
            {
                // Si no ingresa número, se controla el error
                Console.WriteLine("\nPor favor ingrese un número válido.");
                Pause();
                option = -1;
            }

        } while (option != 0); // El programa se repite hasta que el usuario elija salir
    }

    // Muestra el menú principal del sistema
    private void ShowMenu()
    {
        Console.WriteLine("===============================================");
        Console.WriteLine("     TRADUCTOR PARCAL ESPAÑOL - INGLÉS");
        Console.WriteLine("===============================================");
        Console.WriteLine();
        Console.WriteLine("  1) Traducir una frase");
        Console.WriteLine("  2) Agregar palabra al diccionario");
        Console.WriteLine("  3) Ver palabras cargadas");
        Console.WriteLine("  0) Salir");
        Console.WriteLine();
        Console.Write("Seleccione una opción: ");
    }

    // Permite ingresar una frase y mostrar su traducción parcial
    private void Translate()
    {
        Console.WriteLine("------ TRADUCCIÓN DE FRASE ------");
        Console.Write("Ingrese la frase: ");

        string sentence = Console.ReadLine() ?? string.Empty;

        // Se delega la lógica de traducción al DictionaryManager
        string result = dictionaryManager.TranslateSentence(sentence);

        Console.WriteLine("\nTraducción parcial:");
        Console.WriteLine(result);
    }

    // Permite agregar nuevas palabras dinámicamente
    // al diccionario durante la ejecución del programa
    private void AddNewWord()
    {
        Console.WriteLine("------ AGREGAR NUEVA PALABRA ------");

        Console.Write("Ingrese la palabra en español: ");
        string spanish = (Console.ReadLine() ?? string.Empty).Trim();

        Console.Write("Ingrese la traducción en inglés: ");
        string english = (Console.ReadLine() ?? string.Empty).Trim();

        if (!string.IsNullOrWhiteSpace(spanish) &&
            !string.IsNullOrWhiteSpace(english))
        {
            dictionaryManager.AddWord(spanish, english);
        }
        else
        {
            Console.WriteLine("\nError: No se permiten valores vacíos.");
        }
    }

    // Muestra todas las palabras actualmente almacenadas
    // y la cantidad total registrada en el diccionario
    private void ShowDictionary()
    {
        Console.WriteLine("------ PALABRAS CARGADAS ------\n");

        var words = dictionaryManager.GetAllWords();

        Console.WriteLine($"Total de palabras: {dictionaryManager.WordCount}\n");

        foreach (var item in words)
        {
            Console.WriteLine($"{item.Key}  →  {item.Value}");
        }
    }

    // Método auxiliar para pausar antes de volver al menú
    private void Pause()
    {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }
}