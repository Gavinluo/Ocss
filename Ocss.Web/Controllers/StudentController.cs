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
        public IActionResult Save(Student stu)
        {
            using (var dbContext = new _04010018Context())
            {
                var dbStudent = dbContext.Student.Find(stu.StudentId);
                if (dbStudent !=null)
                {
                    dbStudent.StudentName = stu.StudentName;
                    ViewData["Msg"] = "修改成功";
                }
                else
                {
                    dbContext.Student.Add(stu);
                    ViewData["Msg"] = "新建成功";
                }
                dbContext.SaveChanges();
                return View("List", dbContext.Student.ToList());
            }

        }
        public IActionResult Edit(string id)
        {
            using (var dbContext = new _04010018Context())
            {
                return View(dbContext.Student.Find(id));
            }
           
        }
        public IActionResult List()
        {
            var studentList = new List<Student>();
            using (var dbContext = new _04010018Context())
            {
                studentList = dbContext.Student.Skip(10).Take(20).ToList();
            }
            return View(studentList);
        }
    }
}
