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
            return View();
        }
        public IActionResult LoginUser(LoginModel model)
        {
            if (model.UserName == "admin" && model.Password == "admin")
            {
                return Redirect("/Student/List");
            }
            ViewData["error"] = "登录密码错误";
            return View("ShowLogin");
        }
        /*  public IActionResult LoginUser(string username, string pwd)
          {
              if (username == "admin" && pwd == "admin")
              {
                  return Redirect("/Student/List");
              }
              ViewData["error"] = "登录密码错误";
              return View("ShowLogin");
          }*/

    }
}
