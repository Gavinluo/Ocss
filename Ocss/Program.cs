using System;

namespace Ocss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //输出文字
            Console.WriteLine("Hello World!");
            Console.WriteLine("请输入你的姓名：");
            //读取控制台输入的字符串
            var yourName = Console.ReadLine();
            //清除控制台所有内容
            Console.Clear();
            //拼接字符串输出到控制台
            Console.WriteLine($"Your input is {yourName}");
        }
    }
}
