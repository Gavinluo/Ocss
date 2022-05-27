using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ocss.Web.Models;
using System;

namespace Ocss.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult ShowLogin()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Date")))
            {
                HttpContext.Session.SetString("Date", DateTime.Now.ToString());
            }

            ViewData["SessionData"] = HttpContext.Session.GetString("Date");
            return View();
        }
        public IActionResult LoginUser(LoginModel model)
        {
            //用我们的DbContext 从数据库里获取UserName 的密码，然后进行对比。
            if (model.UserName == "admin" && model.Password == "admin")
            {
                HttpContext.Session.SetString("LoginUser", model.UserName);

                return Redirect("/Student/List");
            }
            ViewData["error"] = "登录密码错误";
            return View("ShowLogin");
        }

    }
}
