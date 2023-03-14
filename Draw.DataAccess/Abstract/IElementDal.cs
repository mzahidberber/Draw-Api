using Draw.Entities.Concrete;

namespace Draw.DataAccess.Abstract
{
    public interface IElementDal : IEntityRepository<Element>
    {
        Task<Element> GetElementWithElementTypeAsync(string userId, int entityId);
        Task<Element> GetElementWithLayerAsync(string userId, int entityId);
        Task<Element> GetElementWithPenAsync(string userId, int entityId);
        Task<Element> GetElementWithRadiusAsync(string userId, int entityId);
        Task<Element> GetElementWithSSAnglesAsync(string userId, int entityId);
        Task<Element> GetElementWithPointsAsync(string userId, int entityId);
    }
}
