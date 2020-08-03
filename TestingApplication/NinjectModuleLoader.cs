using Ninject;
using Services.Ninject;

namespace TestingApplication
{
    public static class NinjectModuleLoader
    {
        private static StandardKernel _kernel;

        public static StandardKernel Kernel
        {
            get
            {
                if (_kernel == null)
                {
                    _kernel = new StandardKernel();
                    _kernel.Load<ServicesNinjectModule>();
                }

                return _kernel;
            }
        }
    }
}