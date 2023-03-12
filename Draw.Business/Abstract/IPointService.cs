using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Abstract
{
    public interface IPointService:IBaseService<PointDTO>
    {
        Task<Response<IEnumerable<PointDTO>>> GetAllByElementAsync(string userId,int elementId);
        Task<Response<IEnumerable<PointDTO>>> GetAllByDrawAsync(string userId,int drawId);
        Task<Response<IEnumerable<PointDTO>>> GetAllByLayerAsync(string userId,int layerId);
        Task<Response<ElementDTO>> GetElementAsync(string userId, int entityId);
        Task<Response<PointTypeDTO>> GetPointTypeAsync(string userId, int entityId);
    }
}
