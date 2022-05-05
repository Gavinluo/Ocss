using HtmlAgilityPack;
using Microsoft.VisualBasic.FileIO;
using StudyInfomationSpider.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace StudyInfomationSpider
{
    /// <summary>
    /// 慕课网学习信息爬虫Demo
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            using (TextFieldParser textFieldParser = new TextFieldParser(@"慕课网注册信息.csv"))
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
            //CrawlByRegex(users);

            CrawlByZZZ(users);
            ExportCSV(users);
        }

        private static void ExportCSV(List<User> users)
        {

            using (StreamWriter sw = new StreamWriter("StudyResult.csv", false, System.Text.Encoding.UTF8))
            {
                foreach (var s in users)
                {
                    sw.Write($"{s.ID},{s.NickName},{s.Name}");
                    foreach (var item in s.Courses)
                    {
                        sw.Write($",{item.CourseName},已学习{item.StudyPercent}");
                    }
                    sw.WriteLine();
                }
            }
        }

        private static void CrawlByRegex(List<User> users)
        {
            foreach (var item in users)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    var data = httpClient.GetStringAsync(item.MoocUrl);
                    var htmlData = data.Result;
                    item.Courses = ParseHtmlByRegex(htmlData);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + e.StackTrace);
                    Console.WriteLine($"信息错误：item.MoocUrl:{item.MoocUrl}");
                    continue;
                }

            }
        }

        private static void CrawlByZZZ(List<User> users)
        {
            foreach (var item in users)
            {
                var web = new HtmlWeb();
                var doc = web.Load(item.MoocUrl);
                var htmlnode = doc?.DocumentNode?.SelectNodes(@"//*[@id=""main""]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li");
                if (htmlnode != null)
                {
                    foreach (var node in htmlnode)
                    {
                        item.Courses.Add(new Course()
                        {
                            CourseName = node?.SelectSingleNode("div[2]/h3/a")?.InnerText,
                            ////*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li/div[2]/div[2]/span[1]/a/i
                            NoteCount = int.Parse(node?.SelectSingleNode("div[2]/div[2]/span[1]/a/i")?.InnerText),
                            ////*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li/div[2]/div[1]/span[1]
                            StudyPercent = int.Parse(node?.SelectSingleNode("div[2]/div[1]/span[1]")?.InnerText?.Replace("已学", "").Replace("%", "")),
                            ////*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li/div[2]/div[2]/span[2]/a/i
                            TestCodes = int.Parse(node?.SelectSingleNode("div[2]/div[2]/span[2]/a/i")?.InnerText),
                            UserID = item.ID

                        });
                    }
                }
            }
        }

        private static List<Course> ParseHtmlByRegex(string htmlData)
        {
            List<Course> courses = new List<Course>();

            var regStr = @"<div class=""course-list-cont"">[\S\s]*?</div>[\S\s]*?</div>";
            MatchCollection matchs = new Regex(regStr).Matches(htmlData);
            foreach (var item in matchs)
            {
                var courseHtml = item.ToString();
                //Match CourseName
                var regStrCourseName = @"<a href=""/learn/[\S]*?"" target=""_blank"">[\S]*?</a>";
                var name = new Regex(regStrCourseName).Match(courseHtml);
                if (name != null && name.Success)
                {
                    var cutStr = name.Value.Substring(name.Value.IndexOf(">") + 1);
                    cutStr = cutStr.Substring(0, cutStr.IndexOf("</a>"));
                    Course course = new Course();
                    course.CourseName = cutStr;
                    courses.Add(course);
                }
            }
            return courses;
        }
    }
}
