using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace tesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank.Bank bank = new Bank.Bank();

            Console.WriteLine( bank.Login(1000, 1234));
        }
    }
}
