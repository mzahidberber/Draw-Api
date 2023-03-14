using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Draw.DataAccess.Concrete.EntityFramework
{

    public class EfElementsDal : EfEntityRepositoryBaseAbstract<Element>, IElementDal
    {
        public EfElementsDal(DrawContext context) : base(context)
        {
        }

        public async Task<Element> GetElementWithElementTypeAsync(string userId, int entityId)
        {
            return await _dbSet
                .Where(x => x.ElementId == entityId && x.Layer.DrawBox.UserId==userId)
                .Include(x => x.ElementType)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Element> GetElementWithLayerAsync(string userId, int entityId)
        {
            return await _dbSet
                .Where(x => x.ElementId == entityId && x.Layer.DrawBox.UserId == userId)
                .Include(x => x.Layer)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Element> GetElementWithPenAsync(string userId, int entityId)
        {
            return await _dbSet
                .Where(x => x.ElementId == entityId && x.Layer.DrawBox.UserId == userId)
                .Include(x => x.Pen)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Element> GetElementWithPointsAsync(string userId, int entityId)
        {
            return await _dbSet
                .Where(x => x.ElementId == entityId && x.Layer.DrawBox.UserId == userId)
                .Include(x => x.Points)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Element> GetElementWithSSAnglesAsync(string userId, int entityId)
        {
            return await _dbSet
                .Where(x => x.ElementId == entityId && x.Layer.DrawBox.UserId == userId)
                .Include(x => x.SSAngles)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Element> GetElementWithRadiusAsync(string userId, int entityId)
        {
            return await _dbSet
                .Where(x => x.ElementId == entityId && x.Layer.DrawBox.UserId == userId)
                .Include(x => x.Radiuses)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

    }
}
