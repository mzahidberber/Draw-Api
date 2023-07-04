using Draw.Core.Business.Abstract;
using Draw.Core.DataAccess.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Web;

namespace Draw.Business.Concrete
{
    public class BaseTitleManager : AbstractManager, IBaseTitleService
    {
        private IBaseTitleDal _baseTitleDal;
        public BaseTitleManager()
        {
            _baseTitleDal = DataInstanceFactory.GetInstance<IBaseTitleDal>();
        }

        public async Task<Response<IEnumerable<BaseTitleDTO>>> AddAllAsync(List<BaseTitleDTO> entities)
        {
            return await base.BaseAddAllAsync<BaseTitleDTO, BaseTitle>(entities, _baseTitleDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            return await base.BaseDeleteAllAsync<BaseTitle>(_baseTitleDal, x => entities.Contains(x.Id));
        }

        public async Task<Response<IEnumerable<BaseTitleDTO>>> GetAllAsync()
        {
            return await base.BaseGetAllAsync<BaseTitleDTO, BaseTitle>(_baseTitleDal);
        }

        public async Task<Response<BaseTitleDTO>> GetAsync(int entityId)
        {
            return await base.BaseGetAsync<BaseTitleDTO, BaseTitle>(entityId, _baseTitleDal);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync( List<BaseTitleDTO> entities)
        {
            return await base.BaseUpdateAsync<BaseTitleDTO, BaseTitle>(entities, _baseTitleDal);
        }
    }
}
