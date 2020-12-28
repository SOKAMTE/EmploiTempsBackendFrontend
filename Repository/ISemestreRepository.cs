using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public interface ISemestreRepository
    {
        Task<IEnumerable<Semestre>> GetSemestres();
        Task<Semestre> GetSemestre(int idSemestre);
        Task<Semestre> AddSemestre(Semestre semestre);
        Task<Semestre> UpdateSemestre(Semestre semestre);
        Task<Semestre> DeleteSemestre(int idSemestre);
        Task<IEnumerable<Semestre>> SearchSemestre(string name);
    } 
}