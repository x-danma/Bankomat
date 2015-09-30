using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
     class Account
    {
        public Account()
        {
        }

        public bool Withdrawal(decimal amount, string description)
        {
            if (amount < WithdrawalLimitPerTime)
            {
                dbAdapter.Withdrawal(AccountNumber, amount, description);
                return true;
            }
            else
            {
                throw new Exception($"Du kan inte ta ut mer än {WithdrawalLimitPerTime} åt gången");
            }
        }

        public List<string> GetTransactions(int cardNumber, int count)
        {
            List<Transaction> transactions = dbAdapter.GetTransactions(cardNumber, count);
            List<string> transactionsList = new List<string>();

            foreach (var transaction in transactions)
            {
                transactionsList.Add($"{transaction.Date}  {transaction.Amount} {transaction.Description}");
            }

            return transactionsList;
        }

        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal WithdrawalLimitPerTime { get; set; }
        public decimal WithdrawalLimitPerDay { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
