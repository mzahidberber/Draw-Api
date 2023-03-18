using Ninject;

namespace Draw.Core.DependencyResolvers.Ninject
{
    public class CoreInstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new CoreAccessModule());
            return kernel.Get<T>();
        }
    }
}
