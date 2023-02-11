using Draw.UI.Controller.Abstract;
using Draw.UI.Controller.Concrete;
using Ninject.Modules;

namespace Draw.UI.DependencyResolvers.Ninject
{
    internal class UIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IController>().To<GraphicsScreenController>().InSingletonScope();
        }
    }
}
