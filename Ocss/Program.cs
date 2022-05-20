using Ocss.Models;
using Ocss.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ocss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OcssUI();
        }

        public static void OcssUI()
        {
            Menu menu = new Menu();
            while (true)
            {
                try
                {
                    var key = menu.ShowMenu();
                    switch (key)
                    {
                        //新增课程
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:

                            var course = new Course();
                            Console.WriteLine("请输入课程名称:");
                            course.CourseName = Console.ReadLine();
                            Console.WriteLine("请输入课程ID:");
                            course.CourseId = Console.ReadLine();
                            course.CreatedDate = DateTime.Now;
                            using (var dbContext = new _04010018Context())
                            {
                                dbContext.Course.Add(course);
                                dbContext.SaveChanges();
                            }

                            Console.WriteLine("保存完成，按任意键返回");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D2:
                            using (var dbContext = new _04010018Context())
                            {
                                var courses = dbContext.Course.ToList();
                                Course.ShowAllCourse(courses);
                            }

                            Console.WriteLine("查看完成，按任意键返回");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D3:
                            break;
                        //新增学生
                        case ConsoleKey.D4:
                            using (_04010018Context context = new _04010018Context())
                            {
                                Models.Student student = new Models.Student();
                                Console.WriteLine("请输入学生学号:");
                                student.StudentId = Console.ReadLine();
                                Console.WriteLine("请输入学生姓名:");
                                student.StudentName = Console.ReadLine();
                                student.CreatedDate = DateTime.Now;
                                student.StudentPassword = "111111";
                                context.Student.Add(student);
                                context.SaveChanges();
                            }
                            break;
                        //查看学生
                        case ConsoleKey.D5:
                            using (_04010018Context context = new _04010018Context())
                            {
                                var students = context.Student.ToList();
                                Student.ShowAllStudent(students);
                                Console.WriteLine("查看完成，按任意键返回");
                                Console.ReadKey();
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("程序出错了:" + ex.Message + ",按任意键继续");
                    Console.ReadKey();
                }

            }

        }
    }
}
