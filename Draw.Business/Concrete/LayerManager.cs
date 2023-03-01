

using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Aspects.PostSharp.LoginAspects;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Concrete
{
    public class LayerManager : ILayerService
    {
        IUserService _userManager;
        public LayerManager()
        {
            _userManager=InstanceFactory.GetInstance<IUserService>();
        }
        public object GetAll(User user, int drawId)
        {
            throw new NotImplementedException();
            //return _userManager.IsLoggedUser(user) ?
            //    _userManager.GetLogginUserDrawManager(user.UserName).GetLayers(userDrawBoxId) :
            //    new Exception("Last Login");
        }
        //[LoginAspect(typeof(LogginUsers))]
        public object Get(User user, int drawId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object AddAll(User user, int drawId, List<Layer> entities)
        {
            throw new NotImplementedException();
            //return _userManager.IsLoggedUser(user) ?
            //    _userManager.GetLogginUserDrawManager(user.UserName).AddLayer(userDrawBoxId, layer) :
            //    new Exception("Last Login");
        }

        public object UpdateAll(User user, int drawId, List<Layer> entities)
        {
            throw new NotImplementedException();
        }

        public object DeleteAll(User user, int drawId, List<Layer> entities)
        {
            throw new NotImplementedException();
        }

        public object GetElements(User user, int drawId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object GetPen(User user, int drawId, int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
