using emploiTemps.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Models;
using System.Linq;

namespace emploiTemps.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly EmploiTempsContext _context;

        public UserRepository(EmploiTempsContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int idUser)
        {
            return await _context.Users
                .FirstOrDefaultAsync(e => e.idUser == idUser);
        }

        public async Task<User> AddUser(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(e => e.idUser == user.idUser);

            if (result != null)
            {
                result.idUser = user.idUser;
                result.username = user.username;
                result.password = user.password;
                result.mail = user.mail;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<User> DeleteUser(int idUser)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(e => e.idUser == idUser);
            if (result != null)
            {
                _context.Users.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<User>> SearchUser(string name)
        {
            IQueryable<User> query = _context.Users;
                
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.username.Contains(name)
                            || e.password.Contains(name) || e.mail.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<User> GetUserByMail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(e => e.mail == email);
        }
    }
}