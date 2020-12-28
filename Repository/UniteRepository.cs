using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public class UniteRepository: IUniteRepository
    {
        private readonly EmploiTempsContext _context;

        public UniteRepository(EmploiTempsContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Unite>> GetUnites()
        {
            return await _context.Unites.ToListAsync();
        }

        public async Task<Unite> GetUnite(int idUnite)
        {
            return await _context.Unites
                .FirstOrDefaultAsync(e => e.idUnite == idUnite);
        }

        public async Task<Unite> AddUnite(Unite unite)
        {
            var result = await _context.Unites.AddAsync(unite);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Unite> UpdateUnite(Unite unite)
        {
            var result = await _context.Unites
                .FirstOrDefaultAsync(e => e.idUnite == unite.idUnite);

            if (result != null)
            {
                result.idUnite = unite.idUnite;
                result.nameUnite = unite.nameUnite;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Unite> DeleteUnite(int idUnite)
        {
            var result = await _context.Unites
                .FirstOrDefaultAsync(e => e.idUnite == idUnite);
            if (result != null)
            {
                _context.Unites.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Unite>> SearchUnite(string name)
        {
            IQueryable<Unite> query = _context.Unites;
                
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.nameUnite.Contains(name));
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