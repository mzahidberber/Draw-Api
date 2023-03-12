using Draw.DataAccess.Abstract;
using Draw.DataAccess.Concrete;
using Draw.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace Draw.DataAccess.DependencyResolvers.Ninject
{
    internal class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDrawCommandDal>().To<EfDrawCommandDal>().InSingletonScope();
            Bind<IDrawBoxDal>().To<EfDrawBoxDal>().InSingletonScope();
            Bind<IElementDal>().To<EfElementsDal>().InSingletonScope();
            Bind<IPointDal>().To<EfPointDal>().InSingletonScope();
            Bind<IColorDal>().To<EfColorDal>().InSingletonScope();
            Bind<IElementTypeDal>().To<EfElementTypeDal>().InSingletonScope();
            Bind<ILayerDal>().To<EfLayerDal>().InSingletonScope();
            Bind<IPenDal>().To<EfPenDal>().InSingletonScope();
            Bind<IPenStyleDal>().To<EfPenStyleDal>().InSingletonScope();
            Bind<IPointTypeDal>().To<EfPointTypeDal>().InSingletonScope();
            Bind<DrawContext>().To<DrawContext>().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            
        }
    }
}
