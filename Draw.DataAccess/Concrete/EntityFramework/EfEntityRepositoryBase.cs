﻿using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;
        public EfEntityRepositoryBase()
        {
            _context = DataInstanceFactory.GetInstance<DbContext>();
            _dbSet=_context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
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
            return entity ?? Activator.CreateInstance<TEntity>();
        }

        public IQueryable<TEntity> GetWhereAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
