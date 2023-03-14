using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPointDal : EfEntityRepositoryBaseAbstract<Point>, IPointDal
    {
        public EfPointDal(DrawContext context) : base(context)
        {
        }

        public async Task<Point> GetPointWithElementAsync(string userId, int pointId)
        {
            return await _dbSet
                .Where(x => x.PointId == pointId && x.Element.Layer.DrawBox.UserId == userId)
                .Include(x => x.Element)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Point> GetPointWithPointTypeAsync(string userId, int pointId)
        {
            return await _dbSet
                .Where(x => x.PointId == pointId && x.Element.Layer.DrawBox.UserId == userId)
                .Include(x => x.PointType)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }
    }
}
