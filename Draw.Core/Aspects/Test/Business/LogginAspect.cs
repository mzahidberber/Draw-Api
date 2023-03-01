using Castle.DynamicProxy;
using Draw.Core.Aspects.Test;

namespace Draw.Core.Aspects.Test.Business
{
    public class LogginAspect : MethodAspect
    {
        public override void OnAfter(IInvocation invocation)
        {
            Console.WriteLine("After");
        }
        public override void OnBefore(IInvocation invocation)
        {
            Console.WriteLine("Before");
        }
    }
}
