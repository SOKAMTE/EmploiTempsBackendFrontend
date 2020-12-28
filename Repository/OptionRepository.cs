using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public class OptionRepository: IOptionRepository
    {
        private readonly EmploiTempsContext _context;

        public OptionRepository(EmploiTempsContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Option>> GetOptions()
        {
            return await _context.Options.ToListAsync();
        }

        public async Task<Option> GetOption(int idOption)
        {
            return await _context.Options
                .FirstOrDefaultAsync(e => e.idOption == idOption);
        }

        public async Task<Option> AddOption(Option option)
        {
            var result = await _context.Options.AddAsync(option);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Option> UpdateOption(Option option)
        {
            var result = await _context.Options
                .FirstOrDefaultAsync(e => e.idOption == option.idOption);

            if (result != null)
            {
                result.idOption = option.idOption;
                result.nameOption = option.nameOption;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Option> DeleteOption(int idOption)
        {
            var result = await _context.Options
                .FirstOrDefaultAsync(e => e.idOption == idOption);
            if (result != null)
            {
                _context.Options.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Option>> SearchOption(string name)
        {
            IQueryable<Option> query = _context.Options;
                
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.nameOption.Contains(name));
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