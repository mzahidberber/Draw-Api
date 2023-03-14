using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.Business.Concrete
{
    public class LayerManager :AbstractManager, ILayerService
    {
        private readonly ILayerDal _layerDal;
        public LayerManager()
        {
            _layerDal=DataInstanceFactory.GetInstance<ILayerDal>(); 
        }
        
        public async Task<Response<IEnumerable<LayerDTO>>> AddAllAsync(List<LayerDTO> entities)
        {
            return await base.BaseAddAllAsync<LayerDTO, Layer>(entities, _layerDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            return await base.BaseDeleteAllAsync<Layer>(_layerDal, x => entities.Contains(x.LayerId) && x.DrawBox.UserId == userId);
        }

        public async Task<Response<IEnumerable<LayerDTO>>> GetAllAsync(string userId)
        {
            return await base.BaseGetAllAsync<LayerDTO, Layer>(_layerDal, e => e.DrawBox.UserId == userId);
        }

        public async Task<Response<IEnumerable<LayerDTO>>> GetAllByDrawAsync(string userId, int drawId)
        {
            return await base.BaseGetAllAsync<LayerDTO, Layer>(_layerDal, e => e.DrawBox.UserId == userId && e.DrawBoxId==drawId);
        }

        public async Task<Response<LayerDTO>> GetAsync(string userId, int entityId)
        {
            return await base.BaseGetWhereAsync<LayerDTO, Layer>(_layerDal, x => x.LayerId == entityId && x.DrawBox.UserId == userId);
        }

        public async Task<Response<IEnumerable<ElementDTO>>> GetElementsAsync(string userId, int entityId)
        {
            var layer = await _layerDal.GetLayerWithElementsAsync(userId, entityId);
            var elements = layer.Elements.Select(x=>ObjectMapper.Mapper.Map<ElementDTO>(x));
            return Response<IEnumerable<ElementDTO>>.Success(elements, 200);
        }

        public async Task<Response<PenDTO>> GetPenAsync(string userId, int entityId)
        {
            var layer = await _layerDal.GetLayerWithPenAsync(userId, entityId);
            return Response<PenDTO>.Success(ObjectMapper.Mapper.Map<PenDTO>(layer.Pen), 200);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<LayerDTO> entities)
        {
            return await base.BaseUpdateAsync<LayerDTO, Layer>(entities, _layerDal, () =>
            {
                var idList = entities.Select(x => x.LayerId).ToList();
                var elementsCount = _layerDal.GetWhereAsync(x => idList.Contains(x.LayerId) && x.DrawBox.UserId == userId).Count();
                if (elementsCount != entities.Count) throw new CustomException("Entity Not Found");
            });
        }
    }
}
