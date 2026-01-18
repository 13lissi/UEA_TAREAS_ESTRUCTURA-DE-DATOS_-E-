using System;

class ListaEstudiantes
{
    private Nodo cabeza;
    private Nodo cola;
    private int aprobados;
    private int reprobados;

    public void Agregar(Estudiante e)
    {
        Nodo nuevo = new Nodo(e);

        if (cabeza == null) // lista vacía
        {
            cabeza = cola = nuevo;
            // Incrementar el contador para el primer estudiante
            if (e.Nota >= 7) aprobados++; else reprobados++;
        }
        else if (e.Nota >= 7) // aprobados al inicio
        {
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
            aprobados++;
        }
        else // reprobados al final
        {
            cola.Siguiente = nuevo;
            cola = nuevo;
            reprobados++;
        }
    }

    public void Buscar(string cedula)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.Dato.Cedula == cedula)
            {
                Console.WriteLine($"Estudiante encontrado: {actual.Dato.Nombre} {actual.Dato.Apellido} - Nota: {actual.Dato.Nota}");
                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("Estudiante no encontrado.");
    }

    public void Eliminar(string cedula)
    {
        Nodo actual = cabeza;
        Nodo anterior = null;

        while (actual != null)
        {
            if (actual.Dato.Cedula == cedula)
            {
                // Ajustar contadores al eliminar
                if (actual.Dato.Nota >= 7) aprobados--; else reprobados--;

                if (anterior == null) // primer nodo
                    cabeza = actual.Siguiente;
                else
                    anterior.Siguiente = actual.Siguiente;

                if (actual == cola) // si eliminamos el último
                    cola = anterior;

                Console.WriteLine("Estudiante eliminado correctamente.");
                return;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        Console.WriteLine("No se encontró el estudiante.");
    }

    public void Mostrar()
    {
        Nodo actual = cabeza;
        Console.WriteLine("\n--- Lista de Estudiantes ---");
        while (actual != null)
        {
            Console.WriteLine($"{actual.Dato.Cedula} - {actual.Dato.Nombre} {actual.Dato.Apellido} - Nota: {actual.Dato.Nota}");
            actual = actual.Siguiente;
        }
        Console.WriteLine($"Total aprobados: {aprobados}, Total reprobados: {reprobados}");
    }
}
