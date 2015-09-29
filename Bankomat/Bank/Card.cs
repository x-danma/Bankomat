using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bank
{
    class Card
    {
        public string CardNumber { get; set; }
        public int Pin { get; set; }
        public int PinFailsInRow { get; set; }
        public bool isActivated { get; set; }


        public Account Account { get; set; }


        private void CardLogin()
        {

            SqlConnection myConnection = new SqlConnection();
            SqlCommand myCommand = new SqlCommand();

            myConnection.ConnectionString = @"Data Source= localhost\SQLEXPRESS;Initial Catalog=Contacts;Integrated Security=SSPI";

            SqlDataReader myReader = null;
            try
            {

                //öppnar en connection och startar SQL-commands för att selecta
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = "sp_SelectCardNumber";
                myCommand.CommandText = "sp_SelectPinNumber";
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //Input från View:n

                    // string cardNumberInput = textbox1.Text;
                    //string pinInput = textbox2.Text;

                    // if (CardNumberinput == CardNumber && pinInput == Pin )
                    {

                    }
                }
            }
            catch (Exception)
            {

            }

            finally
            {
                if (myReader != null) myReader.Close();
                if (myConnection != null) myConnection.Close();
            }


        }
    }
}
