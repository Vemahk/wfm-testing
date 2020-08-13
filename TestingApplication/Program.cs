using Ninject;
using ServiceAbstractions.Interfaces;

namespace TestingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = NinjectModuleLoader.Kernel;
            var logger = kernel.Get<ILogger>();

            logger.LogTrace("Program Start!");
        }
    }
}
