using Draw.DataAccess.Abstract;
using Draw.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected readonly DrawContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IDbContextTransaction transaction;
        public EfEntityRepositoryBase(DrawContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            transaction = _context.Database.BeginTransaction();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            //_context.SaveChanges();
        }

        public bool Commit(bool state = true)
        {
            _context.SaveChanges();
            if (state)
                transaction.Commit();
            else
                transaction.Rollback();

            //Dispose();
            return true;
        }

        public async Task<bool> CommitAsync(bool state = true)
        {
            await _context.SaveChangesAsync();
            if (state)
                await transaction.CommitAsync();
            else
                await transaction.RollbackAsync();

            //Dispose();
            return true;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public IQueryable<TEntity> GetWhereAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public virtual bool IsUserEntity(int entityId, string userId)
        {
            return false;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
