using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ocss.Web.Controllers
{

    public class StudentController : Controller
    {
        public IActionResult Edit(string id)
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
