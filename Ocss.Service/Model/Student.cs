using System;
using System.Collections.Generic;
using System.Text;

namespace Ocss.Service.Models
{
    /// <summary>
    /// partial 部分类 ，可以和另外一个同名部分类自动合并到一起
    /// </summary>
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
        }
    }
}
