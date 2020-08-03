using System;
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
            Bind<IHttpService>().To<HttpService>();

            if(Kernel is null)
                throw new ApplicationException("Ninject Kernel is null. Cannot proceed.");

            Kernel.Load<JsonServiceNinjectModule>();
        }
    }
}