using HtmlAgilityPack;
using StudyInfomationSpider.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyInfomationSpider.Spider
{
    /// <summary>
    /// 使用ZZZ组件完成的抓取
    /// </summary>
    internal class SpiderByZZZ : ISpider
    {
        public void CaptureInformation(List<User> users)
        {
            #region 并行计算
            /* 性能优化可以使用下面的 Parallel.For 并行方式*/
            var usersArray = users.ToArray();
            Parallel.For(0, usersArray.Length - 1,new ParallelOptions() { MaxDegreeOfParallelism=  5}, i =>
            {
                try
                {
                    var web = new HtmlWeb();
                    var doc = web.Load(usersArray[i].MoocUrl);
                        //*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div/div/ul/li[1]
                        var htmlnode = doc?.DocumentNode?.SelectNodes(@"//li[@class='course-one']");
                        //*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li
                        if (htmlnode != null)
                        {
                            foreach (var node in htmlnode)
                            {
                                users[i].Courses.Add(new Course()
                                {
                                    CourseName = node?.SelectSingleNode("div[2]/h3/a")?.InnerText,
                                    ////*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li/div[2]/div[2]/span[1]/a/i
                                    //*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div/div/ul/li[1]/div[2]/h3/a
                                    NoteCount = int.Parse(node?.SelectSingleNode("div[2]/div[2]/span[1]/a/i")?.InnerText),
                                    ////*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li/div[2]/div[1]/span[1]
                                    StudyPercent = int.Parse(node?.SelectSingleNode("div[2]/div[1]/span[1]")?.InnerText?.Replace("已学", "").Replace("%", "")),
                                    ////*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li/div[2]/div[2]/span[2]/a/i
                                    TestCodes = int.Parse(node?.SelectSingleNode("div[2]/div[2]/span[2]/a/i")?.InnerText),
                                    UserID = usersArray[i].ID

                                });
                            }
                        }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine($"抓取失败：{usersArray[i].Name},{usersArray[i].MoocUrl}, {e.Message}{e.StackTrace}");
                }
                
            });
            #endregion
        }
    }
}
