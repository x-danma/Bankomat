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

            try
            {
                Console.WriteLine(bank.Withdrawal(1000, 6000, "Bankomat"));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
