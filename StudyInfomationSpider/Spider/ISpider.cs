using StudyInfomationSpider.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyInfomationSpider
{
    /// <summary>
    /// 爬虫接口
    /// </summary>
    internal interface ISpider
    {
        public void CaptureInformation(List<User> users);
    }
}
