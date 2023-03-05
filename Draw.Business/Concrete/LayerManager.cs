

using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;

namespace Draw.Business.Concrete
{
    public class LayerManager : ILayerService
    {
        IUserService _userManager;
        public LayerManager()
        {
            _userManager=InstanceFactory.GetInstance<IUserService>();
        }

        public Task<Response<IEnumerable<LayerDTO>>> AddAllAsync(List<LayerDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(List<int> entitiesId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<LayerDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<LayerDTO>> GetAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ElementDTO>>> GetElementsAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PenDTO>> GetPenAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(List<LayerDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
