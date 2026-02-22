using System;
using System.Collections.Generic;
using System.Linq;
using TareaSemana10.Models;

namespace TareaSemana10.Services
{
    // Implementa la lógica aplicando teoría de conjuntos y LINQ.
    public class VaccinationManager : IVaccinationManager
    {
        private HashSet<Citizen> Citizens;
        private HashSet<Citizen> Pfizer;
        private HashSet<Citizen> AstraZeneca;

        private Random random = new Random();

        public VaccinationManager()
        {
            Citizens = new HashSet<Citizen>();
            Pfizer = new HashSet<Citizen>();
            AstraZeneca = new HashSet<Citizen>();
        }

        // Genera el conjunto universal de 500 ciudadanos ficticios.
        public void GenerateCitizens(int total)
        {
            for (int i = 1; i <= total; i++)
            {
                Citizens.Add(new Citizen(i, $"Ciudadano {i}"));
            }
        }

        // Asignación independiente para permitir intersección real.
        public void AssignVaccines(int pfizerCount, int astraZenecaCount)
        {
            Pfizer = Citizens
                        .OrderBy(c => random.Next())
                        .Take(pfizerCount)
                        .ToHashSet();

            AstraZeneca = Citizens
                            .OrderBy(c => random.Next())
                            .Take(astraZenecaCount)
                            .ToHashSet();
        }

        // U - (P ∪ A)
        public HashSet<Citizen> GetNotVaccinated()
        {
            var vaccinated = Pfizer.Union(AstraZeneca).ToHashSet();
            return Citizens.Except(vaccinated).ToHashSet();
        }

        // P ∩ A
        public HashSet<Citizen> GetBothDoses()
        {
            return Pfizer.Intersect(AstraZeneca).ToHashSet();
        }

        // P - A
        public HashSet<Citizen> GetOnlyPfizer()
        {
            return Pfizer.Except(AstraZeneca).ToHashSet();
        }

        // A - P
        public HashSet<Citizen> GetOnlyAstraZeneca()
        {
            return AstraZeneca.Except(Pfizer).ToHashSet();
        }
    }
}