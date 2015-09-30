using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Customer
    {
        public decimal GetBalance(int cardNumber)
        {
            Account account = dbAdapter.GetAccount(cardNumber);

            return account.Balance;
        }

        public List<string> GetTransactions(int cardNumber, int count)
        {
            Account account = dbAdapter.GetAccount(cardNumber);
            return account.GetTransactions(cardNumber, count);
        }

        public bool Withdrawal(int cardNumber, decimal amount, string description)
        {
            Account account = dbAdapter.GetAccount(cardNumber);
            return account.Withdrawal(amount, description);
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
    }
}
