using System;
using System.Collections.Generic;
using System.Text;

namespace Ocss
{
    internal class Demo2
    {
        const int MaxLoopCount = 500;
        public void TestSwith()
        {
            int loopCount = 1;
            while (loopCount < MaxLoopCount)
            {
                Console.WriteLine("请输入银行代码：");
                var code = Console.ReadLine();
                switch (code)
                {
                    case "ICBC":
                        Console.WriteLine("中国工商银行");
                        break;
                    case "EXIT":
                        loopCount = 500;
                        break;
                    default:
                        Console.WriteLine($"这个字符{code}没有找到");
                        break;
                }
                loopCount++;
            }

        }

        public void TestForeach()
        {
            Console.WriteLine("请输入字符串");
            var inputString = Console.ReadLine();
            foreach (var item in inputString)
            {
                Console.WriteLine(item);
            }
        }

        public void TestFor()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j <= i + 1; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }
}
