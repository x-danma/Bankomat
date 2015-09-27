using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public int CustomerID { get; set; }
        public int AccountNumber { get; set; }
        public int ClearingNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal WithdrawalLimitPerTime { get; set; }
        public decimal WithdrawalLimitPerDay { get; set; }

        public Customer Customer { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Card> Cards { get; set; }
    }
}