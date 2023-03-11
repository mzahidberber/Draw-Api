using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Concrete
{
    public class PenManager : IPenService
    {
        public Task<Response<IEnumerable<PenDTO>>> AddAllAsync(List<PenDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PenDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<PenDTO>> GetAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<ColorDTO> GetColorAsync(int penId)
        {
            throw new NotImplementedException();
        }

        public Task<PenStyleDTO> GetPenStyleAsync(int penId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(List<PenDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
