using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Abstract
{
    public interface IElementService:IBaseService<ElementDTO>
    {
        Task<Response<IEnumerable<ElementDTO>>> GetAllWithAttAsync(string userId);
        Task<Response<IEnumerable<ElementDTO>>> GetAllByDrawAsync(string userId,int drawId);
        Task<Response<IEnumerable<ElementDTO>>> GetAllByDrawWithAttAsync(string userId,int drawId);
        Task<Response<IEnumerable<ElementDTO>>> GetAllByLayerAsync(string userId,int layerId);
        Task<Response<IEnumerable<ElementDTO>>> GetAllByLayerWithAttAsync(string userId,int layerId);
        Task<Response<PenDTO>> GetPenAsync(string userId,int entityId);
        Task<Response<ElementTypeDTO>> GetElementTypeAsync(string userId, int entityId);
        Task<Response<LayerDTO>> GetLayerAsync(string userId, int entityId);
        Task<Response<IEnumerable<RadiusDTO>>> GetRadiusesAsync(string userId, int entityId);
        Task<Response<IEnumerable<SSAngleDTO>>> GetSSAnglesAsync(string userId, int entityId);
        Task<Response<IEnumerable<PointDTO>>> GetPointsAsync(string userId, int entityId);
        Task<Response<IEnumerable<ElementDTO>>> AddAllAsync(int drawBoxId, List<ElementDTO> entities);


    }
}
