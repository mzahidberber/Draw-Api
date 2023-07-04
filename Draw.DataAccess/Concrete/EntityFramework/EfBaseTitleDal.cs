

using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.DataAccess.Abstract;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Web;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfBaseTitleDal:EfEntityRepositoryBaseAbstract<BaseTitle>,IBaseTitleDal
    {
        public EfBaseTitleDal(DrawContext context) : base(context)
        {
            
        }

        
    }
}
