using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ocss.Model
{
    internal class Course
    {
        public string Name { set; get; }
        public string ID { set; get; }

        public static void ShowAllCourse(List<Course> allCourse)
        {
            Console.Clear();
            Console.WriteLine("课程ID     课程名称");
            foreach (var item in allCourse)
            {
                Console.WriteLine($"{item.ID}     {item.Name}");
            }

        }
        public static List<Course> ReadFromLocalFile()
        {
            var allText = File.ReadAllText("AllCourse.json");
            JsonConvert.DeserializeObject<List<Course>>(allText);
            return null;
        }

        public static void SaveToLocalFile(List<Course> allCourse)
        {

        }
    }
}
