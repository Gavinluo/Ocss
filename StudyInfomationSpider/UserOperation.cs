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
                        Uri uri = new Uri(rows[4]);
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
                sw.WriteLine("学号,昵称,姓名,慕课地址,课程1,进度1,课程2,进度2,课程3,进度3,课程4,进度4,课程5,进度5,课程6,进度6");
                foreach (var s in users)
                {
                    sw.Write($"{s.ID},{s.NickName},{s.Name},{s.MoocUrl}");

                    foreach (var item in s.Courses.OrderBy(a => a.CourseName))
                    {
                        sw.Write($",{item.CourseName},{item.StudyPercent}");
                    }
                    sw.WriteLine();
                }
            }
        }

    }
}
