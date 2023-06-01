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
		public string[] COURSES = new string[4] { "C#面向对象编程", "用C#实现封装", "C#开发轻松入门", "初识HTML(5)+CSS(3)-升级版" };
		public List<User> GetUsersFromCSV()
		{
			List<User> users = new List<User>();
			List<string> errorUrlUsers = new List<string>();
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
						//校验用户的慕课地址
						if (!rows[4].Contains("www.imooc.com/u/")
							|| !rows[4].EndsWith("/courses"))
						{
							errorUrlUsers.Add(rows[2]);
							continue;
						}
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

						continue;
					}
				}
			}

			Console.WriteLine($"这些同学地址不正确：{string.Join(",", errorUrlUsers)}");
			return users;
		}

		public void ExportCSV(List<User> users)
		{

			using (StreamWriter sw = new StreamWriter("StudyResult.csv", false, System.Text.Encoding.UTF8))
			{
				sw.Write("学号,姓名");
				foreach (var item in COURSES)
				{
					sw.Write($",{item},学习进度");
				}
				sw.WriteLine();

				foreach (var s in users)
				{
					sw.Write($"{s.ID},{s.Name}");
					foreach (var calcCourse in COURSES)
					{
						bool hasFind = false;
						foreach (var userCourse in s.Courses)
						{
							if (userCourse.CourseName == calcCourse)
							{
								hasFind = true;
								sw.Write($",{userCourse.CourseName},{userCourse.StudyPercent}");
							}
						}
						if (!hasFind)
						{
							sw.Write(",无,0");
						}
					}

					sw.WriteLine();
				}
			}
		}

	}
}
