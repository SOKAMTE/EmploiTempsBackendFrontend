using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models; 
using System.Linq; 

namespace emploiTemps.Repository
{
    public class NiveauRepository: INiveauRepository
    {
        private readonly EmploiTempsContext _context;

        public NiveauRepository(EmploiTempsContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Niveau>> GetNiveaus()
        {
            return await _context.Niveaus.ToListAsync();
        }

        public async Task<Niveau> GetNiveau(int idNiveau)
        {
            return await _context.Niveaus
                .FirstOrDefaultAsync(e => e.idNiveau == idNiveau);
        }

        public async Task<Niveau> AddNiveau(Niveau niveau)
        {
            var result = await _context.Niveaus.AddAsync(niveau);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Niveau> UpdateNiveau(Niveau niveau)
        {
            var result = await _context.Niveaus
                .FirstOrDefaultAsync(e => e.idNiveau == niveau.idNiveau);

            if (result != null)
            {
                result.idNiveau = niveau.idNiveau;
                result.nameLevel = niveau.nameLevel;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Niveau> DeleteNiveau(int idNiveau)
        {
            var result = await _context.Niveaus
                .FirstOrDefaultAsync(e => e.idNiveau == idNiveau);
            if (result != null)
            {
                _context.Niveaus.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Niveau>> SearchNiveau(string name)
        {
            IQueryable<Niveau> query = _context.Niveaus;
                
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.nameLevel.Contains(name));
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