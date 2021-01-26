using BookFairService;
using Ninject;

namespace BookFairIoc
{
    public class BookFairKernel
    {
        private  IKernel _kernel;
        public IKernel Kernel => _kernel ?? (_kernel = new StandardKernel(new BookFairModule()));

        public IService GetService()
        {
            return Kernel.Get<IService>();
        }
    }
}
