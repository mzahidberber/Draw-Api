using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete.Draw;
using Draw.Core.DataAccess.Abstract;
namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPenStyleDal : EfEntityRepositoryBaseAbstract<PenStyle>, IPenStyleDal
    {
        public EfPenStyleDal(DrawContext context) : base(context)
        {
        }

        
    }
}
