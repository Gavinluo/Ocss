using System;
using System.Collections.Generic;
using System.Text;

namespace Ocss.Model
{
    internal class Student
    {
        public string Name { set; get; }
        public string ID { set; get; }
        public List<Course> SelectCourse { set; get; }
    }
}
