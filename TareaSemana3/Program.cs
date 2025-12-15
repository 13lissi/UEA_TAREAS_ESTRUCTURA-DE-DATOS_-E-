using System;

namespace RegistroEstudiante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE REGISTRO DE ESTUDIANTE ===");

            // Instancia de la clase Estudiante
            Estudiante nuevoEstudiante = new Estudiante();

            try
            {
                // Solicitud de datos básicos
                Console.Write("Ingrese el ID del estudiante: ");
                nuevoEstudiante.ID = Console.ReadLine();

                Console.Write("Ingrese los Nombres: ");
                nuevoEstudiante.Nombres = Console.ReadLine();

                Console.Write("Ingrese los Apellidos: ");
                nuevoEstudiante.Apellidos = Console.ReadLine();

                Console.Write("Ingrese la Dirección: ");
                nuevoEstudiante.Direccion = Console.ReadLine();

                // Solicitud de los 3 números de teléfono (llenado del array)
                Console.WriteLine("\n--- Registro de Contacto (3 Números requeridos) ---");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Ingrese el número de teléfono #{i + 1}: ");
                    nuevoEstudiante.Telefonos[i] = Console.ReadLine();
                }

                // Mostrar los resultados llamando al método de la clase
                nuevoEstudiante.MostrarInformacion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }

            // Pausa para que no se cierre la consola inmediatamente
            Console.WriteLine("\nPara salir presione cualquier tecla ¡Gracias!");
            Console.ReadKey();
        }
    }
}