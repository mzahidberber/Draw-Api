using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Reflection;

namespace Draw.Core.Aspects.PostSharp.HandleAspects
{
    [PSerializable]
    public class HandleAspect: OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            base.OnException(args);
        }

        public override Type GetExceptionType(MethodBase targetMethod)
        {
            return base.GetExceptionType(targetMethod);
        }

        


    }
}
