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
            List<Course> allCoures = Course.ReadFromLocalFile();
            Menu menu = new Menu();
            while (true)
            {
                var key = menu.ShowMenu();
                switch (key)
                {
                    //新增课程
                    case ConsoleKey.D1:
                        var course = new Course();
                        Console.WriteLine("请输入课程名称:");
                        course.CourseName = Console.ReadLine();
                        Console.WriteLine("请输入课程ID:");
                        course.CourseId = Console.ReadLine();
                        course.CreatedDate = DateTime.Now;
                        allCoures.Add(course);
                        Course.SaveToLocalFile(allCoures);
                        Console.WriteLine("保存完成，按任意键返回");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Course.ShowAllCourse(allCoures);
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
                    //删除学生
                    case ConsoleKey.D6:

                        using (_04010018Context context = new _04010018Context())
                        {
                            var students = context.Student.ToList();
                            Student.ShowAllStudent(students);
                            Console.WriteLine("请输入要删除的学号：");
                            var studentId = Console.ReadLine();
                            //context.Student
                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.D0:

                        return;
                    default:
                        break;
                }


            }

        }
    }
}
