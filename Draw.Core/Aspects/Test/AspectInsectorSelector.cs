using Castle.DynamicProxy;
using System.Reflection;

namespace Draw.Core.Aspects.Test
{
    public class AspectInsectorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAtt = type.GetCustomAttributes<AspectBaseAtrribute>(true).ToList();

            var methodAtt = type.GetMethod(method.Name)?.GetCustomAttributes<AspectBaseAtrribute>().ToList();

            if (methodAtt != null)
                classAtt.AddRange(methodAtt);

            return classAtt.OrderBy(x => x.Priority).ToArray();
        }
    }
}
