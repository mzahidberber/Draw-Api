using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete.Draw;
using Microsoft.EntityFrameworkCore;
using Draw.Core.DataAccess.Abstract;
namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfRadiusDal : EfEntityRepositoryBaseAbstract<Radius>, IRadiusDal
    {
        public EfRadiusDal(DrawContext context) : base(context)
        {
        }
    }
}
