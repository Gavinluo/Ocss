using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocss.Service.Models;
using Ocss.Web.DataTransferModel;
using System;
using System.Linq;

namespace Ocss.Web.Controllers
{
    /// <summary>
    /// IAllowAnonymous 在我们的过滤器里是放行了此Controller
    /// </summary>
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public LoginController()
        {
        }
        /// <summary>
        /// 显示登录页面
        /// </summary>
        /// <returns></returns>
        public IActionResult ShowLogin()
        {
            //Session 里的一个 Date 变量，当用户第一次访问我们的登录页面的时间
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Date")))
            {
                HttpContext.Session.SetString("Date", DateTime.Now.ToString());
            }
            //通过 ViewData 方式进行传值到 View页面
            ViewData["SessionData"] = HttpContext.Session.GetString("Date");
            return View();
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IActionResult Logout()
        {
            // 主动抛出一个异常，是为了告诉自己需要实现这块的代码逻辑
            throw new NotImplementedException();
        }
        public IActionResult LoginUser(LoginModel model)
        {
            //用我们的DbContext 从数据库里获取UserName 的密码，然后进行对比。
            if (model.UserName == "admin" && model.Password == "admin")
            {
                //登录成功会放入一个变量
                HttpContext.Session.SetString("LoginUser", model.UserName);
                HttpContext.Session.SetString("LoginType", "老师");
                return Redirect("/Student/List");
            }
            ViewData["error"] = "登录密码错误";
            return View("ShowLogin");
        }

    }
}
