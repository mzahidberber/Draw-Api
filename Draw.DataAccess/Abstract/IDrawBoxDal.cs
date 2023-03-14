using Draw.Entities.Concrete;

namespace Draw.DataAccess.Abstract
{
    public interface IDrawBoxDal : IEntityRepository<DrawBox>
    {
        Task<DrawBox> GetDrawWithLayersAsync(string userId, int drawId);
    }
}
