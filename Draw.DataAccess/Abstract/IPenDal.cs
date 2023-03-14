using Draw.Entities.Concrete;

namespace Draw.DataAccess.Abstract
{
    public interface IPenDal : IEntityRepository<Pen>
    {
        Task<Pen> GetPenWithColorAsync(string userId, int penId);
        Task<Pen> GetPenWithPenStyleAsync(string userId, int penId);
    }
}
