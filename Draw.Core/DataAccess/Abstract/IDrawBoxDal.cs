using Draw.Entities.Concrete.Draw;

namespace Draw.Core.DataAccess.Abstract
{
    public interface IDrawBoxDal : IEntityRepository<DrawBox>
    {
        Task<DrawBox> GetDrawWithLayersAsync(string userId, int drawId);
    }
}
