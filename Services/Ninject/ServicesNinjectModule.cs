using JsonService;
using Ninject;
using Ninject.Modules;
using ServiceAbstractions.Interfaces;
using Services.Concrete;

namespace Services.Ninject
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHttpService>().To<HttpService>().InSingletonScope();
            Kernel.Load<JsonServiceNinjectModule>();
        }
    }
}