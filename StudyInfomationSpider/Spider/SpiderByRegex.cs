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
        /// <summary>
        /// 这个代码会从网页的HTML中获取每个课程的标题和学习进度。正则表达式模式<p class=""title"">(.*?)<\/p>.*?<span>已学(.*?)<\/span>用来匹配课程标题和学习进度。.*?是一个非贪婪匹配，它会尽可能少地匹配字符。        另外，我使用了RegexOptions.Singleline选项，这使得.字符可以匹配任何字符，包括换行符。这是因为在HTML中，课程标题和学习进度可能不在同一行。请注意，这个代码可能需要根据实际的HTML结构进行调整。如果这个正则表达式无法正确匹配，你可能需要修改它以适应实际的HTML结构。
        /// </summary>
        /// <param name="pageContents"></param>
        /// <returns></returns>
        private static List<Course> ParseHtmlByRegex(string pageContents)
        {
            List<Course> courses = new List<Course>();
            // Pattern for course title and progress
            var pattern = @"<p class=""title"">(.*?)<\/p>.*?<span>已学(.*?)<\/span>";
            var regex = new Regex(pattern, RegexOptions.Singleline);
            var matches = regex.Matches(pageContents);

            foreach (Match match in matches)
            {
                var title = match.Groups[1].Value;
                var progress = match.Groups[2].Value;

                Console.WriteLine($"课程名: {title}, 学习进度: {progress}");
            }
            return courses;
        }
    }
}
