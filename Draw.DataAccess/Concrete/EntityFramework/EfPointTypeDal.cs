using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete.Draw;
using Draw.Core.DataAccess.Abstract;
namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPointTypeDal : EfEntityRepositoryBaseAbstract<PointType>, IPointTypeDal
    {
        public EfPointTypeDal(DrawContext context) : base(context)
        {
        }

       
    }
}
