﻿using Draw.Entities.Concrete;

namespace Draw.DataAccess.Abstract
{
    public interface ILayerDal : IEntityRepository<Layer>
    {
        Task<Layer> GetLayerWithElementsAsync(string userId, int layerId);
        Task<List<Layer>> GetAllByDrawWithPenAsync(string userId, int drawId);
        Task<Layer> GetLayerWithPenAsync(string userId, int layerId);
    }
}
