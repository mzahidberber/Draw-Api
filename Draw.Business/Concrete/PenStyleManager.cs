using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.Business.Concrete
{
    public class PenStyleManager :AbstractManager, IPenStyleService
    {
        private IPenStyleDal _penStyleDal;
        public PenStyleManager()
        {
            _penStyleDal=DataInstanceFactory.GetInstance<IPenStyleDal>();
        }
        public async Task<Response<IEnumerable<PenStyleDTO>>> AddAllAsync(List<PenStyleDTO> entities)
        {
            return await base.BaseAddAllAsync<PenStyleDTO, PenStyle>(entities, _penStyleDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            return await base.BaseDeleteAllAsync<PenStyle>(entities, _penStyleDal);
        }

        public async Task<Response<IEnumerable<PenStyleDTO>>> GetAllAsync()
        {
            return await base.BaseGetAllAsync<PenStyleDTO, PenStyle>( _penStyleDal);
        }

        public async Task<Response<PenStyleDTO>> GetAsync(int entityId)
        {
            return await base.BaseGetAsync<PenStyleDTO, PenStyle>(entityId, _penStyleDal);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(List<PenStyleDTO> entities)
        {
            return await base.BaseUpdateAsync<PenStyleDTO, PenStyle>(entities, _penStyleDal);
        }
    }
}
