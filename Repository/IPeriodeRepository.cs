using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public interface IPeriodeRepository
    {
        Task<IEnumerable<Periode>> GetPeriodes();
        Task<Periode> GetPeriode(int idPeriode);
        Task<Periode> AddPeriode(Periode periode);
        Task<Periode> UpdatePeriode(Periode periode);
        Task<Periode> DeletePeriode(int idPeriode);
        Task<IEnumerable<Periode>> SearchPeriode(string name);
    } 
}