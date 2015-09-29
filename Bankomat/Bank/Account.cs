﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
     class Account
    {
        private int accountNumber; 
        private decimal balance;


        public Account()
        {
           // AccountID = id;
            //Balacne = dbAdapter;
        }

        public void Withdrawal(int amount)
        {
            if (amount < WithdrawalLimitPerTime)
            {
                if (Transactions.Where(t => t.Date.Date == DateTime.Now.Date && t.Amount < 0).Select(t => t.Amount).Sum() < WithdrawalLimitPerDay)
                {
                    balance -= amount;
                    logTransaction(amount, $"bankomat {DateTime.Now}");
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

        public void logTransaction(int amount, string description)
        {
            Transactions.Add(new Transaction { Amount = amount, Date = DateTime.Now, Description = description, AccountID = this.AccountID }); //Sätt dateTime automatiskt i Db, 
        }

        public int AccountID { get; set; }
        public int AccountNumber { get; set; }
//        public int ClearingNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal WithdrawalLimitPerTime { get; set; }
        public decimal WithdrawalLimitPerDay { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
