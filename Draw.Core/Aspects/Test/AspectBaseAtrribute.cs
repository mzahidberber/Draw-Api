using Castle.DynamicProxy;

namespace Draw.Core.Aspects.Test
{
    //[AttributeUsage(
    //    AttributeTargets.Class |
    //    AttributeTargets.Method |
    //    AttributeTargets.Assembly,
    //    AllowMultiple =true,
    //    Inherited = true)]
    [Serializable]
    public abstract class AspectBaseAtrribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation) { }
    }
}
