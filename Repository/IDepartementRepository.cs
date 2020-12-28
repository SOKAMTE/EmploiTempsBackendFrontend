using System.Threading.Tasks;
using System.Collections.Generic;
using emploiTemps.Models;

namespace emploiTemps.Repository
{
    public interface IDepartementRepository
    {
        Task<IEnumerable<Departement>> GetDepartements();
        Task<Departement> GetDepartement(int idDepartement);
        Task<Departement> AddDepartement(Departement departement);
        Task<Departement> UpdateDepartement(Departement departement);
        Task<Departement> DeleteDepartement(int idDepartement);
        Task<IEnumerable<Departement>> SearchDepartement(string name);
    } 
}