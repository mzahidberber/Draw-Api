using Castle.DynamicProxy;
using Draw.Core.Aspects.Test;

namespace Draw.Core.Aspects.Test.Business
{
    public class DefensiveProgrammingAspect : MethodAspect
    {
        public override void OnBefore(IInvocation invocation)
        {
            var parameters = invocation.Arguments;
            foreach (var p in parameters)
            {
                if (p.Equals(null))
                    throw new ArgumentException();
            }
            Console.WriteLine("Null Check has been competed for {0}", invocation.Method);
        }
    }
}
