using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository 
{
    public interface IUniteRepository
    {
        Task<IEnumerable<Unite>> GetUnites();
        Task<Unite> GetUnite(int idUnite);
        Task<Unite> AddUnite(Unite unite);
        Task<Unite> UpdateUnite(Unite unite);
        Task<Unite> DeleteUnite(int idUnite);
        Task<IEnumerable<Unite>> SearchUnite(string name);
        //Task<Unite> GetUniteByMail(string email);
    } 
}