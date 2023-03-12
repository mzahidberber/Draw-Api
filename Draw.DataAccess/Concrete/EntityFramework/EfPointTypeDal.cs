using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPointTypeDal : EfEntityRepositoryBase<PointType>, IPointTypeDal
    {
        public EfPointTypeDal(DrawContext context) : base(context)
        {
        }
    }
}
