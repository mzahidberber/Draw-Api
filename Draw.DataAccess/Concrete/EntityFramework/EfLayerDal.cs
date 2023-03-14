using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfLayerDal : EfEntityRepositoryBaseAbstract<Layer>, ILayerDal
    {
        public EfLayerDal(DrawContext context) : base(context)
        {
           
        }

        public async Task<Layer> GetLayerWithElementsAsync(string userId, int layerId)
        {
            return await _dbSet
                .Where(x => x.LayerId == layerId && x.DrawBox.UserId == userId)
                .Include(x=>x.Elements)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Layer> GetLayerWithPenAsync(string userId, int layerId)
        {
            return await _dbSet
                .Where(x => x.LayerId == layerId && x.DrawBox.UserId == userId)
                .Include(x => x.Pen)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }
    }
}
