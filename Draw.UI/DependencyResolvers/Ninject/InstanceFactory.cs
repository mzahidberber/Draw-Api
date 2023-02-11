using Ninject;

namespace Draw.UI.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new UIModule());
            return kernel.Get<T>();
        }
    }
}
