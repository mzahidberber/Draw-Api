using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete.Draw;
using Draw.Core.DataAccess.Abstract;
namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfDrawCommandDal : EfEntityRepositoryBaseAbstract<DrawCommand>, IDrawCommandDal
    {
        public EfDrawCommandDal(DrawContext context) : base(context)
        {
        }

       
    }
}
