using System;
using System.Linq;
using TareaSemana10.Services;

namespace TareaSemana10
{
    class Program
    {
        static void Main(string[] args)
        {
            IVaccinationManager manager = new VaccinationManager();

            // Generamos el conjunto universal de 500 ciudadanos
            manager.GenerateCitizens(500);

            // Asignamos 75 vacunas de cada tipo
            manager.AssignVaccines(75, 75);

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("   SISTEMA NACIONAL DE VACUNACIÓN COVID-19  ");
                Console.WriteLine("=============================================");
                Console.WriteLine("Población total registrada: 500 ciudadanos");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1. Ver ciudadanos NO vacunados");
                Console.WriteLine("2. Ver ciudadanos con AMBAS dosis");
                Console.WriteLine("3. Ver ciudadanos SOLO Pfizer");
                Console.WriteLine("4. Ver ciudadanos SOLO AstraZeneca");
                Console.WriteLine("5. Salir");
                Console.WriteLine("---------------------------------------------");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ShowData("CIUDADANOS NO VACUNADOS", manager.GetNotVaccinated());
                        break;

                    case "2":
                        ShowData("CIUDADANOS CON AMBAS DOSIS", manager.GetBothDoses());
                        break;

                    case "3":
                        ShowData("CIUDADANOS SOLO PFIZER", manager.GetOnlyPfizer());
                        break;

                    case "4":
                        ShowData("CIUDADANOS SOLO ASTRAZENECA", manager.GetOnlyAstraZeneca());
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Método auxiliar para mostrar resultados de manera organizada.
        // Utiliza LINQ (.Take) para mostrar solo una muestra de registros.
        static void ShowData(string title, System.Collections.Generic.HashSet<Models.Citizen> data)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine(title);
            Console.WriteLine("=============================================");
            Console.WriteLine($"Total en este grupo: {data.Count}");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Muestra de los primeros 10 registros:\n");

            foreach (var citizen in data.Take(10))
            {
                Console.WriteLine(citizen);
            }

            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}