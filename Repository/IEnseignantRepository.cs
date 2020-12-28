using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public interface IEnseignantRepository
    {
        Task<IEnumerable<Enseignant>> GetEnseignants();
        Task<Enseignant> GetEnseignant(int idEnseignant);
        Task<Enseignant> AddEnseignant(Enseignant enseignant);
        Task<Enseignant> UpdateEnseignant(Enseignant enseignant);
        Task<Enseignant> DeleteEnseignant(int idEnseignant);
        Task<IEnumerable<Enseignant>> SearchEnseignant(string name);
        Task<Enseignant> GetEnseignantByMail(string email);
    } 
}