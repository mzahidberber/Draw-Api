using PostSharp.Aspects;
using System;

namespace Draw.Core3
{
    [Serializable]
    public class Class1 : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Enty");
        }
    }
}
