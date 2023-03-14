using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBaseAbstract<Color>, IColorDal
    {
        public EfColorDal(DrawContext context) : base(context)
        {
        }

    }
}
