using System;

namespace TareaSemana10.Models
{
    // Representa a un ciudadano del sistema.
    // Se usa como objeto para aplicar correctamente teoría de conjuntos.
    public class Citizen
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Citizen(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Dos ciudadanos son iguales si tienen el mismo Id.
        public override bool Equals(object? obj)
        {
            if (obj is Citizen other)
            {
                return this.Id == other.Id;
            }
            return false;
        }

        // Necesario para que HashSet funcione correctamente.
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} (ID: {Id})";
        }
    }
}