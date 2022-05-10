using System;
using System.Collections.Generic;
using System.Text;

namespace Ocss.Models
{
    partial class Student
    {
        public static void ShowAllStudent(List<Student> allStudent)
        {
            Console.Clear();
            Console.WriteLine("学生ID\t\t学生姓名");
            foreach (var item in allStudent)
            {
                Console.WriteLine($"{item.StudentId}\t\t{item.StudentName}");
            }
            Console.WriteLine("查看完成，按任意键返回");
            Console.ReadKey();
        }
    }
}
