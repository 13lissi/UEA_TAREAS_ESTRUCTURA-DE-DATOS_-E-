namespace TareaSemana14;


/// Representa un nodo individual dentro del árbol binario de búsqueda.
/// Cada nodo almacena un valor entero y referencias a sus hijos izquierdo y derecho.

public class Nodo
{
    public int Valor { get; set; }
    public Nodo? Izquierdo { get; set; }
    public Nodo? Derecho { get; set; }

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}
