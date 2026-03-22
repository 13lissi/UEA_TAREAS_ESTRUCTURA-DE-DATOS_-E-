namespace TareaSemana14;

/// <summary>
/// Implementación de un Árbol Binario de Búsqueda (BST).
/// Gestiona todas las operaciones: inserción, búsqueda, eliminación,
/// recorridos y consultas de propiedades del árbol.
/// </summary>
public class ArbolBST
{
    private Nodo? _raiz;

    public ArbolBST()
    {
        _raiz = null;
    }

    // INSERCIÓN

    public void Insertar(int valor)
    {
        _raiz = InsertarRecursivo(_raiz, valor);
    }

    private static Nodo InsertarRecursivo(Nodo? nodo, int valor)
    {
        // Caso base: posición vacía → crear nuevo nodo
        if (nodo is null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
        // Valor duplicado: se ignora (BST no permite repetidos)

        return nodo;
    }

    // BÚSQUEDA
    public bool Buscar(int valor)
    {
        return BuscarRecursivo(_raiz, valor);
    }

    private static bool BuscarRecursivo(Nodo? nodo, int valor)
    {
        if (nodo is null) return false;
        if (valor == nodo.Valor) return true;

        return valor < nodo.Valor
            ? BuscarRecursivo(nodo.Izquierdo, valor)
            : BuscarRecursivo(nodo.Derecho, valor);
    }

    // ELIMINACIÓN

    public bool Eliminar(int valor)
    {
        // Verificamos primero si el valor existe
        if (!Buscar(valor)) return false;

        _raiz = EliminarRecursivo(_raiz, valor);
        return true;
    }

    private static Nodo? EliminarRecursivo(Nodo? nodo, int valor)
    {
        if (nodo is null) return null;

        if (valor < nodo.Valor)
        {
            nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
        }
        else
        {
            // Nodo encontrado — tres casos posibles:

            // Caso 1: nodo hoja (sin hijos)
            if (nodo.Izquierdo is null && nodo.Derecho is null)
                return null;

            // Caso 2: solo un hijo
            if (nodo.Izquierdo is null) return nodo.Derecho;
            if (nodo.Derecho is null) return nodo.Izquierdo;

            // Caso 3: dos hijos → reemplazar con el sucesor inorden (mínimo del subárbol derecho)
            int sucesor = ObtenerMinimo(nodo.Derecho);
            nodo.Valor = sucesor;
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor);
        }

        return nodo;
    }

    // RECORRIDOS

    /// <summary>Raíz → Izquierdo → Derecho</summary>
    public List<int> Preorden()
    {
        var resultado = new List<int>();
        PreordenRecursivo(_raiz, resultado);
        return resultado;
    }

    private static void PreordenRecursivo(Nodo? nodo, List<int> resultado)
    {
        if (nodo is null) return;
        resultado.Add(nodo.Valor);
        PreordenRecursivo(nodo.Izquierdo, resultado);
        PreordenRecursivo(nodo.Derecho, resultado);
    }

    /// <summary>Izquierdo → Raíz → Derecho (produce valores ordenados)</summary>
    public List<int> Inorden()
    {
        var resultado = new List<int>();
        InordenRecursivo(_raiz, resultado);
        return resultado;
    }

    private static void InordenRecursivo(Nodo? nodo, List<int> resultado)
    {
        if (nodo is null) return;
        InordenRecursivo(nodo.Izquierdo, resultado);
        resultado.Add(nodo.Valor);
        InordenRecursivo(nodo.Derecho, resultado);
    }

    /// <summary>Izquierdo → Derecho → Raíz</summary>
    public List<int> Postorden()
    {
        var resultado = new List<int>();
        PostordenRecursivo(_raiz, resultado);
        return resultado;
    }

    private static void PostordenRecursivo(Nodo? nodo, List<int> resultado)
    {
        if (nodo is null) return;
        PostordenRecursivo(nodo.Izquierdo, resultado);
        PostordenRecursivo(nodo.Derecho, resultado);
        resultado.Add(nodo.Valor);
    }

    // PROPIEDADES DEL ÁRBOL

    public int ObtenerMinimo()
    {
        if (_raiz is null) throw new InvalidOperationException("El árbol está vacío.");
        return ObtenerMinimo(_raiz);
    }

    private static int ObtenerMinimo(Nodo nodo)
    {
        // El mínimo siempre está en el nodo más a la izquierda
        return nodo.Izquierdo is null ? nodo.Valor : ObtenerMinimo(nodo.Izquierdo);
    }

    public int ObtenerMaximo()
    {
        if (_raiz is null) throw new InvalidOperationException("El árbol está vacío.");
        return ObtenerMaximo(_raiz);
    }

    private static int ObtenerMaximo(Nodo nodo)
    {
        // El máximo siempre está en el nodo más a la derecha
        return nodo.Derecho is null ? nodo.Valor : ObtenerMaximo(nodo.Derecho);
    }

    public int ObtenerAltura()
    {
        return ObtenerAlturaRecursivo(_raiz);
    }

    private static int ObtenerAlturaRecursivo(Nodo? nodo)
    {
        if (nodo is null) return 0;

        int alturaIzquierda = ObtenerAlturaRecursivo(nodo.Izquierdo);
        int alturaDerecha = ObtenerAlturaRecursivo(nodo.Derecho);

        return 1 + Math.Max(alturaIzquierda, alturaDerecha);
    }

    public bool EstaVacio() => _raiz is null;

    // LIMPIAR
    public void Limpiar()
    {
        _raiz = null;
    }
}
