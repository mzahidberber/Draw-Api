using Draw.DataAccess.Abstract;
using Draw.DataAccess.Abstract.Commands;
using Draw.DataAccess.Abstract.Draws;
using Draw.DataAccess.Abstract.Elements;
using Draw.DataAccess.Abstract.Helpers;
using Draw.DataAccess.Abstract.Users;
using Draw.DataAccess.Concrete.EntityFramework.Commands;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.DataAccess.Concrete.EntityFramework.Draws;
using Draw.DataAccess.Concrete.EntityFramework.Elements;
using Draw.DataAccess.Concrete.EntityFramework.Helpers;
using Draw.DataAccess.Concrete.EntityFramework.Users;
using Microsoft.EntityFrameworkCore;
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
            Bind<EfPenStyleDal>().To<EfPenStyleDal>().InSingletonScope();
            Bind<IPointTypeDal>().To<EfPointTypeDal>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
            Bind<DbContext>().To<DrawContext>().InSingletonScope();
            
        }
    }
}
