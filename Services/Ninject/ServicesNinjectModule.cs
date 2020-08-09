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

            /* --== Service Layer ==-- */
            Bind<IHttpService>().To<HttpService>().InSingletonScope();
            // ReSharper disable once AssignNullToNotNullAttribute
            Kernel.Load<JsonServiceNinjectModule>();

            /* --== Repository Layer ==-- */
            Kernel.Load<RepositoryNinjectModule>();
        }
    }
}