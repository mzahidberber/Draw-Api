using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Concrete
{
    public class DrawBoxManager : IDrawBoxService
    {
        public Task<Response<IEnumerable<DrawBoxDTO>>> AddAllAsync(List<DrawBoxDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<DrawBoxDTO>>> GetAllAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<DrawBoxDTO>> GetAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<LayerDTO>>> GetLayersAsync(string userId, int drawId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<DrawBoxDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
