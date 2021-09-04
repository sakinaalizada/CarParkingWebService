using System;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Interceptors;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
 
    }
}
