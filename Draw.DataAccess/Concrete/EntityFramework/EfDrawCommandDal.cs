using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;
using System.Linq.Expressions;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfDrawCommandDal : EfEntityRepositoryBaseAbstract<DrawCommand>, IDrawCommandDal
    {
        public EfDrawCommandDal(DrawContext context) : base(context)
        {
        }

       
    }
}
