using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DataAccess.Abstract;
using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Draw;
using Microsoft.EntityFrameworkCore;
using Draw.Core.DataAccess.Abstract;
namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPenDal : EfEntityRepositoryBaseAbstract<Pen>, IPenDal
    {
        public EfPenDal(DrawContext context) : base(context)
        {
        }

        public IQueryable<Pen> GetAllWithAttAsync(string userId)
        {
            return _dbSet
                .Where(x => x.UserId == userId)
                //.Include(x => x.PenColor)
                .Include(x=>x.PenStyle).AsQueryable();
        }

        public async Task<Pen> GetPenWithColorAsync(string userId, int penId)
        {
            return await _dbSet
                .Where(x => x.Id == penId && x.UserId == userId)
                //.Include(x => x.PenColor)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task<Pen> GetPenWithPenStyleAsync(string userId, int penId)
        {
            return await _dbSet
                .Where(x => x.Id == penId && x.UserId == userId)
                .Include(x => x.PenStyle)
                .SingleOrDefaultAsync() ?? throw new CustomException("Entity Not Found");
        }

        public async Task AddAsyncOnlyPen(Pen entity)
        {
            _context.Entry(entity.PenStyle).State = EntityState.Detached;
            await _dbSet.AddAsync(entity);
        }
    }
}
