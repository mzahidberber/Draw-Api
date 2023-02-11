using Draw.Business.Abstract;
using Draw.Business.Concrete;
using Ninject.Modules;

namespace Draw.Business.DependencyResolvers.Ninject
{
    internal class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDrawService>().To<DrawBusinessManager>().InSingletonScope();
            
        }
    }
}
