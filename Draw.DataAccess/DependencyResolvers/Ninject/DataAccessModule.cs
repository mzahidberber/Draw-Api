﻿using Draw.DataAccess.Abstract;
using Draw.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace Draw.DataAccess.DependencyResolvers.Ninject
{
    internal class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            
            //Bind<DrawContext>().ToSelf();
            Bind<IDrawCommandDal>().To<EfDrawCommandDal>();
            Bind<IDrawBoxDal>().To<EfDrawBoxDal>();
            Bind<IElementDal>().To<EfElementsDal>();
            Bind<IPointDal>().To<EfPointDal>();
            Bind<IColorDal>().To<EfColorDal>();
            Bind<IElementTypeDal>().To<EfElementTypeDal>();
            Bind<ILayerDal>().To<EfLayerDal>();
            Bind<IPenDal>().To<EfPenDal>();
            Bind<IPenStyleDal>().To<EfPenStyleDal>();
            Bind<IPointTypeDal>().To<EfPointTypeDal>();
            Bind<IRadiusDal>().To<EfRadiusDal>();
            Bind<ISSAngleDal>().To<EfSSAngleDal>();

        }
    }
}
