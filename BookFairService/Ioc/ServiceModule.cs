using BookFairRepositories.Repositories;
using BookFairRepositories.Interfaces;
using Ninject.Modules;

namespace BookFairService.Ioc
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUsersRepository>().To<UsersRepository>();
            Bind<IBookFairService>().To<BookFairService>();                        
        }
    }
}
