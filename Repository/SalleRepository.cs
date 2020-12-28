using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public class SalleRepository: ISalleRepository
    {
        private readonly EmploiTempsContext _context;

        public SalleRepository(EmploiTempsContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Salle>> GetSalles()
        {
            return await _context.Salles.ToListAsync();
        }

        public async Task<Salle> GetSalle(int idSalle)
        {
            return await _context.Salles
                .FirstOrDefaultAsync(e => e.idSalle == idSalle);
        }

        public async Task<Salle> AddSalle(Salle salle)
        {
            var result = await _context.Salles.AddAsync(salle);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Salle> UpdateSalle(Salle salle)
        {
            var result = await _context.Salles
                .FirstOrDefaultAsync(e => e.idSalle == salle.idSalle);

            if (result != null)
            {
                result.idSalle = salle.idSalle;
                result.nameSalle = salle.nameSalle;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Salle> DeleteSalle(int idSalle)
        {
            var result = await _context.Salles
                .FirstOrDefaultAsync(e => e.idSalle == idSalle);
            if (result != null)
            {
                _context.Salles.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Salle>> SearchSalle(string name)
        {
            IQueryable<Salle> query = _context.Salles;
                
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.nameSalle.Contains(name));
            }

            return await query.ToListAsync();
        }

        /*public async Task<Unite> GetUniteByMail(string email)
        {
            return await _context.Unites
                .FirstOrDefaultAsync(e => e.mail == email);
        }*/
    }
}