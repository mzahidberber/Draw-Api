using Draw.Core.Business.Abstract;
using Draw.Core.DataAccess.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Web;

namespace Draw.Business.Concrete
{
    internal class NumbersManager : AbstractManager, INumbersService
    {
        private INumbersDal _numbersDal;
        public NumbersManager()
        {
            _numbersDal = DataInstanceFactory.GetInstance<INumbersDal>();
        }

        
        public async Task<Response<IEnumerable<NumbersDTO>>> AddAllAsync(List<NumbersDTO> entities)
        {
            return await base.BaseAddAllAsync<NumbersDTO, Numbers>(entities, _numbersDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            return await base.BaseDeleteAllAsync<Numbers>(_numbersDal, x => entities.Contains(x.Id));
        }

        public async Task<Response<IEnumerable<NumbersDTO>>> GetAllAsync()
        {
            return await base.BaseGetAllAsync<NumbersDTO, Numbers>(_numbersDal);
        }

        public async Task<Response<NumbersDTO>> GetAsync(int entityId)
        {
            return await base.BaseGetAsync<NumbersDTO, Numbers>(entityId, _numbersDal);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(List<NumbersDTO> entities)
        {
            return await base.BaseUpdateAsync<NumbersDTO, Numbers>(entities, _numbersDal);
        }
    }
}
