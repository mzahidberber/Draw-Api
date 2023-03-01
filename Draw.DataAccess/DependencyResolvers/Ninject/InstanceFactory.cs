using Ninject;

namespace Draw.DataAccess.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new DataAccessModule());
            return kernel.Get<T>();
        }
    }
}
