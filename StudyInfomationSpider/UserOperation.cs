using Microsoft.VisualBasic.FileIO;
using StudyInfomationSpider.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudyInfomationSpider
{
    /// <summary>
    /// 学生操作类
    /// </summary>
    internal class UserOperation
    {
        public string[] COURSES = new string[6] { "C#面向对象编程", "用C#实现封装", "C#开发轻松入门", "初识HTML(5)+CSS(3)-2020升级版", "JavaScript入门篇", "JavaScript进阶篇" };
        public List<User> GetUsersFromCSV()
        {
            List<User> users = new List<User>();
            using (TextFieldParser textFieldParser = new TextFieldParser(@"慕课网注册信息（收集结果）-慕课网注册信息.csv"))
            {
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.SetDelimiters(",");
                bool isFirstRow = true;
                while (!textFieldParser.EndOfData)
                {
                    string[] rows = textFieldParser.ReadFields();
                    if (isFirstRow)
                    {
                        isFirstRow = false;
                        continue;
                    }
                    try
                    {
                        User u = new User
                        {
                            NickName = rows[0],
                            Name = rows[2],
                            ID = rows[3],
                            MoocUrl = new Uri(rows[4]),
                        };
                        users.Add(u);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + e.StackTrace);
                        Console.WriteLine($"信息错误：NickName:{rows[0]},Name:{rows[2]},ID:{rows[3]},MoocUri:{rows[4]}");
                        continue;
                    }
                }
            }
            return users;
        }

        public void ExportCSV(List<User> users)
        {

            using (StreamWriter sw = new StreamWriter("StudyResult.csv", false, System.Text.Encoding.UTF8))
            {
                sw.Write("学号,昵称,姓名,慕课地址");
                foreach (var item in COURSES)
                {
                    sw.Write($",{item},学习进度,代码练习");
                }

                foreach (var s in users)
                {
                    sw.Write($"{s.ID},{s.NickName},{s.Name},{s.MoocUrl}");
                    foreach (var calcCourse in COURSES)
                    {
                        foreach (var userCourse in s.Courses)
                        {
                            if (userCourse.CourseName == calcCourse)
                            {
                                sw.Write($",{userCourse.CourseName},{userCourse.StudyPercent},{userCourse.TestCodes}");
                            }
                        }
                    }

                    /*foreach (var item in s.Courses.OrderBy(a => a.CourseName))
                    {
                        sw.Write($",{item.CourseName},{item.StudyPercent},{item.TestCodes}");
                    }*/
                    sw.WriteLine();
                }
            }
        }

    }
}
