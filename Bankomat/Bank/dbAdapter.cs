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
        public static bool Withdrawal(int accountNumber, decimal amount)
        {
            SqlConnection myConnection = getConnection();
            SqlDataReader myReader = null;
            SqlCommand cmd = new SqlCommand();

            //ERROR ID
            //0 = inget fel
            //1 = För lite pengar på konto
            //2 = större än dagens uttagsgrän
            //alt error message

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_Withdrawal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));
                cmd.Parameters.Add(new SqlParameter("@Amount", amount));
                cmd.Parameters.Add(new SqlParameter("@ErrorMsg", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@ErrorID", SqlDbType.VarChar));
                cmd.Parameters["@ErrorMsg"].Direction = ParameterDirection.Output;
                cmd.Parameters["@ErrorID"].Direction = ParameterDirection.Output;

                myReader = cmd.ExecuteReader();
                myReader.Read();
                int errorID = Convert.ToInt32(myReader["ErrorID"]);
                int errorMsg = Convert.ToInt32(myReader["ErrorMsg"]);

                if (errorID > 0 || errorMsg > 2)
                    throw new CustomException("Tekniskt fel.");
                else if (errorMsg == 1)
                    throw new CustomException("Konotot saknar täckning för uttaget");
                else if (errorMsg == 2)
                    throw new CustomException("Maxgränsen för dagligt uttag överskriden");
                else
                    return true;

            }
            catch (Exception)
            {
                throw new Exception("Kontakt till banken misslyckades.");
            }
            finally
            {
                myConnection.Close();
            }
        }
        public static Card GetCard(int cardNumber)
        {
            Card card = new Card();

            SqlConnection myConnection = getConnection();
            SqlDataReader myReader = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_getCard";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@CardNumber", cardNumber));


                myReader = cmd.ExecuteReader();
                myReader.Read();
                card.CardNumber = Convert.ToInt32(myReader["CardNumber"]);
                card.isActivated = Convert.ToBoolean(myReader["IsActivated"]);
                card.Pin = Convert.ToInt32("Pin");
                card.PinFailsInRow = Convert.ToInt32("PinFailsInRow");

            }
            catch (Exception)
            {
                throw new CustomException("Kortet kunde inte läsas. Kontakta ditt bankkontor.");
            }
            finally
            {
                myConnection.Close();
            }

            return card;
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
                throw new CustomException("Ogiltigt kort. Kontakta ditt bankkontor.");
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
                account.AccountNumber = Convert.ToInt32(myReader["AccountNumber"]);
                account.Balance = Convert.ToDecimal(myReader["Balance"]);
                account.WithdrawalLimitPerDay = Convert.ToDecimal(myReader["WithdrawalLimitPerDay"]);
                account.WithdrawalLimitPerTime = Convert.ToDecimal(myReader["WithdrawalLimitPerTime"]);
            }
            catch (Exception)
            {
                throw new CustomException("Ogiltigt kort. Kontakta ditt bankkontor.");
            }
            finally
            {
                myConnection.Close();
            }

            return account;

        }

        public static List<Transaction> GetTransactions(int accountID, int count)
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
                throw new CustomException("Kontakt till banken misslyckades");
            }
            finally
            {
                myConnection.Close();
            }

            return transactions;
        }

        public static void WriteClickLog(int customerID, string type, string result)
        {
            SqlConnection myConnection = getConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_WriteToClickLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@CustomerID", customerID));
                cmd.Parameters.Add(new SqlParameter("@Type", type));
                cmd.Parameters.Add(new SqlParameter("@Result", result));

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void UpdateCardState(int pinFailsInRow, bool isActivated, int cardNumber)
        {
            SqlConnection myConnection = getConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = $"UPDATE Card SET PinFailsInRow='{pinFailsInRow}', IsActivated='{isActivated}' WHERE CardNumber='{cardNumber}'";

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new CustomException("Kontakt till banken misslyckades");
            }
            finally
            {
                myConnection.Close();
            }

        }

        static SqlConnection getConnection()
        {
            SqlConnection myConnection = new SqlConnection("Data Source=localhost\\SQLExpress;Initial Catalog=BankDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //ANDREAS-PC\\SQLEXPRESS
            return myConnection;
        }
    }
}
