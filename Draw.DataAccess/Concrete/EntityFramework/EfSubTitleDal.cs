

using Draw.Core.DataAccess.Abstract;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete.Web;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfSubTitleDal:EfEntityRepositoryBaseAbstract<SubTitle>,ISubTitleDal
    {
        public EfSubTitleDal(DrawContext context):base(context)
        {
            
        }
    }
}
