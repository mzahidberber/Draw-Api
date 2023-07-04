using Draw.Core.Business.Abstract;
using Draw.Core.DataAccess.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Draw;

namespace Draw.Business.Concrete
{
    public class SSAngleManager :AbstractManager, ISSAngleService
    {
        private readonly ISSAngleDal _ssangleDal;
        public SSAngleManager()
        {
            _ssangleDal=DataInstanceFactory.GetInstance<ISSAngleDal>();
        }

        public async Task<Response<IEnumerable<SSAngleDTO>>> AddAllAsync(List<SSAngleDTO> entities)
        {
            return await base.BaseAddAllAsync<SSAngleDTO, SSAngle>(entities, _ssangleDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            return await base.BaseDeleteAllAsync<SSAngle>(_ssangleDal, x => entities.Contains(x.Id) && x.Element.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<IEnumerable<SSAngleDTO>>> GetAllAsync(string userId)
        {
            return await base.BaseGetAllAsync<SSAngleDTO, SSAngle>(_ssangleDal, e => e.Element.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<SSAngleDTO>> GetAsync(string userId, int entityId)
        {
            return await base.BaseGetWhereAsync<SSAngleDTO, SSAngle>(_ssangleDal, x => x.Id == entityId && x.Element.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<SSAngleDTO> entities)
        {
            return await base.BaseUpdateAsync<SSAngleDTO, SSAngle>(entities, _ssangleDal, () =>
            {
                var idList = entities.Select(x => x.Id).ToList();
                var elementsCount = _ssangleDal.GetWhereAsync(x => idList.Contains(x.Id) && x.Element.Layer.DrawBox.UserId == userId).Count();
                if (elementsCount != entities.Count) return false;
                else return true;
            });
        }
    }
}
