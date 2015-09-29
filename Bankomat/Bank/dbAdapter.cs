﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class dbAdapter
    {
        public static void Withdrawal()
        {

        }

        public static Customer GetCustomer(int cardNumber)
        {
            Customer customer = new Customer();

            SqlConnection myConnection = getConnection();
            SqlDataReader myReader = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_getCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@CardNumber", cardNumber));

                myReader = cmd.ExecuteReader();
                myReader.Read();
                customer.ID = Convert.ToInt32(myReader["ID"]);
                customer.FirstName = myReader["FirstName"].ToString();
                customer.LastName = myReader["LastName"].ToString();
                customer.SSN = myReader["SSN"].ToString();
            }
            catch (Exception)
            {
                throw new Exception("Kontakt till banken kunde inte skapas");
            }
            finally
            {
                myConnection.Close();
            }

            return customer;
        }

        public static Account GetAccount(int cardNumber)
        {
            Account account = new Account();

            SqlConnection myConnection = getConnection();
            SqlDataReader myReader = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_getAccount";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@CardNumber", cardNumber));

                myReader = cmd.ExecuteReader();
                myReader.Read();
                account.AccountID = Convert.ToInt32(myReader["AccountID"]);
                account.AccountNumber = Convert.ToInt32(myReader["AccountNumber"]);
                account.Balance = Convert.ToDecimal(myReader["Balance"]);
                account.WithdrawalLimitPerDay = Convert.ToDecimal(myReader["WithdrawalLimitPerDay"]);
                account.WithdrawalLimitPerTime = Convert.ToDecimal(myReader["WithdrawalLimitPerTime"]);
            }
            catch (Exception)
            {
                throw new Exception("Kontakt till banken kunde inte skapas");
            }
            finally
            {
                myConnection.Close();
            }

            return account;

        }

        public static List<Transaction> GetTransaction(int accountID, int count)
        {
            List<Transaction> transactions = new List<Transaction>();

            SqlConnection myConnection = getConnection();
            SqlDataReader myReader = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_getAccount";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@AccountID", accountID));
                cmd.Parameters.Add(new SqlParameter("@Count", count));

                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    Transaction transaction = new Transaction();
                    transaction.Amount = Convert.ToDecimal(myReader["Amount"]);
                    transaction.Date = DateTime.Parse(myReader["Date"].ToString());
                    transaction.Description = myReader["Description"].ToString();
                    transaction.TransactionID = Convert.ToInt32(myReader["TransactionID"]);
                }
            }
            catch (Exception)
            {
                throw new Exception("Kontakt till banken kunde inte skapas");
            }
            finally
            {
                myConnection.Close();
            }

            return transactions;
        }

        static void WriteClickLog(int CustomerID, DateTime date, string type, string result)
        {

        }

        static SqlConnection getConnection()
        {
            SqlConnection myConnection = new SqlConnection("Data Source=ANDREAS-PC\\SQLEXPRESS; Initial Catalog=Bank; Integrated Security=SSPI");
            //ANDREAS-PC\\SQLEXPRESS
            return myConnection;
        }
    }
}
