using Draw.DataAccess.Abstract.Helpers;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.DataAccess.Concrete.EntityFramework.Helpers
{
    public class EfElementTypeDal:EfEntityRepositoryBase<ElementType,DrawContext>,IElementTypeDal
    {
    }
}
