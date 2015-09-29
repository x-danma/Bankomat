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

        public bool Withdrawal(decimal amount)
        {
            if (amount < WithdrawalLimitPerTime)
            {
                if (Transactions.Where(t => t.Date.Date == DateTime.Now.Date && t.Amount < 0).Select(t => t.Amount).Sum() < WithdrawalLimitPerDay)
                {
                    dbAdapter.Withdrawal(AccountNumber, amount);
                    return true;
                }
                else
                {
                    throw new Exception($"Du kan inte ta ut mer än {WithdrawalLimitPerDay} per dag");
                }
            }
            else
            {
                throw new Exception($"Du kan inte ta ut mer än {WithdrawalLimitPerTime} åt gången");
            }
        }

        public string GetTransactions(int cardNumber, int count)
        {
            List<Transaction> transactions = dbAdapter.GetTransactions(cardNumber, count);

            StringBuilder transactionsString = new StringBuilder();

            foreach (var transaction in transactions)
            {
                transactionsString.Append(transaction.Date + ";" + transaction.Amount + ";" + transaction.Description + ";" );
            }

            return transactionsString.ToString();
        }

        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal WithdrawalLimitPerTime { get; set; }
        public decimal WithdrawalLimitPerDay { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
