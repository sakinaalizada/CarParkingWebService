using System;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Interceptors;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac.Authorization
{
    public class AuthorizationAspect : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthorizationAspect(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceHelper.ServiceProvider.GetService<IHttpContextAccessor>();

        }                                                                                                                                                                  

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception("Access denied");
        }
    }
}
