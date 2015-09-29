using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Bank
    {
        public Bank(string name)
        {
        }

        public decimal GetBalacne(int cardNumber)
        {
            Customer customer = dbAdapter.GetCustomer(cardNumber);

            return customer.GetBalance(cardNumber);
        }

        public bool Login(int cardNumber, int pin)
        {
            Card card = dbAdapter.GetCard(cardNumber);

            return card.LogIn(cardNumber, pin);
        }

    }
}
