using Draw.Entities.Concrete;

namespace Draw.DataAccess.Abstract
{
    public interface IPointDal : IEntityRepository<Point>
    {
        Task<Point> GetPointWithElementAsync(string userId, int pointId);
        Task<Point> GetPointWithPointTypeAsync(string userId, int pointId);
    }
}
