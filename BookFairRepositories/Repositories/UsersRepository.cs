using BookFairRepositories.Interfaces;
using DAL;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookFairRepositories.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        IDbContext _context;
        public UsersRepository(IDbContext context)
        {
            _context = context??throw new ArgumentNullException("expecting a not null context");
        }
        public bool Connect(string login, string password)
        {
            return _context.Connect(login, password);
        }

        public async Task<bool> ConnectAsync(string login, string password)
        {
            return await _context.ConnectAsync(login,password);
        }

        public bool Register(Models.User user)
        {
            try
            {
                _context.Register(user);                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<bool> RegisterAsync(Models.User user)
        {
            return await _context.RegisterAsync(user);
        }
    }
}
