using StudyInfomationSpider.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace StudyInfomationSpider
{
    /// <summary>
    /// 正则表达式爬虫接口
    /// </summary>
    internal class SpiderByRegex : ISpider
    {
        public void CaptureInformation(List<User> users)
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
