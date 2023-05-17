using Ocss.Service.Models;
using Ocss.UI;
using System;
using System.Linq;

namespace Ocss
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuItems = {
            "新建学生",
            "修改学生",
            "删除学生"
        };

            int currentIndex = 0;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (currentIndex == i)
                    {
                        Console.Write("-> ");
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (currentIndex + 1 < menuItems.Length)
                    {
                        currentIndex++;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (currentIndex - 1 >= 0)
                    {
                        currentIndex--;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    switch (currentIndex)
                    {
                        case 0:
                            // 新建学生的代码
                            Console.WriteLine("新建学生被选中");
                            Console.ReadKey();
                            break;
                        case 1:
                            // 修改学生的代码
                            Console.WriteLine("修改学生被选中");
                            Console.ReadKey();
                            break;
                        case 2:
                            // 删除学生的代码
                            Console.WriteLine("删除学生被选中");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            /*char inputKey = 'o';
            while (true)
            {
                Console.Clear();
                switch (inputKey)
                {
                    case 'o':
                        Console.WriteLine("1.课程新增");
                        Console.WriteLine("2.课程修改");
                        Console.WriteLine("3.退出");
                        inputKey = Console.ReadKey().KeyChar;
                        break;
                    case '1':
                        Console.WriteLine("请输入课程ID：");
                        var id = Console.ReadLine();
                        Console.WriteLine("请输入课程名称：");
                        var name = Console.ReadLine();
                        // 操作数据库一系列代码操作.....
                        Console.WriteLine("保存成功! 按任意键继续");
                        Console.ReadKey();
                        inputKey = 'o';
                        break;
                    default:
                        Console.WriteLine("输入的菜单不存在");
                        inputKey = 'o';
                        break;
                }




            }*/

            // OcssUI();
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
                                Student student = new Student();
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
