﻿using Draw.DataAccess.Abstract.Commands;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework.Commands
{
    public class EfDrawCommandDal:EfEntityRepositoryBase<DrawCommand>,IDrawCommandDal
    {
    }
}
