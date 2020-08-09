using Ninject.Modules;
using Repository.Abstractions;
using Repository.Concrete;

namespace Repository
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggingRepository>().To<FileLoggingRepository>();
        }
    }
}