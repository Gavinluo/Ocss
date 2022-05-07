using Ocss.Model;
using Ocss.UI;
using System;
using System.Collections.Generic;

namespace Ocss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> allCoures = new List<Course>();
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
                        course.Name = Console.ReadLine();
                        Console.WriteLine("请输入课程ID:");
                        course.ID = Console.ReadLine();
                        allCoures.Add(course);
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
                    case ConsoleKey.D4:
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
