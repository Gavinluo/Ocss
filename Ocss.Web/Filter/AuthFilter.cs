using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Ocss.Web.Filter
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthFilter : IAuthorizationFilter
    {
        //每个action执行之前都会进入这个方法
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //如果不通过认证 重定向到/Login/User页
            if (!string.IsNullOrEmpty(context.HttpContext.Session.GetString("LoginUser")) || HasAllowAnonymous(context) == true) return;
            context.Result = new RedirectToActionResult("ShowLogin", "Login", null);
        }

        //用于判断Action有没有AllowAnonymous标签
        private bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return true;
            }

            return false;
        }



    }
}
