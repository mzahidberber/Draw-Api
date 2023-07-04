using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Core.Business.Abstract
{
    public interface ILayerService:IBaseService<LayerDTO>
    {
        Task<Response<IEnumerable<LayerDTO>>> GetAllByDrawAsync(string userId,int drawId);
        Task<Response<IEnumerable<LayerDTO>>> GetAllByDrawWithPenAsync(string userId,int drawId);
        Task<Response<IEnumerable<ElementDTO>>> GetElementsAsync(string userId,int entityId);
        Task<Response<PenDTO>> GetPenAsync(string userId, int entityId);
        Task<Response<IEnumerable<LayerDTO>>> AddAllAttAsync(string userId, int drawBoxId, List<LayerDTO> entities);

    }
}
