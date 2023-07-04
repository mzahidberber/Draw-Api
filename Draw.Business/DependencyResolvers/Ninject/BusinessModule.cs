using Draw.Business.Concrete;
using Draw.Core.Business.Abstract;
using Ninject.Modules;

namespace Draw.Business.DependencyResolvers.Ninject
{
    internal class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDrawService>().To<DrawManager>().InSingletonScope();
            Bind<IDrawBoxService>().To<DrawBoxManager>().InSingletonScope();
            Bind<IElementService>().To<ElementManager>().InSingletonScope();
            Bind<IElementTypeService>().To<ElementTypeManager>().InSingletonScope();
            Bind<ILayerService>().To<LayerManager>().InSingletonScope();
            Bind<IPenService>().To<PenManager>().InSingletonScope();
            Bind<IPenStyleService>().To<PenStyleManager>().InSingletonScope();
            Bind<IPointService>().To<PointManager>().InSingletonScope();
            Bind<IPointTypeService>().To<PointTypeManager>().InSingletonScope();
            Bind<ISSAngleService>().To<SSAngleManager>().InSingletonScope();
            Bind<IRadiusService>().To<RadiusManager>().InSingletonScope();
            Bind<IMainTitleService>().To<MainTitleManager>().InSingletonScope();
            Bind<IBaseTitleService>().To<BaseTitleManager>().InSingletonScope();
            Bind<ISubTitleService>().To<SubTitleManager>().InSingletonScope();
        }
    }
}
