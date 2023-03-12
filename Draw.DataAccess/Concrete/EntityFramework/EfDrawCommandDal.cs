using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfDrawCommandDal : EfEntityRepositoryBase<DrawCommand>, IDrawCommandDal
    {
        public EfDrawCommandDal(DrawContext context) : base(context)
        {
        }
    }
}
