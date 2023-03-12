using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.Concrete.EntityFramework;
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

        public Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<LayerDTO>>> GetAllAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<LayerDTO>>> GetAllByDrawAsync(string userId, int drawId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<LayerDTO>> GetAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ElementDTO>>> GetElementsAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PenDTO>> GetPenAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<LayerDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
