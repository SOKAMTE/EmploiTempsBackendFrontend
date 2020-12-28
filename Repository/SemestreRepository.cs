using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public class SemestreRepository: ISemestreRepository
    {
        private readonly EmploiTempsContext _context;

        public SemestreRepository(EmploiTempsContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Semestre>> GetSemestres()
        {
            return await _context.Semestres.ToListAsync();
        }

        public async Task<Semestre> GetSemestre(int idSemestre)
        {
            return await _context.Semestres
                .FirstOrDefaultAsync(e => e.idSemestre == idSemestre);
        }

        public async Task<Semestre> AddSemestre(Semestre semestre)
        {
            var result = await _context.Semestres.AddAsync(semestre);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Semestre> UpdateSemestre(Semestre semestre)
        {
            var result = await _context.Semestres
                .FirstOrDefaultAsync(e => e.idSemestre == semestre.idSemestre);

            if (result != null)
            {
                result.idSemestre = semestre.idSemestre;
                result.nameSemestre = semestre.nameSemestre;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Semestre> DeleteSemestre(int idSemestre)
        {
            var result = await _context.Semestres
                .FirstOrDefaultAsync(e => e.idSemestre == idSemestre);
            if (result != null)
            {
                _context.Semestres.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Semestre>> SearchSemestre(string name)
        {
            IQueryable<Semestre> query = _context.Semestres;
                
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.nameSemestre.Contains(name));
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