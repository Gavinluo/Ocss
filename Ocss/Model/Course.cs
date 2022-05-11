using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ocss.Models
{
    partial class Course
    {

        public static void ShowAllCourse(List<Course> allCourse)
        {
            Console.Clear();
            Console.WriteLine("课程ID\t\t课程名称");
            foreach (var item in allCourse)
            {
                Console.WriteLine($"{item.CourseId}\t\t{item.CourseName}");
            }

        }

        /// <summary>
        /// Todo... 从文件中读数据
        /// </summary>
        /// <returns></returns>
        public static List<Course> ReadFromLocalFile()
        {
            if (File.Exists("AllCourse.json"))
            {
                var allText = File.ReadAllText("AllCourse.json");
                var list = JsonConvert.DeserializeObject<List<Course>>(allText);
                return list;
            }
            return new List<Course>();
        }

        /// <summary>
        /// Todo... 写数据到文件中
        /// </summary>
        /// <param name="allCourse"></param>
        public static void SaveToLocalFile(List<Course> allCourse)
        {
            if (File.Exists("AllCourse.json"))
            {
                File.Delete("AllCourse.json");
            }
            var jsonText = JsonConvert.SerializeObject(allCourse);
            File.WriteAllText("AllCourse.json", jsonText);
        }
    }
}
