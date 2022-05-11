using System;
using System.Collections.Generic;
using System.Text;

namespace Ocss
{
    public class Employee
    {
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual void SayHi()
        {
            Console.Write("大家好，");
        }

    }

    public class PE : Employee
    {

        public PE(int id, string name, int porpular) : base(id, name)
        {
            Porpular = porpular;
        }
        public int Porpular { set; get; }
        public override void SayHi()
        {
            base.SayHi();
            Console.Write($"我是PE，我的人气值：{this.Porpular}");
            Console.WriteLine();
        }
    }

    public class SE : Employee
    {
        public SE(int id, string name, int yearofExp) : base(id, name)
        {
            YearOfExp = yearofExp;
        }

        public int YearOfExp { set; get; }
        public override void SayHi()
        {
            base.SayHi();
            Console.Write($"我是SE，我的工作年限：{this.YearOfExp}");
            Console.WriteLine();
        }
    }

}
