using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfSSAngleDal : EfEntityRepositoryBaseAbstract<SSAngle>, ISSAngleDal
    {
        public EfSSAngleDal(DrawContext context) : base(context)
        {
        }
    }
}
