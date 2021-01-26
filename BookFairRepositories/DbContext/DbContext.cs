using BookFairRepositories.Interfaces;
using DAL;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookFairRepositories.DbContext
{
    public class DbContext : IDbContext
    {

        public bool Connect(string login, string password)
        {
            using (var context = new BookFairContext())
            {
                return context.Users.SingleOrDefault(u => u.Login == login && u.Password == password) != null;
            }
        }

        public async Task<bool> ConnectAsync(string login, string password)
        {
            return await Task.Run(() => Connect(login, password));
        }

        public bool Register(Models.User user)
        {
            using (var context = new BookFairContext())
            {
                context.Users.Add(new User());
                return true;
            }
        }

        public async Task<bool> RegisterAsync(Models.User user)
        {
            var isSuccess = false;
            try
            {
                isSuccess = await Task.Run(() => Register(user));
            }
            catch (Exception)
            {
                throw;
            }

            return isSuccess;
        }
    }
}
