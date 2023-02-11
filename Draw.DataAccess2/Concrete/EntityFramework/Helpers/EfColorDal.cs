using Draw.DataAccess.Abstract.Helpers;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete.Helpers;

namespace Draw.DataAccess.Concrete.EntityFramework.Helpers
{
    public class EfColorDal:EfEntityRepositoryBase<Color,DrawContext>,IColorDal
    {
    }
}
