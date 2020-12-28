using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public class EnseignantRepository: IEnseignantRepository
    {
        private readonly EmploiTempsContext _context;

        public EnseignantRepository(EmploiTempsContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Enseignant>> GetEnseignants()
        {
            return await _context.Enseignants.ToListAsync();
        }

        public async Task<Enseignant> GetEnseignant(int idEnseignant)
        {
            return await _context.Enseignants
                .FirstOrDefaultAsync(e => e.idEnseignant == idEnseignant);
        }

        public async Task<Enseignant> AddEnseignant(Enseignant enseignant)
        {
            var result = await _context.Enseignants.AddAsync(enseignant);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Enseignant> UpdateEnseignant(Enseignant enseignant)
        {
            var result = await _context.Enseignants
                .FirstOrDefaultAsync(e => e.idEnseignant == enseignant.idEnseignant);

            if (result != null)
            {
                result.idEnseignant = enseignant.idEnseignant;
                result.username = enseignant.username;
                result.password = enseignant.password;
                result.mail = enseignant.mail;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Enseignant> DeleteEnseignant(int idEnseignant)
        {
            var result = await _context.Enseignants
                .FirstOrDefaultAsync(e => e.idEnseignant == idEnseignant);
            if (result != null)
            {
                _context.Enseignants.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Enseignant>> SearchEnseignant(string name)
        {
            IQueryable<Enseignant> query = _context.Enseignants;
                
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.username.Contains(name)
                            || e.password.Contains(name) || e.mail.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Enseignant> GetEnseignantByMail(string email)
        {
            return await _context.Enseignants
                .FirstOrDefaultAsync(e => e.mail == email);
        }
    }
}