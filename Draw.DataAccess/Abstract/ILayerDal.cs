using Draw.Entities.Concrete;

namespace Draw.DataAccess.Abstract
{
    public interface ILayerDal : IEntityRepository<Layer>
    {
        Task<Layer> GetLayerWithElementsAsync(string userId, int layerId);
        Task<Layer> GetLayerWithPenAsync(string userId, int layerId);
    }
}
