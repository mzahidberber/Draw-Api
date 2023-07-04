using Draw.Core.Business.Abstract;
using Draw.Core.DataAccess.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Web;

namespace Draw.Business.Concrete
{
    public class SubTitleManager:AbstractManager,ISubTitleService
    {
        private ISubTitleDal _subTitleDal;
        public SubTitleManager()
        {
            _subTitleDal = DataInstanceFactory.GetInstance<ISubTitleDal>();
        }

        public async Task<Response<IEnumerable<SubTitleDTO>>> AddAllAsync(List<SubTitleDTO> entities)
        {
            return await base.BaseAddAllAsync<SubTitleDTO, SubTitle>(entities, _subTitleDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync( List<int> entities)
        {
            return await base.BaseDeleteAllAsync<SubTitle>(_subTitleDal, x => entities.Contains(x.Id));
        }

        public async Task<Response<IEnumerable<SubTitleDTO>>> GetAllAsync()
        {
            return await base.BaseGetAllAsync<SubTitleDTO, SubTitle>(_subTitleDal);
        }

        public async Task<Response<SubTitleDTO>> GetAsync( int entityId)
        {
            return await base.BaseGetAsync<SubTitleDTO, SubTitle>(entityId, _subTitleDal);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(List<SubTitleDTO> entities)
        {
            return await base.BaseUpdateAsync<SubTitleDTO, SubTitle>(entities, _subTitleDal);
        }
    }
}
