using Draw.Core.DataAccess.Abstract;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete.Web;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfNumbersDal: EfEntityRepositoryBaseAbstract<Numbers>, INumbersDal
    {
        public EfNumbersDal(DrawContext context) : base(context)
        {

        }
    }
}
