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

    }
}
