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
                List<string> transactions = bank.GetTransactions(1000, 5);

                foreach (var item in transactions)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
