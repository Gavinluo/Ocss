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
            Console.WriteLine("课程ID\t\t课程名称");
            foreach (var item in allCourse)
            {
                Console.WriteLine($"{item.ID}\t\t{item.Name}");
            }

        }

        /// <summary>
        /// Todo... 从文件中读数据
        /// </summary>
        /// <returns></returns>
        public static List<Course> ReadFromLocalFile()
        {
            var allText = File.ReadAllText("AllCourse.json");
            JsonConvert.DeserializeObject<List<Course>>(allText);
            return null;
        }

        /// <summary>
        /// Todo... 写数据到文件中
        /// </summary>
        /// <param name="allCourse"></param>
        public static void SaveToLocalFile(List<Course> allCourse)
        {

        }
    }
}
