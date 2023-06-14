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

        public IQueryable<Layer> GetAllByDrawWithPenAsync(string userId, int drawId)
        {
            return _dbSet
                .Where(x => x.DrawBoxId == drawId && x.DrawBox.UserId == userId)
                .Include(x => x.Pen)
                //.ThenInclude(x=>x.PenColor)
                //.Include(x => x.Pen)
                .ThenInclude(x => x.PenStyle).AsQueryable();
        }

        public async Task<Layer> GetLayerWithElementsAsync(string userId, int layerId)
        {
            return await _dbSet
                .Where(x => x.Id == layerId && x.DrawBox.UserId == userId)
                .Include(x=>x.Elements)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Layer> GetLayerWithPenAsync(string userId, int layerId)
        {
            return await _dbSet
                .Where(x => x.Id == layerId && x.DrawBox.UserId == userId)
                .Include(x => x.Pen)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }
    }
}
