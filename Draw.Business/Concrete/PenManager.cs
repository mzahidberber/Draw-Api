using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Concrete
{
    public class PenManager : IPenService
    {
        public Task<Response<IEnumerable<PenDTO>>> AddAllAsync(List<PenDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PenDTO>>> GetAllAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PenDTO>> GetAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ColorDTO>> GetColorAsync(string userId, int penId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PenStyleDTO>> GetPenStyleAsync(string userId, int penId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<PenDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
