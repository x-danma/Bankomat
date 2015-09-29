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

        public string GetTransactions(int cardNumber, int count)
        {
            Account account = dbAdapter.GetAccount(cardNumber);
            return account.GetTransactions(cardNumber, count);
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }

        public List<Account> Accounts { get; set; }
        public List<Card> Cards { get; set; }
    }
}
