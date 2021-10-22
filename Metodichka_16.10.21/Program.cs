using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodichka_16._10._21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 7.1");
            BankAccount account = new BankAccount();
            account.GetBalace();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nВведите:\n1 - чтобы пополнить счёт\n2 - чтобы снять деньги\n3 - чтобы изменить тип счёта\nДругое - чтобы завершить программу");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите сумму");
                        decimal amount;
                        while(!decimal.TryParse(Console.ReadLine(), out amount))
                        {
                            Console.WriteLine("Некорректное значение, попробуйте снова");
                        }
                        account.Deposit(amount);
                        Console.Clear();
                        account.GetBalace();
                        break;
                    case "2":
                        Console.WriteLine("Введите сумму");
                        while (!decimal.TryParse(Console.ReadLine(), out amount))
                        {
                            Console.WriteLine("Некорректное значение, попробуйте снова");
                        }
                        account.Withdraw(amount);
                        Console.Clear();
                        account.GetBalace();
                        break;
                    case "3":
                        account.SwitchType();
                        Console.Clear();
                        account.GetBalace();
                        break;
                    default:
                        flag = false;
                        Console.Clear();
                        break;
                }
            }

            Console.WriteLine("Home Task 7.1");
            int n = 0;
            flag = true;
            List <Building> buildings= new List<Building>();
            while (flag)
            {
                Console.WriteLine("Введите:\n1 - чтобы заполнить информацию о новом здании\n2 - чтобы получить информацию о домах\nДругое - чтобы завершить работу программы");
                switch (Console.ReadLine())
                {
                    case "1":
                        buildings.Add(new Building());
                        Console.WriteLine("Заполняем информацию о новом здании. Введите высоту здания");
                        double height;
                        while (!double.TryParse(Console.ReadLine(), out height))
                        {
                            Console.WriteLine("Некореектное значение, попробуйте снова");
                        }
                        buildings[n].SetHeight(height);
                        short floors, apartaments, entrances;
                        Console.WriteLine("Введите кол-во этажей в доме");
                        while (!short.TryParse(Console.ReadLine(), out floors))
                        {
                            Console.WriteLine("Некореектное значение, попробуйте снова");
                        }
                        buildings[n].SetFloors(floors);
                        Console.WriteLine("Введите кол-во квартир в доме");
                        while (!short.TryParse(Console.ReadLine(), out apartaments))
                        {
                            Console.WriteLine("Некореектное значение, попробуйте снова");
                        }
                        buildings[n].SetApartaments(apartaments);
                        Console.WriteLine("Введите кол-во подъездов в доме");
                        while (!short.TryParse(Console.ReadLine(), out entrances))
                        {
                            Console.WriteLine("Некореектное значение, попробуйте снова");
                        }
                        buildings[n].SetEntrances(entrances);
                        buildings[n].GetBuildingInfo();
                        Console.ReadKey();
                        Console.Clear();
                        n++;
                        break;
                    case "2":
                        if (n < 1)
                        {
                            Console.WriteLine("Заполните информацию хотя бы об одном здании");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Введите номер здания 0 <= n <= {0}", n - 1);
                            int number;
                            while (!int.TryParse(Console.ReadLine(), out number) | number > (n - 1) | number < 0)
                            {
                                Console.WriteLine("Некорректное значение, попробуйте снова");
                            }
                            buildings[number].GetBuildingInfo();
                            Console.ReadKey();
                            Console.Clear();
                        }
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
