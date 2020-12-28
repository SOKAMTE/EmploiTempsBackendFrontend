using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public interface IOptionRepository
    {
        Task<IEnumerable<Option>> GetOptions();
        Task<Option> GetOption(int idOption);
        Task<Option> AddOption(Option option);
        Task<Option> UpdateOption(Option option);
        Task<Option> DeleteOption(int idOption);
        Task<IEnumerable<Option>> SearchOption(string name);
    } 
}