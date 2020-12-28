using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public interface ISalleRepository
    {
        Task<IEnumerable<Salle>> GetSalles();
        Task<Salle> GetSalle(int idSalle);
        Task<Salle> AddSalle(Salle salle);
        Task<Salle> UpdateSalle(Salle salle);
        Task<Salle> DeleteSalle(int idSalle);
        Task<IEnumerable<Salle>> SearchSalle(string name);
    } 
}