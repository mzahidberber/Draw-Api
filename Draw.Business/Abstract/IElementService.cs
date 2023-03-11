using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Abstract
{
    public interface IElementService:IBaseService<ElementDTO>
    {
        Task<Response<PenDTO>> GetPenAsync(int entityId);
        Task<Response<ElementTypeDTO>> GetElementTypeAsync(int entityId);
        Task<Response<LayerDTO>> GetLayerAsync(int entityId);
        Task<Response<IEnumerable<RadiusDTO>>> GetRadiusesAsync(int entityId);
        Task<Response<IEnumerable<SSAngleDTO>>> GetSSAnglesAsync(int entityId);
        Task<Response<IEnumerable<PointDTO>>> GetPointsAsync(int entityId);
        
    }
}
