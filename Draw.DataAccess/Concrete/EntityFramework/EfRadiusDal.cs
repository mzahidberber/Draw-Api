using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfRadiusDal : EfEntityRepositoryBaseAbstract<Radius>, IRadiusDal
    {
        public EfRadiusDal(DrawContext context) : base(context)
        {
        }
    }
}
