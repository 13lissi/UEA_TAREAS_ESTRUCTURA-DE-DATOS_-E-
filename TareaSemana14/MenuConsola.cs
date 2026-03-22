namespace TareaSemana14;

/// Gestiona toda la interacción con el usuario a través de la consola.
/// Aplica el principio de Responsabilidad Única: solo se ocupa de la UI.

public class MenuConsola
{
    private readonly ArbolBST _arbol;

    public MenuConsola()
    {
        _arbol = new ArbolBST();
    }

    public void Ejecutar()
    {
        MostrarBienvenida();

        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            string opcion = LeerEntrada("  Selecciona una opcion: ");
            Console.WriteLine();
            continuar = ProcesarOpcion(opcion);
        }
    }

    // MENU PRINCIPAL
    private void MostrarBienvenida()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║     ARBOL BINARIO DE BUSQUEDA (BST) -- C#        ║");
        Console.WriteLine("║             Estructura de Datos                  ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝");
        Console.WriteLine();
    }

    private void MostrarMenu()
    {
        Console.WriteLine("┌──────────────────── MENU ────────────────────────┐");
        Console.WriteLine("│  1. Insertar valores                             │");
        Console.WriteLine("│  2. Buscar valor                                 │");
        Console.WriteLine("│  3. Eliminar valor                               │");
        Console.WriteLine("│  4. Recorridos (Preorden / Inorden / Postorden)  │");
        Console.WriteLine("│  5. Propiedades (Minimo / Maximo / Altura)       │");
        Console.WriteLine("│  6. Limpiar arbol                                │");
        Console.WriteLine("│  0. Salir                                        │");
        Console.WriteLine("└──────────────────────────────────────────────────┘");
    }

    private bool ProcesarOpcion(string opcion)
    {
        switch (opcion.Trim())
        {
            case "1": OpcionInsertar();    break;
            case "2": OpcionBuscar();      break;
            case "3": OpcionEliminar();    break;
            case "4": OpcionRecorridos();  break;
            case "5": OpcionPropiedades(); break;
            case "6": OpcionLimpiar();     break;
            case "0": MostrarDespedida(); return false;
            default:
                Console.WriteLine("  Opcion invalida. Intenta de nuevo.");
                break;
        }

        Console.WriteLine();
        Pausar();
        Console.Clear();
        MostrarBienvenida();
        return true;
    }

    // OPERACIONES
    /// <summary>
    /// Permite insertar múltiples valores en secuencia sin volver al menú.
    /// El bucle termina cuando el usuario escribe "fin".
    /// </summary>
    private void OpcionInsertar()
    {
        Console.WriteLine("──────────────── INSERTAR VALORES ──────────────────────");
        Console.WriteLine("  Escribe un numero y presiona Enter para insertarlo.");
        Console.WriteLine("  Escribe  'fin'  cuando termines.");
        Console.WriteLine();

        int insertados = 0;

        while (true)
        {
            string entrada = LeerEntrada($"  Valor #{insertados + 1}: ");

            if (entrada.ToLower() == "fin")
                break;

            if (!int.TryParse(entrada, out int valor))
            {
                Console.WriteLine("  Entrada invalida. Escribe un numero entero o 'fin'.");
                continue;
            }

            // Detectar duplicados antes de insertar para informar al usuario
            if (_arbol.Buscar(valor))
            {
                Console.WriteLine($"  El valor {valor} ya existe en el arbol. No se inserta.");
                continue;
            }

            _arbol.Insertar(valor);
            insertados++;
            Console.WriteLine($"  -> {valor} insertado.");
        }

        Console.WriteLine();
        Console.WriteLine($"  Total insertados: {insertados} valor(es).");
    }

    private void OpcionBuscar()
    {
        Console.WriteLine("──────────────── BUSCAR VALOR ──────────────────────");

        if (_arbol.EstaVacio()) { MensajeArbolVacio(); return; }

        if (!TryLeerEntero("  Ingresa el valor a buscar: ", out int valor))
            return;

        bool encontrado = _arbol.Buscar(valor);
        Console.WriteLine(encontrado
            ? $"  El valor {valor} SI existe en el arbol."
            : $"  El valor {valor} NO existe en el arbol.");
    }

    private void OpcionEliminar()
    {
        Console.WriteLine("──────────────── ELIMINAR VALOR ──────────────────────");

        if (_arbol.EstaVacio()) { MensajeArbolVacio(); return; }

        if (!TryLeerEntero("  Ingresa el valor a eliminar: ", out int valor))
            return;

        bool eliminado = _arbol.Eliminar(valor);
        Console.WriteLine(eliminado
            ? $"  Valor {valor} eliminado correctamente."
            : $"  El valor {valor} no existe en el arbol.");
    }

    // SUBMENU: RECORRIDOS

    private void OpcionRecorridos()
    {
        Console.WriteLine("──────────────── RECORRIDOS DEL ARBOL ──────────────────");

        if (_arbol.EstaVacio()) { MensajeArbolVacio(); return; }

        Console.WriteLine("  a. Preorden  (Raiz -> Izq -> Der)");
        Console.WriteLine("  b. Inorden   (Izq  -> Raiz -> Der)");
        Console.WriteLine("  c. Postorden (Izq  -> Der  -> Raiz)");
        Console.WriteLine("  d. Todos los recorridos");
        Console.WriteLine();

        string sub = LeerEntrada("  Elige una opcion (a/b/c/d): ").Trim().ToLower();
        Console.WriteLine();

        switch (sub)
        {
            case "a":
                MostrarRecorrido("Preorden  (Raiz->Izq->Der)", _arbol.Preorden());
                break;
            case "b":
                MostrarRecorrido("Inorden   (Izq->Raiz->Der)", _arbol.Inorden());
                break;
            case "c":
                MostrarRecorrido("Postorden (Izq->Der->Raiz)", _arbol.Postorden());
                break;
            case "d":
                MostrarRecorrido("Preorden  (Raiz->Izq->Der)", _arbol.Preorden());
                MostrarRecorrido("Inorden   (Izq->Raiz->Der)", _arbol.Inorden());
                MostrarRecorrido("Postorden (Izq->Der->Raiz)", _arbol.Postorden());
                break;
            default:
                Console.WriteLine("  Opcion invalida.");
                break;
        }
    }

    // SUBMENU: PROPIEDADES

    private void OpcionPropiedades()
    {
        Console.WriteLine("──────────────── PROPIEDADES DEL ARBOL ─────────────────");

        if (_arbol.EstaVacio()) { MensajeArbolVacio(); return; }

        Console.WriteLine("  a. Valor minimo");
        Console.WriteLine("  b. Valor maximo");
        Console.WriteLine("  c. Altura del arbol");
        Console.WriteLine("  d. Todas las propiedades");
        Console.WriteLine();

        string sub = LeerEntrada("  Elige una opcion (a/b/c/d): ").Trim().ToLower();
        Console.WriteLine();

        switch (sub)
        {
            case "a":
                Console.WriteLine($"  Minimo  : {_arbol.ObtenerMinimo()}");
                break;
            case "b":
                Console.WriteLine($"  Maximo  : {_arbol.ObtenerMaximo()}");
                break;
            case "c":
                Console.WriteLine($"  Altura  : {_arbol.ObtenerAltura()} nivel(es)");
                break;
            case "d":
                Console.WriteLine($"  Minimo  : {_arbol.ObtenerMinimo()}");
                Console.WriteLine($"  Maximo  : {_arbol.ObtenerMaximo()}");
                Console.WriteLine($"  Altura  : {_arbol.ObtenerAltura()} nivel(es)");
                break;
            default:
                Console.WriteLine("  Opcion invalida.");
                break;
        }
    }

    private void OpcionLimpiar()
    {
        Console.WriteLine("─────────────────── LIMPIAR ARBOL ────────────────────────");
        string confirmacion = LeerEntrada("  ¿Estas seguro? (s/n): ").ToLower();

        if (confirmacion == "s" || confirmacion == "si")
        {
            _arbol.Limpiar();
            Console.WriteLine("  El arbol ha sido limpiado completamente.");
        }
        else
        {
            Console.WriteLine("  Operacion cancelada.");
        }
    }

    // UTILIDADES DE UI

    private void MostrarRecorrido(string etiqueta, List<int> valores)
    {
        Console.WriteLine($"  {etiqueta}:");
        Console.WriteLine($"    {string.Join(" -> ", valores)}");
        Console.WriteLine();
    }

    private void MensajeArbolVacio()
    {
        Console.WriteLine("  El arbol esta vacio. Inserta valores primero.");
    }

    private void MostrarDespedida()
    {
        Console.WriteLine();
        Console.WriteLine("  Hasta luego. ¡Buena suerte en tus estudios!");
        Console.WriteLine();
    }

    private void Pausar()
    {
        Console.WriteLine("  Presiona cualquier tecla para continuar...");
        Console.ReadKey(intercept: true);
    }

    /// <summary>
    /// Lee una entrada del usuario. Repite la pregunta si el usuario
    /// deja el campo vacío, evitando strings vacíos que causan errores silenciosos.
    /// </summary>
    private static string LeerEntrada(string mensaje)
    {
        string? entrada;

        do
        {
            Console.Write(mensaje);
            entrada = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(entrada));

        return entrada.Trim();
    }

    /// <summary>
    /// Solicita un entero al usuario y reintenta automáticamente si la entrada
    /// es inválida, sin expulsar al usuario de la operación actual.
    /// </summary>
    private static bool TryLeerEntero(string mensaje, out int resultado)
    {
        while (true)
        {
            string entrada = LeerEntrada(mensaje);

            if (int.TryParse(entrada, out resultado))
                return true;

            Console.WriteLine("  Entrada invalida. Escribe un numero entero.");
        }
    }
}