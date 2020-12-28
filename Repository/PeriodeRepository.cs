using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public class PeriodeRepository: IPeriodeRepository
    {
        private readonly EmploiTempsContext _context;

        public PeriodeRepository(EmploiTempsContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Periode>> GetPeriodes()
        {
            return await _context.Periodes.ToListAsync();
        }

        public async Task<Periode> GetPeriode(int idPeriode)
        {
            return await _context.Periodes
                .FirstOrDefaultAsync(e => e.idPeriode == idPeriode);
        }

        public async Task<Periode> AddPeriode(Periode periode)
        {
            var result = await _context.Periodes.AddAsync(periode);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Periode> UpdatePeriode(Periode periode)
        {
            var result = await _context.Periodes
                .FirstOrDefaultAsync(e => e.idPeriode == periode.idPeriode);

            if (result != null)
            {
                result.idPeriode = periode.idPeriode;
                result.dateDebutPeriode = periode.dateDebutPeriode;
                result.dateFinPeriode = periode.dateFinPeriode;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Periode> DeletePeriode(int idPeriode)
        {
            var result = await _context.Periodes
                .FirstOrDefaultAsync(e => e.idPeriode == idPeriode);
            if (result != null)
            {
                _context.Periodes.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Periode>> SearchPeriode(string name)
        {
            IQueryable<Periode> query = _context.Periodes;
                
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.namePeriode.Contains(name));
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