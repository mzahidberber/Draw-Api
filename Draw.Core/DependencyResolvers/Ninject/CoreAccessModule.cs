

using Draw.Core.Services;
using Draw.Core.Services.Abstract;
using Ninject.Modules;

namespace Draw.Core.DependencyResolvers.Ninject
{
    internal class CoreAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGeoService>().To<GeoService>().InSingletonScope();

        }
    }
}
