﻿

using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Interceptors;
using Core.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
    public class CachingAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        public CachingAspect(int duration=60)
        {
            _duration = duration;
            _cacheManager = ServiceHelper.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}." +
                $"{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",",arguments.Select(x=>x?.ToString()??"<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue=_cacheManager.Get<object>(key);
                return ;
            }
            invocation.Proceed();
            _cacheManager.Add(key,invocation.ReturnValue,_duration);

        }
    }

}
