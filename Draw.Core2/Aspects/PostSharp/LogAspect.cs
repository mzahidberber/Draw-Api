using PostSharp.Aspects;
using System;

namespace Draw.Core2.Aspects.PostSharp
{
    [Serializable]
    public class LogAspect: OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Entyy");
        }
    }
}
