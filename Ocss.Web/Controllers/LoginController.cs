using Microsoft.AspNetCore.Mvc;
using System;

namespace Ocss.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult ShowLogin()
        {
            return View();
        }

        public IActionResult LoginUser(string username, string pwd)
        {
            if (username == "admin" && pwd == "admin")
            {
                return Redirect("/Student/List");
            }
            ViewData["error"] = "登录密码错误";
            return View("ShowLogin");
        }

    }
}
