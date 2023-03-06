using Draw.Business.Abstract.BaseSevice;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Abstract
{
    public interface IElementService:IBaseService<ElementDTO>
    {
        Task<PenDTO> GetPenAsync(int entityId);
        Task<ElementTypeDTO> GetElementTypeAsync(int entityId);
        Task<LayerDTO> GetLayerAsync(int entityId);
        Task<IEnumerable<RadiusDTO>> GetRadiusesAsync(int entityId);
        Task<IEnumerable<SSAngleDTO>> GetSSAnglesAsync(int entityId);
        Task<IEnumerable<PointDTO>> GetPointsAsync(int entityId);
        
    }
}
