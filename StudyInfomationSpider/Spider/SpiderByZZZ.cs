using HtmlAgilityPack;
using StudyInfomationSpider.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
            /* 性能优化可以使用下面的并行方式
          var usersArray = users.ToArray();
          Parallel.For(0, usersArray.Length - 1, i =>
          {
              var web = new HtmlWeb();
              var doc = web.Load(usersArray[i].MoocUrl);
              var htmlnode = doc?.DocumentNode?.SelectNodes(@"//*[@id=""main""]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li");
              if (htmlnode != null)
              {
                  foreach (var node in htmlnode)
                  {
                      users[i].Courses.Add(new Course()
                      {
                          CourseName = node?.SelectSingleNode("div[2]/h3/a")?.InnerText,
                          ////*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li/div[2]/div[2]/span[1]/a/i
                          NoteCount = int.Parse(node?.SelectSingleNode("div[2]/div[2]/span[1]/a/i")?.InnerText),
                          ////*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li/div[2]/div[1]/span[1]
                          StudyPercent = int.Parse(node?.SelectSingleNode("div[2]/div[1]/span[1]")?.InnerText?.Replace("已学", "").Replace("%", "")),
                          ////*[@id="main"]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li/div[2]/div[2]/span[2]/a/i
                          TestCodes = int.Parse(node?.SelectSingleNode("div[2]/div[2]/span[2]/a/i")?.InnerText),
                          UserID = usersArray[i].ID

                      });
                  }
              }
          });*/
            #endregion
            foreach (var item in users)
            {
                var web = new HtmlWeb();
                var doc = web.Load(item.MoocUrl);
                var htmlnode = doc?.DocumentNode?.SelectNodes(@"//*[@id=""main""]/div[2]/div[2]/div[2]/div/div[1]/div[1]/div/ul/li");
                //*[@id="main"]/div[1]/div[1]/div[3]/div[3]/span[2]
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
    }
}
