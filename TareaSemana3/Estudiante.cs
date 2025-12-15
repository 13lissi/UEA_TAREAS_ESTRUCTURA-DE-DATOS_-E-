using System;

namespace RegistroEstudiante
{
    // Definición de la clase Estudiante
    public class Estudiante
    {
        // Propiedades de la clase (Getters y Setters)
        public string? ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        
        // Requisito: Los números de teléfono deben almacenarse utilizando un array.
        // Definimos un arreglo de strings de tamaño 3.
        public string[] Telefonos { get; set; }

        // Constructor para inicializar el objeto y el arreglo
        public Estudiante()
        {
            Telefonos = new string[3]; // Inicializa el array para 3 números
        }

        // Método para mostrar la información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("\n--- DATOS REGISTRADOS DEL ESTUDIANTE ---");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nombre Completo: {Nombres} {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Números de Teléfono:");
            
            // Recorremos el arreglo para mostrar los teléfonos
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}