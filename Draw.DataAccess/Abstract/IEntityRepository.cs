﻿using Draw.Entities.Abstract;
using System.Linq.Expressions;

namespace Draw.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        IQueryable<T> GetAllAsync(Expression<Func<T,bool>>? filter =null);
        IQueryable<T> GetWhereAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool IsUserEntity(int entityId,string userId);
    }
}
