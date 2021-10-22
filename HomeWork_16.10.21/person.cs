using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_16._10._21
{
    abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public Person(string name, string surname, byte age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        abstract public void DisplayInfo();
    }
    class Vertuhai : Person
    {
        public string Rank { get; set; }
        public Vertuhai(string name, string surname, byte age, string rank) :base(name, surname, age)
        {
            Rank = rank;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("{0} {1}, {2} лет. Должность: {3}", Name, Surname, Age, Rank);
        }
    }
    class Prisoner : Person
    {
        private double balance;
        public string Article { set; get; }
        public string Nickname { set; get; }
        public string Caste { set; get; }
        public Prisoner(string name, string surname, byte age, string article, string nickname, string caste) : base(name, surname, age)
        {
            Article = article;
            Nickname = nickname;
            Caste = caste;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("{0} {1}, {2} лет. Погоняло {3}. {4}. Cидит за {5}", Name, Surname, Age, Nickname, Caste, Article);
        }
        public double GetBalance()
        {
            return balance;
        }
        public void Deposit(double value)
        {
            balance += value;
        }
    }
}
