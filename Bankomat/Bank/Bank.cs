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

        public decimal GetBalance(int cardNumber)
        {
            try
            {
                Customer customer = dbAdapter.GetCustomer(cardNumber);
                dbAdapter.WriteClickLog(customer.ID, "Check balance", "");
                return customer.GetBalance(cardNumber);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new CustomException("Tekniskt fel.");
            }
        }

        public bool Withdrawal(int cardNumber, decimal amount)
        {
            try
            {
                Customer customer = dbAdapter.GetCustomer(cardNumber);
                return customer.Withdrawal(cardNumber, amount);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new CustomException("Tekniskt fel.");
            }

        }

        public string GetTransactions(int cardNumber, int count)
        {
            try
            {
                Customer customer = dbAdapter.GetCustomer(cardNumber);
                dbAdapter.WriteClickLog(customer.ID, "Get Transactions", "");
                return customer.GetTransactions(cardNumber, count);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new CustomException("Tekniskt fel.");
            }
        }

        public bool Login(int cardNumber, int pin)          //ClickLog UserID?
        {
            try
            {
                Card card = dbAdapter.GetCard(cardNumber);
                return card.LogIn(cardNumber, pin);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new CustomException("Tekniskt fel.");
            }
        }   

    }
}
