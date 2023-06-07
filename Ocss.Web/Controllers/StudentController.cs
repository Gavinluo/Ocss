using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ocss.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ocss.Web.Controllers
{
    /// <summary>
    /// 学生控制器
    /// </summary>
    public class StudentController : Controller
    {
        public IActionResult Save(Student stu)
        {
            using (var dbContext = new _04010018Context())
            {
                var dbStudent = dbContext.Student.Find(stu.StudentId);
                if (dbStudent != null)
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
                //通过Find方法（通过主键查找) 找到学生，并且以强类型方式返回到View
                return View(dbContext.Student.Find(id));
            }

        }
        /// <summary>
        /// 加载学生列表的
        /// </summary>
        /// <param name="searchText">查询参数，可以为空</param>
        /// <param name="currentPage">当前页，可以为空,默认值1</param>
        /// <param name="pageSize">页大小，可以为空</param>
        /// <returns></returns>
        public IActionResult List(string searchText, int currentPage = 1, int pageSize = 10)
        {
            var studentList = new List<Student>();
            using (var dbContext = new _04010018Context())
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    //Skip 跳过前多少条数据
                    //Take 取多少条数据
                    studentList = dbContext.Student.Skip(0).Take(pageSize).ToList();
                }
                else
                {
                    studentList = dbContext.Student.Where(a => a.StudentId.Contains(searchText) || a.StudentName.Contains(searchText)).Skip(0).Take(pageSize).ToList();
                }
            }
            return View(studentList);

        }

        public IActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
