using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository 
{
    public class DepartementRepository: IDepartementRepository
    {
        private readonly EmploiTempsContext _context;

        public DepartementRepository(EmploiTempsContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Departement>> GetDepartements()
        {
            return await _context.Departements.ToListAsync();
        }

        public async Task<Departement> GetDepartement(int idDepartement)
        {
            return await _context.Departements
                .FirstOrDefaultAsync(e => e.idDepartement == idDepartement);
        }

        public async Task<Departement> AddDepartement(Departement departement)
        {
            var result = await _context.Departements.AddAsync(departement);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Departement> UpdateDepartement(Departement departement)
        {
            var result = await _context.Departements
                .FirstOrDefaultAsync(e => e.idDepartement == departement.idDepartement);

            if (result != null)
            {
                result.idDepartement = departement.idDepartement;
                result.nameDepartement = departement.nameDepartement;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Departement> DeleteDepartement(int idDepartement)
        {
            var result = await _context.Departements
                .FirstOrDefaultAsync(e => e.idDepartement == idDepartement);
            if (result != null)
            {
                _context.Departements.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        } 

        public async Task<IEnumerable<Departement>> SearchDepartement(string name)
        {
            IQueryable<Departement> query = _context.Departements;
                
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.nameDepartement.Contains(name));
            }

            return await query.ToListAsync();
        }
    }
}