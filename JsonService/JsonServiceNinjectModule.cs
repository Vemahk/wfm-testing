using JsonService.Services;
using JsonService.Services.Abstractions;
using Ninject.Modules;

namespace JsonService
{
    public class JsonServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IJsonRequestService>().To<JsonRequestService>();
        }
    }
}