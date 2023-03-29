using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPenDal : EfEntityRepositoryBaseAbstract<Pen>, IPenDal
    {
        public EfPenDal(DrawContext context) : base(context)
        {
        }

        public async Task<List<Pen>> GetAllWithAttAsync(string userId)
        {
            return await _dbSet
                .Where(x => x.PenUserId == userId)
                //.Include(x => x.PenColor)
                .Include(x=>x.PenStyle)
                .ToListAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Pen> GetPenWithColorAsync(string userId, int penId)
        {
            return await _dbSet
                .Where(x => x.PenId == penId && x.PenUserId == userId)
                //.Include(x => x.PenColor)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Pen> GetPenWithPenStyleAsync(string userId, int penId)
        {
            return await _dbSet
                .Where(x => x.PenId == penId && x.PenUserId == userId)
                .Include(x => x.PenStyle)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }
    }
}
