using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.Business.Concrete
{
    public class RadiusManager :AbstractManager, IRadiusService
    {
        private readonly IRadiusDal _radiusDal;
        public RadiusManager()
        {
            _radiusDal=DataInstanceFactory.GetInstance<IRadiusDal>();
        }

        public async Task<Response<IEnumerable<RadiusDTO>>> AddAllAsync(List<RadiusDTO> entities)
        {
            return await base.BaseAddAllAsync<RadiusDTO, Radius>(entities, _radiusDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            return await base.BaseDeleteAllAsync<Radius>(_radiusDal, x => entities.Contains(x.Id) && x.Element.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<IEnumerable<RadiusDTO>>> GetAllAsync(string userId)
        {
            return await base.BaseGetAllAsync<RadiusDTO, Radius>(_radiusDal, e => e.Element.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<RadiusDTO>> GetAsync(string userId, int entityId)
        {
            return await base.BaseGetWhereAsync<RadiusDTO, Radius>(_radiusDal, x => x.Id == entityId && x.Element.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<RadiusDTO> entities)
        {
            return await base.BaseUpdateAsync<RadiusDTO, Radius>(entities, _radiusDal, () =>
            {
                var idList = entities.Select(x => x.Id).ToList();
                var elementsCount = _radiusDal.GetWhereAsync(x => idList.Contains(x.Id) && x.Element.Layer.DrawBox.UserId == userId).Count();
                if (elementsCount != entities.Count) return false;
                else return true;
            });
        }
    }
}
