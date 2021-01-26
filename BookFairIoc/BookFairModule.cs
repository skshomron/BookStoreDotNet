using Ninject.Modules;
using BookFairService;
using BookFairRepositories.Interfaces;
using BookFairRepositories.Repositories;
using DAL;
using Ninject;
using BookFairRepositories.DbContext;

namespace BookFairIoc
{
    public class BookFairModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUsersRepository>().To<UsersRepository>();
            Bind<IService>().To<Service>();
            Bind<IDbContext>().To<DbContext>();
        }
        
    }
}
