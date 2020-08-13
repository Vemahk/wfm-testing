using System;
using JsonService;
using Ninject;
using Ninject.Modules;
using Repository;
using ServiceAbstractions.Interfaces;
using Services.Concrete;

namespace Services.Ninject
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            if(Kernel == null)
                throw new ApplicationException("Cannot precede without a Ninject Kernel.");

            var appName = Kernel.Settings.Get("appName", "GenericApplication");

            /* --== Service Layer ==-- */
            Bind<IHttpService>().To<HttpService>().InSingletonScope();
            Bind<ILogger>().To<Logger>().InSingletonScope().WithConstructorArgument("appName", appName ?? string.Empty);
            // ReSharper disable once AssignNullToNotNullAttribute
            Kernel.Load<JsonServiceNinjectModule>();

            /* --== Repository Layer ==-- */
            Kernel.Load<RepositoryNinjectModule>();
        }
    }
}