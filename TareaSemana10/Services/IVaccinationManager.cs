using System.Collections.Generic;
using TareaSemana10.Models;

namespace TareaSemana10.Services
{
    // Define el contrato que debe cumplir el gestor de vacunación.
    public interface IVaccinationManager
    {
        void GenerateCitizens(int total);
        void AssignVaccines(int pfizerCount, int astraZenecaCount);

        HashSet<Citizen> GetNotVaccinated();
        HashSet<Citizen> GetBothDoses();
        HashSet<Citizen> GetOnlyPfizer();
        HashSet<Citizen> GetOnlyAstraZeneca();
    }
}