using System;
using System.Collections.Generic;
using System.Text;

namespace Ocss.UI
{
    internal class Menu
    {
        public ConsoleKey ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1.新增课程");
            Console.WriteLine("2.查看课程");
            Console.WriteLine("3.删除课程");
            Console.WriteLine("3.新增学生");
            Console.WriteLine("4.查看学生");
            Console.WriteLine("5.退出");
            return Console.ReadKey().Key;
        }
    }
}
