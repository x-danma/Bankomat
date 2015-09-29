using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Bank
    {

        public string Name { get; set; }
        public int Number { get; set; }

        public Bank()
        {
            Name = "AWA Bank";
            Number = 1234;
        }

        public decimal GetBalacne(int cardNumber)
        {
            try
            {
                Customer customer = dbAdapter.GetCustomer(cardNumber);
                dbAdapter.WriteClickLog(customer.ID, "Check balance", "Checked balnace");

                return customer.GetBalance(cardNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetTransactions(int cardNumber, int count)
        {
            Customer customer = dbAdapter.GetCustomer(cardNumber);
            return customer.GetTransactions(cardNumber, count);
        }

        public bool Login(int cardNumber, int pin)
        {
            Card card = dbAdapter.GetCard(cardNumber);

            return card.LogIn(cardNumber, pin);
        }

    }
}
