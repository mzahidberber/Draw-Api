using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Concrete
{
    public class PointManager : IPointService
    {
        public Task<Response<IEnumerable<PointDTO>>> AddAllAsync(List<PointDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PointDTO>>> GetAllAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PointDTO>>> GetAllByDrawAsync(string userId, int drawId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PointDTO>>> GetAllByElementAsync(string userId, int elementId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PointDTO>>> GetAllByLayerAsync(string userId, int layerId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PointDTO>> GetAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ElementDTO>> GetElementAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PointTypeDTO>> GetPointTypeAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<PointDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
