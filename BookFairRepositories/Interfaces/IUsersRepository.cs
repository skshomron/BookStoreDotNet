using BookFairRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFairRepositories.Interfaces
{
    public interface IUsersRepository
    {
        bool Connect(string login, string password);
        Task<bool> ConnectAsync(string login, string password);
        bool Register(User user);
        Task<bool>RegisterAsync(User user);
    }
}
