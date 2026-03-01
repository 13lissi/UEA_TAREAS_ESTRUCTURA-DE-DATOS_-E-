using System;
using System.Collections.Generic;

namespace TareaSemana11;

// Esta clase se encarga exclusivamente de gestionar el diccionario
// y la lógica de traducción. 
public class DictionaryManager
{
    // Diccionario principal 
    private readonly Dictionary<string, string> dictionary;

    public DictionaryManager()
    {
        dictionary = new Dictionary<string, string>();
        LoadInitialWords();
    }

    // Propiedad pública para saber cuántas palabras hay cargadas
    public int WordCount => dictionary.Count;

    // Devuelve todas las palabras cargadas
    public Dictionary<string, string> GetAllWords()
    {
        return dictionary;
    }

    // Carga inicial de palabras base (Español → Inglés)
    private void LoadInitialWords()
    {
        dictionary.Add(NormalizeWord("tiempo"), "time");
        dictionary.Add(NormalizeWord("persona"), "person");
        dictionary.Add(NormalizeWord("año"), "year");
        dictionary.Add(NormalizeWord("camino"), "way");
        dictionary.Add(NormalizeWord("forma"), "way");
        dictionary.Add(NormalizeWord("día"), "day");
        dictionary.Add(NormalizeWord("cosa"), "thing");
        dictionary.Add(NormalizeWord("hombre"), "man");
        dictionary.Add(NormalizeWord("mundo"), "world");
        dictionary.Add(NormalizeWord("vida"), "life");
        dictionary.Add(NormalizeWord("mano"), "hand");
        dictionary.Add(NormalizeWord("parte"), "part");
        dictionary.Add(NormalizeWord("niño"), "child");
        dictionary.Add(NormalizeWord("niña"), "child");
        dictionary.Add(NormalizeWord("ojo"), "eye");
        dictionary.Add(NormalizeWord("mujer"), "woman");
        dictionary.Add(NormalizeWord("lugar"), "place");
        dictionary.Add(NormalizeWord("trabajo"), "work");
        dictionary.Add(NormalizeWord("semana"), "week");
        dictionary.Add(NormalizeWord("caso"), "case");
        dictionary.Add(NormalizeWord("punto"), "point");
        dictionary.Add(NormalizeWord("tema"), "point");
        dictionary.Add(NormalizeWord("gobierno"), "government");
        dictionary.Add(NormalizeWord("empresa"), "company");
        dictionary.Add(NormalizeWord("compañía"), "company");
    }

    // Permite agregar nuevas palabras al diccionario
    public void AddWord(string spanish, string english)
    {
        if (string.IsNullOrWhiteSpace(spanish) ||
            string.IsNullOrWhiteSpace(english))
        {
            Console.WriteLine("No se permiten valores vacíos.");
            return;
        }

        string normalizedKey = NormalizeWord(spanish);

        if (!dictionary.ContainsKey(normalizedKey))
        {
            dictionary.Add(normalizedKey, english);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }

    // Traduce una frase completa de forma parcial
    // Solo reemplaza palabras que existan en el diccionario
    public string TranslateSentence(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
            return string.Empty;

        string[] words = sentence.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            string originalWord = words[i];

            // Eliminamos signos para buscar la palabra limpia
            string cleanWord = originalWord.Trim(',', '.', ';', ':', '!', '?', '"');

            string normalizedWord = NormalizeWord(cleanWord);

            // TryGetValue evita excepciones y warnings
            if (dictionary.TryGetValue(normalizedWord, out string? translation)
                && !string.IsNullOrEmpty(translation))
            {
                // Reemplaza solo la palabra limpia,
                // conservando signos de puntuación
                words[i] = originalWord.Replace(cleanWord, translation);
            }
        }

        return string.Join(" ", words);
    }

    // Método que elimina SOLO las tildes de las vocales
    
    private static string NormalizeWord(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return string.Empty;

        string lower = word.ToLowerInvariant();

        lower = lower
            .Replace("á", "a")
            .Replace("é", "e")
            .Replace("í", "i")
            .Replace("ó", "o")
            .Replace("ú", "u");

        return lower;
    }
}