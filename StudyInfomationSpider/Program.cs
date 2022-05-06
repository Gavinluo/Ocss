using HtmlAgilityPack;
using Microsoft.VisualBasic.FileIO;
using StudyInfomationSpider.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Linq;
using StudyInfomationSpider.Spider;

namespace StudyInfomationSpider
{
    /// <summary>
    /// 慕课网学习信息爬虫Demo
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var userOperation = new UserOperation();
            List<User> users = userOperation.GetUsersFromCSV();

            //使用ZZZ组件抓取信息 ，这里通过接口的方式实现了两种不通方式的抓取
            ISpider spider = new SpiderByZZZ();
            spider.CaptureInformation(users);

            /* 
            //这里使用了正则表达时的方式抓取信息
            ISpider spider2 = new SpiderByRegex();
            spider2.CaptureInformation(users);
            */
            userOperation.ExportCSV(users);
        }




    }
}
