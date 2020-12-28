using System.Threading.Tasks;
using emploiTemps.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq; 

namespace emploiTemps.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int idUser);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int idUser);
        Task<IEnumerable<User>> SearchUser(string name);
        Task<User> GetUserByMail(string email);
    } 
}