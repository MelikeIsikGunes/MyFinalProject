using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //ReflectedType->namespace
            //key ismi oluşturuyoruz,eşsiz olsun diye namespace.class.metot -> Örn: Business.Abstract.IProderService.GetAll()
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList(); //parametreleri varsa onları listele
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; //parametreleri araya virgül koyarak birleştir, parametre yoksa null ekle
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key); //eğer cache'de varsa metottan çık ve cache'ten getir
                return;
            }
            invocation.Proceed(); //cache'te yoksa metot çalışmaya devam etsin
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //belleğe eklensin
        }
    }
}
