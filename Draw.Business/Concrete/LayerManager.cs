

using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.DTOs;
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

        public Task<Response<IEnumerable<Layer>>> AddAllAsync(List<Layer> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(List<Layer> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<Layer>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Layer>> GetAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Element>> GetElementsAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Pen>> GetPenAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(List<Layer> entities)
        {
            throw new NotImplementedException();
        }
    }
}
