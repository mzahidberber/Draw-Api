using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPointDal : EfEntityRepositoryBase<Point>, IPointDal
    {
        public EfPointDal(DrawContext context) : base(context)
        {
        }
    }
}
