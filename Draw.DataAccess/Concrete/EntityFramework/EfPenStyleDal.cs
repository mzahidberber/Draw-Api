using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;
using System.Linq.Expressions;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPenStyleDal : EfEntityRepositoryBaseAbstract<PenStyle>, IPenStyleDal
    {
        public EfPenStyleDal(DrawContext context) : base(context)
        {
        }

        
    }
}
