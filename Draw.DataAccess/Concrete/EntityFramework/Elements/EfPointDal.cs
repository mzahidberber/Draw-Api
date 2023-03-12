using Draw.DataAccess.Abstract.Elements;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework.Elements
{
    public class EfPointDal:EfEntityRepositoryBase<Point>,IPointDal
    {
    }
}
