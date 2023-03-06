using Draw.DataAccess.Abstract;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Draw.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DbContext _context;
        public UnitOfWork(DrawContext drawDbContext)
        {
            _context = drawDbContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
