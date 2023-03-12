using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPenStyleDal : EfEntityRepositoryBase<PenStyle>, IPenStyleDal
    {
        public EfPenStyleDal(DrawContext context) : base(context)
        {
        }
    }
}
