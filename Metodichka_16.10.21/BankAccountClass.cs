using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodichka_16._10._21
{
    class BankAccount 
    {
        enum Type {Current, Saving};
        private Type accountType = Type.Current;
        private Guid id = Guid.NewGuid();
        private decimal balance = 0;
        public void Deposit(decimal amount)
        {
            balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (balance - amount >= 0)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств");
                Console.ReadKey();
            }
        }
        public void SwitchType()
        {
            if (accountType == Type.Current)
            {
                accountType = Type.Saving;
            }
            else
            {
                accountType = Type.Current;
            }
        }
        public void GetBalace()
        {
            Console.WriteLine("Номер счёта: {0}\nТип счета: {1}\nБаланс: {2}", id, accountType, balance);
        }
    }
}
