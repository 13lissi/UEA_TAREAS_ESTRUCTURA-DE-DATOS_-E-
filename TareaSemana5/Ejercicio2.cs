using System;
using System.Collections.Generic;

namespace TareaSemana5
{
    class Ejercicio2
    {
        public static void Ejecutar()
        {
            // Lista de asignaturas
            List<string> asignaturas = new List<string>
            {
                "Matemáticas", "Física", "Química", "Historia", "Lengua"
            };

            // Muestra cada asignatura
            foreach (string asignatura in asignaturas)
            {
                Console.WriteLine("Yo estudio " + asignatura);
            }

            Console.WriteLine();
        }
    }
}
