using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfDrawBoxDal : EfEntityRepositoryBaseAbstract<DrawBox>, IDrawBoxDal
    {
        public EfDrawBoxDal(DrawContext context) : base(context)
        {
        }

        public async Task<DrawBox> GetDrawWithLayersAsync(string userId, int drawId)
        {
            return await _dbSet
                .Where(x => x.DrawBoxId == drawId && x.UserId == userId)
                .Include(x => x.Layers)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }
    }
}
