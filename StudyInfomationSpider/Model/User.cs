using StudyInfomationSpider.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyInfomationSpider.Model
{
    /// <summary>
    /// 学生信息
    /// </summary>
    internal class User
    {
        public User()
        {
            Courses = new List<Course>();
        }
        public string Name { get; set; }
        public string ID { set; get; }
        public string NickName { set; get; }
        public Uri MoocUrl { set; get; }
        public List<Course> Courses { set; get; }
    }


}
