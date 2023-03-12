using Draw.DataAccess.Abstract.Helpers;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework.Helpers
{
    public class EfElementTypeDal:EfEntityRepositoryBase<ElementType>,IElementTypeDal
    {
    }
}
