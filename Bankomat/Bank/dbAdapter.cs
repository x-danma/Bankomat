using System;
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
        static void Withdrawal()
        {
            SqlConnection connection = getConnection();

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = "SELECT account FROM Customer WHERE "

                    reader = command.ExecuteReader();
            }
        }

        static decimal GetBalance(int accountNumber)
        {
            decimal balance;

            SqlConnection myConnection = getConnection();
            SqlDataReader myReader = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_getBalance";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));

                myReader = cmd.ExecuteReader();
                myReader.Read();
                balance = Convert.ToDecimal(myReader["Balance"]);

            }
            catch (Exception)
            {
                throw new Exception ("Kontakt till banken kunde inte skapas");
            }
            finally
            {
                myConnection.Close();
            }

            return balance;
        } 

        static List<Transaction> GetTransactions(int accountNumber, int count)
        {
            List<Transaction> transactions = new List<Transaction>();



            return transactions;
        }

        static SqlConnection getConnection()
        {
            SqlConnection myConnection = new SqlConnection("Data Source=ANDREAS-PC\\SQLEXPRESS; Initial Catalog=Bank; Integrated Security=SSPI");
            //ANDREAS-PC\\SQLEXPRESS
            return myConnection;
        }
    }
}
