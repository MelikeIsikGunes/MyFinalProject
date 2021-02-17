using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //invocation bizim gönderceğimiz metodumuz
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation); //method başında bu çalışsın
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); //hata aldığında bu çalışsın
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); //method başarılı olduğunda bu çalışsın
                }
            }
            OnAfter(invocation); //methodtan sonra bu çalışsın
        }
    }
}
