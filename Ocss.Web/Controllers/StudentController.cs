using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ocss.Service.Models;
using System.Collections.Generic;
using System.Linq;

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
            var studentList = new List<Student>();
            using (var dbContext = new _04010018Context())
            {
                studentList = dbContext.Student.ToList();
            }
            return View(studentList);
        }
    }
}
