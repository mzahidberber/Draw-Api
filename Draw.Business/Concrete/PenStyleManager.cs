using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Concrete
{
    public class PenStyleManager : IPenStyleService
    {
        public Task<Response<IEnumerable<PenStyleDTO>>> AddAllAsync(List<PenStyleDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PenStyleDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<PenStyleDTO>> GetAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(List<PenStyleDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
