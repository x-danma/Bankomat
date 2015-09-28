using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bankomat.Models;

namespace Bankomat.DAL
{
    public class BankomatInitializer : DropCreateDatabaseIfModelChanges<BankomatContext>
    {
        protected override void Seed(BankomatContext context)
        {
            var atms = new List<Atm>
            {
                new Atm { Bills100 = 50, Bills500 = 20, Receipts = 1000 }
            };

            atms.ForEach(c => context.Atms.Add(c));
            context.SaveChanges();

            var banks = new List<Bank>
            {
                new Bank {Name="AWA Bank"}
            };

            banks.ForEach(c => context.Banks.Add(c));
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer { FirstName = "Andreas", LastName = "Syberg", SSN ="19880402-0215" }
            };

            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var accounts = new List<Account>
            {
                new Account { Customer = customers[0], AccountNumber=1234, ClearingNumber=1111, Balance=10000, WithdrawalLimitPerDay = 20000, WithdrawalLimitPerTime=5000 }
            };

            accounts.ForEach(c => context.Accounts.Add(c));
            context.SaveChanges();

            var transactions = new List<Transaction>
            {
                new Transaction { Amount = 500, Date = DateTime.Parse("2015-08-23"), Description = "bankomat", Account = accounts[0] }
            };

            transactions.ForEach(c => context.Transactions.Add(c));
            context.SaveChanges();


            var cards = new List<Card>
            {
                new Card {  Account=accounts[0], CardNumber = "123456789", Pin = 1234, PinFailsInRow = 0, isActivated = true  }
            };
            cards.ForEach(c => context.Cards.Add(c));
            context.SaveChanges();
        }
    }
}