using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DemoEFConnectDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbcontext = new Models._04010018Context();
            for (int i = 0; i < 10; i++)
            {
                var student = new Models.Student
                {
                    StudentId = "040100" + i,
                    StudentName = "张三" + i,
                    StudentClass = "计01"
                };
                dbcontext.Student.Add(student);
            }
            dbcontext.SaveChanges();

            var students = dbcontext.Student.Where(a => a.StudentClass == "计01").ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student.StudentName + " " + student.StudentClass);

            }



            /*using (var dbcontext = new Models._04010018Context())
            {
                var student = new Models.Student
                {
                    StudentId = "04010018",
                    StudentName = "张三",
                    StudentClass = "计01"
                };
                dbcontext.Student.Add(student);
                dbcontext.SaveChanges();
            }*/

            /*using (var dbcontext = new Models._04010018Context())
            {
                var student = dbcontext.Student.Find("04010018");
                student.StudentClass = "计02";
                dbcontext.SaveChanges();
                Console.WriteLine(student.StudentName);
            }*/

            /*using (var dbcontext = new Models._04010018Context())
            {
                var student = dbcontext.Student.Find("04010018");
                dbcontext.Student.Remove(student);
                dbcontext.SaveChanges();
                Console.WriteLine("删除成功");
            }*/
        }
    }
}
