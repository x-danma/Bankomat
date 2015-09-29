using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class PersistanceController
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

                command.CommandText = "SELECT account FROM Customer WHERE ";

                    reader = command.ExecuteReader();
            }
        }

        static SqlConnection getConnection()
        {
            SqlConnection myConnection = new SqlConnection("Data Source=ANDREAS-PC\\SQLEXPRESS; Initial Catalog=Bank; Integrated Security=SSPI");
            //ANDREAS-PC\\SQLEXPRESS
            return myConnection;
        }
    }
}



static void PrintdAll()
{
    SqlConnection myConnection = getConnection();

    SqlDataReader myReader = null;

    try
    {
        myConnection.Open();
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;

        myCommand.CommandText = "SELECT * FROM Contact";

        myReader = myCommand.ExecuteReader();

        while (myReader.Read())
            Console.WriteLine($"{myReader["Firstname"].ToString()} {myReader["Lastname"].ToString()} - {myReader["SSN"].ToString()}");
    }
    catch (Exception)
    {

        throw;
    }
    finally
    {
        myConnection.Close();
    }