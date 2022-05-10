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
            Console.WriteLine("4.新增学生");
            Console.WriteLine("5.查看学生");
            Console.WriteLine("6.删除学生");
            Console.WriteLine("7.学生选课");
            Console.WriteLine("8.查看学生已选课程");
            Console.WriteLine("0.退出");
            var inputKey = Console.ReadKey().Key;
            Console.Clear();
            return inputKey;
        }

    }
}
