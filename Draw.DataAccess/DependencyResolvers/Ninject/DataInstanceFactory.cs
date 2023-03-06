using Ninject;

namespace Draw.DataAccess.DependencyResolvers.Ninject
{
    public class DataInstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new DataAccessModule());
            return kernel.Get<T>();
        }
    }
}
