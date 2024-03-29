﻿using Draw.Entities.Concrete.Draw;

namespace Draw.Core.DataAccess.Abstract
{
    public interface IPenDal : IEntityRepository<Pen>
    {
        IQueryable<Pen> GetAllWithAttAsync(string userId);
        Task<Pen> GetPenWithColorAsync(string userId, int penId);
        Task<Pen> GetPenWithPenStyleAsync(string userId, int penId);
        Task AddAsyncOnlyPen(Pen entity);
    }
}
