using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Concrete
{
    public class PointManager : IPointService
    {
        public Task<Response<IEnumerable<PointDTO>>> AddAllAsync(List<PointDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PointDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<PointDTO>> GetAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<ElementDTO> GetElementAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<PointTypeDTO> GetPointTypeAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(List<PointDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
