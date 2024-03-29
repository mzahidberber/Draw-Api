﻿using Castle.DynamicProxy;

namespace Draw.Core.Aspects.Test
{
    public class MethodAspect : AspectBaseAtrribute
    {
        public override void Intercept(IInvocation invocation)
        {
            bool successFlag = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                successFlag = false;
                OnException(invocation, ex);
                throw;
            }
            finally
            {
                if (successFlag)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
        public virtual void OnBefore(IInvocation invocation) { }
        public virtual void OnAfter(IInvocation invocation) { }
        public virtual void OnException(IInvocation invocation, Exception ex) { }
        public virtual void OnSuccess(IInvocation invocation) { }
    }
}
