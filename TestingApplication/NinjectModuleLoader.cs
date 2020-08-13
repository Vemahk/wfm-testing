using Ninject;
using ServiceAbstractions.Interfaces;
using Services.Concrete;
using Services.Ninject;

namespace TestingApplication
{
    public static class NinjectModuleLoader
    {
        private const string AppName = "WFM-Digest";
        
        private static StandardKernel _kernel;

        public static StandardKernel Kernel
        {
            get
            {
                if (_kernel == null)
                {
                    var settings = new NinjectSettings();
                    settings.Set("appName", AppName);

                    _kernel = new StandardKernel(settings);
                    _kernel.Load<ServicesNinjectModule>();
                }

                return _kernel;
            }
        }
    }
}