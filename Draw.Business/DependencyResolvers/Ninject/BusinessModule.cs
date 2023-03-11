using Draw.Business.Abstract;
using Draw.Business.Concrete;
using Ninject.Modules;

namespace Draw.Business.DependencyResolvers.Ninject
{
    internal class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IUserService>().To<UserManager>().InSingletonScope();
            //Bind<IDrawService>().To<DrawBusinessManager>().InSingletonScope();
            Bind<IColorService>().To<ColorManager>().InSingletonScope();
            Bind<IDrawBoxService>().To<DrawBoxManager>().InSingletonScope();
            Bind<IElementService>().To<ElementManager>().InSingletonScope();
            Bind<IElementTypeService>().To<IElementTypeManager>().InSingletonScope();
            Bind<ILayerService>().To<LayerManager>().InSingletonScope();
            Bind<IPenService>().To<PenManager>().InSingletonScope();
            Bind<IPenStyleService>().To<PenStyleManager>().InSingletonScope();
            Bind<IPointService>().To<PointManager>().InSingletonScope();
            Bind<IPointTypeService>().To<PointTypeManager>().InSingletonScope();
        }
    }
}
