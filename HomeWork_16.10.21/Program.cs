using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_16._10._21
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ranks = new string[] { "Курсант", "Смотрящий", "Начальник Охраны", "Начальник колонии", "Уборщик" };
            string[] caste = new string[] { "Шерсть", "Заполосканный", "Чёрт", "Мужик", "Блатной" };
            List<Prisoner> zeki = new List<Prisoner>();
            List<Vertuhai> ments = new List<Vertuhai>();
            string name, surname, rank, nickname, article, cast;
            double value;
            byte age, action;
            bool flag = true, flag2;
            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"persons\ments.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    name = line.Split(' ')[0];
                    surname = line.Split(' ')[1];
                    if (!byte.TryParse(line.Split(' ')[2], out age))
                    {
                        Console.WriteLine("У {name} {surname} введен некорретный возраст");
                    }
                    rank = ranks[byte.Parse(line.Split(' ')[3])];
                    ments.Add(new Vertuhai(name, surname, age, rank));   
                }
            }
            ments.Add(new Vertuhai("Миша", "", 6, "Кот"));
            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"persons\zeks.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    name = line.Split(' ')[0];
                    surname = line.Split(' ')[1];
                    if (!byte.TryParse(line.Split(' ')[2], out age))
                    {
                        Console.WriteLine("У {name} {surname} введен некорретный возраст");
                    }
                    nickname = line.Split(' ')[3];
                    cast = line.Split(' ')[4];
                    article = line.Split(' ')[5];
                    zeki.Add(new Prisoner(name, surname,age, article, nickname, cast));
                }
            }
            while (flag)
            {
                Console.WriteLine("\nВведите:\n1 - чтобы получить список заключенных\n2 - чтобы получить список вертухаев\n3 - добавить вертухая\n4 - добавить зека (войти в хату)\n5 - передать денюжку заключенному\n6 - порыться в вещах, и узнать сколько денег у зека\nДругое - чтобы завершить работу программы");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        foreach (var zek in zeki)
                        {
                            zek.DisplayInfo();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        foreach (var ment in ments)
                        {
                            ment.DisplayInfo();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Введите имя мента");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите фамилию мента");
                        surname = Console.ReadLine();
                        Console.WriteLine("Введите возраст мента");
                        while (!byte.TryParse(Console.ReadLine(), out age) | age < 18)
                        {
                            Console.WriteLine("Некорректное значение, попробуйте снова. В тюрьме, кстати, всем больше 18 лет должно быть");
                        }
                        flag2 = true;
                        Console.WriteLine("Выберите должность нового вертухая:\n1 - Курсант\n2 - Смотрящий\n3 - Начальник охраны\n4 - Начальник колонии\nДругое - какая-нибудь непыльная должность");
                        while (!byte.TryParse(Console.ReadLine(), out action))
                        {
                            Console.WriteLine("Некорректное значение, попробуйте снова");
                        }
                        if (action > 0 & action < 5)
                        {
                            rank = ranks[action - 1];
                        }
                        else { rank = ranks[4]; }
                        ments.Add(new Vertuhai(name, surname, age, rank));
                        Console.Clear();
                        Console.WriteLine("Вертухай {0} {1} теперь работает в этой тюрьме", name, surname);
                        break;
                    case "4":
                        Console.Clear();
                        flag2 = true;
                        while (flag2)
                        {
                            cast = caste[3];
                            nickname = "";
                            Console.WriteLine("Вертухай: Имя?");
                            name = Console.ReadLine();
                            Console.WriteLine("Вертухай: Фамилия?");
                            surname = Console.ReadLine();
                            Console.WriteLine("Вертухай: Сколько лет?");
                            while (!byte.TryParse(Console.ReadLine(), out age))
                            {
                                Console.WriteLine("Ты #@!!&ь дурачком не притворяйся. Еще раз спрашиваю сколько лет?");
                            }
                            Console.WriteLine("Вертухай: За что сел?");
                            article = Console.ReadLine();
                            Console.WriteLine("Вертухай: Деньги с собой есть?\n1 - Да\n2 - нет");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.WriteLine("Вертухай: Сколько?");
                                    if (!double.TryParse(Console.ReadLine(), out value))
                                    {
                                        Console.WriteLine("Ты видимо дурачек");
                                        nickname = "Поехавший";
                                        cast = caste[0];
                                        flag2 = false;
                                    }
                                    else
                                    {
                                        if (value > 100000)
                                        {
                                            Console.WriteLine("Вертухай: воровское имя?");
                                            nickname = Console.ReadLine();
                                            Console.WriteLine("Вертухай: чувствуй себя как дома, {0}", nickname);
                                            cast = caste[4];
                                            flag2 = false;
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Маловато для хорошей жизни. Деньги на стол и шуруй в камеру.");
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Ладно. Шуруй в камеру, бомжара");
                                    break;
                            }
                            if (!flag2)
                            {
                                zeki.Add(new Prisoner(name, surname, age, article, nickname, cast));
                                break;
                            }
                            Console.WriteLine("*Отвели в камеру*\nЗек: Как звать тебя?");
                            nickname = Console.ReadLine();
                            Console.WriteLine("Ты написал 'Чмо', все верно?\n1 - Да\n2 - Нет");
                            switch (Console.ReadLine())
                            {
                                default:
                                    Console.WriteLine("Хорошо, чмо");
                                    nickname = "Чмо";
                                    break;
                            }
                            Console.WriteLine("Какой-то другой зек: Идём, присаживайся!\n1 - присесть рядом с ним\nДругое - идти дальше, искать свободную койку");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.WriteLine("Этот паренек был петухом, теперь ты заполосканный");
                                    cast = caste[1];
                                    flag2 = false;
                                    break;
                                default:
                                    break;
                            }
                            if (!flag2)
                            {
                                zeki.Add(new Prisoner(name, surname, age, article, nickname, cast));
                                break;
                            }
                            Console.WriteLine("Ты занял пустую койку. А это койка петуха какого-то, у него постель забрали блатные. Поздравляю, ты теперь тоже петух");
                            cast = caste[0];
                            zeki.Add(new Prisoner(name, surname, age, article, nickname, cast));
                            flag2 = false;
                            Console.ReadKey();
                        }
                        Console.Clear();
                        Console.WriteLine("Зек теперь мотает срок тут");
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Выберите заключенного, которому будете передавать деньги\n");
                        for (int i = 0; i < zeki.Count; i++)
                        {
                            Console.WriteLine("{0}: {1} {2}", i, zeki[i].Name, zeki[i].Nickname);
                        }
                        while (!byte.TryParse(Console.ReadLine(), out action) | action < 0 | action >= zeki.Count)
                        {
                            Console.WriteLine("Некорректное значение, попробуйте снова");
                        }
                        Console.WriteLine("Введите сумму, которую хотите перевести");
                        while (!double.TryParse(Console.ReadLine(), out value))
                        {
                            Console.WriteLine("Некорректное значение, попробуйте снова");
                        }
                        zeki[action].Deposit(value);
                        Console.Clear();
                        Console.WriteLine("Посылка передана зеку");
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Выберите заключенного, у которого будем рыться\n");
                        for (int i = 0; i < zeki.Count; i++)
                        {
                            Console.WriteLine("{0}: {1} {2}", i, zeki[i].Name, zeki[i].Nickname);
                        }
                        while (!byte.TryParse(Console.ReadLine(), out action) | action < 0 | action >= zeki.Count)
                        {
                            Console.WriteLine("Некорректное значение, попробуйте снова");
                        }
                        Console.Clear();
                        Console.WriteLine("У {0} {1} {2} рублей", zeki[action].Name, zeki[action].Nickname, zeki[action].GetBalance());
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
