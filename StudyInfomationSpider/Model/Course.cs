using System;
using System.Collections.Generic;
using System.Text;

namespace StudyInfomationSpider.Model
{
    /// <summary>
    /// 课程信息
    /// </summary>
    internal class Course
    {
        public string CourseName { get; set; }
        public string UserID { set; get; }
        public int StudyPercent { get; set; }
        public int TestCodes { set; get; }
        public int NoteCount { set; get; }

    }
}
