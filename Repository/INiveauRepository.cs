using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore; 
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public interface INiveauRepository
    {
        Task<IEnumerable<Niveau>> GetNiveaus();
        Task<Niveau> GetNiveau(int idNiveau); 
        Task<Niveau> AddNiveau(Niveau niveau);
        Task<Niveau> UpdateNiveau(Niveau niveau);
        Task<Niveau> DeleteNiveau(int idNiveau);
        Task<IEnumerable<Niveau>> SearchNiveau(string name);
    } 
}