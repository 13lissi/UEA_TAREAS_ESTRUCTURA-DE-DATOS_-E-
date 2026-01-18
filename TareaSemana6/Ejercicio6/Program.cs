using System;

class Program
{
    static void Main()
    {
        ListaEstudiantes lista = new ListaEstudiantes();
        string opcion = "";

        while (opcion != "0")
        {
            // Encabezado y menú vertical
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("         REGISTRO DE ESTUDIANTES           ");
            Console.WriteLine("===========================================\n");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Buscar estudiante por cédula");
            Console.WriteLine("3. Eliminar estudiante por cédula");
            Console.WriteLine("4. Mostrar todos los estudiantes");
            Console.WriteLine("0. Salir");
            Console.Write("\nSeleccione una opción: ");
            opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    // ======================
                    // VALIDAR CÉDULA
                    // ======================
                    string cedula;
                    do
                    {
                        Console.Write("Cédula (10 dígitos): ");
                        cedula = Console.ReadLine() ?? "";
                        if (cedula.Length != 10 || !ulong.TryParse(cedula, out _))
                        {
                            Console.WriteLine("Cédula inválida. Debe tener 10 números.");
                            cedula = "";
                        }
                    } while (cedula == "");

                    // ======================
                    // NOMBRE, APELLIDO, CORREO
                    // ======================
                    Console.Write("Nombre: "); string nombre = Console.ReadLine() ?? "";
                    Console.Write("Apellido: "); string apellido = Console.ReadLine() ?? "";
                    Console.Write("Correo: "); string correo = Console.ReadLine() ?? "";

                    // ======================
                    // VALIDAR NOTA (1 a 10)
                    // ======================
                    double nota = -1;
                    do
                    {
                        Console.Write("Nota (1 a 10): ");
                        if (!double.TryParse(Console.ReadLine(), out nota) || nota < 1 || nota > 10)
                        {
                            Console.WriteLine("Nota inválida. Debe estar entre 1 y 10.");
                            nota = -1;
                        }
                    } while (nota == -1);

                    // Agregar estudiante a la lista
                    lista.Agregar(new Estudiante(cedula, nombre, apellido, correo, nota));
                    Console.WriteLine("\nEstudiante agregado correctamente.");
                    Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Cédula a buscar: ");
                    lista.Buscar(Console.ReadLine() ?? "");
                    Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Cédula a eliminar: ");
                    lista.Eliminar(Console.ReadLine() ?? "");
                    Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadLine();
                    break;

                case "4":
                    lista.Mostrar();
                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                    break;

                case "0":
                    Console.WriteLine("\nSaliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Presione ENTER para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
