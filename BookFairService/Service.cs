using BookFairRepositories.Interfaces;
using BookFairRepositories.Repositories;
using System;
using System.ServiceModel;

namespace BookFairService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookFairService" in both code and config file together.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private IUsersRepository _usersRepository;

        public Service(IUsersRepository users)
        {
            _usersRepository = users ?? throw new ArgumentNullException();
        }
        public bool Connect(string login, string password)
        {
            return _usersRepository.Connect(login,password);
        }
    }
}
