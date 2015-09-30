using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bank;
using System.Data.SqlClient;
using System.Data;

namespace ATM
{
    public class ATM
    {
        int needOfHundreds;
        int needOfFivehundreds;
        Bank.Bank bank;

        public ATM(int atmID)
        {
            AtmID = atmID;
            LoadATM(AtmID);
            bank = new Bank.Bank();
           
        }

        public int AtmID { get; set; }
        public int Receipt { get; set; }
        public int Hundreds { get; set; }
        public int Fivehundreds { get; set; }

        public decimal GetBalance(int cardNumber)
        {
            return bank.GetBalance(cardNumber);
        }

        public List<string> GetTransactions(int cardNumber, int count)
        {
            return bank.GetTransactions(cardNumber, count);
        }

        public bool Login(int cardNumber, int pin)
        {
            return bank.Login(cardNumber, pin);
        }

        public void Withdrawal (int cardNumber, decimal amount)
        {
            
            if (IsMoneyAvailable(amount))
            {
                bank.Withdrawal(cardNumber, amount, "Bankomat");
                Hundreds -= needOfHundreds;
                Fivehundreds -= needOfFivehundreds;
            }
            else
            {
                //Felmeddelande! Pengar slut i bankomaten
            }
        }

        private bool IsRecieptAvailable()
        {
            if (1 > Receipt)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsthereHundreds()
        {
            bool hundreds = false;

            if (Hundreds > 0)
            {
                hundreds = true;
            }
            return hundreds;
        }
        public bool IsthereFiveHundreds()
        {
            bool hundreds = false;

            if (Fivehundreds> 0)
            {
                hundreds = true;
            }
            return hundreds;
        }

        public bool IsMoneyAvailable(decimal amount) //amount = 800
        {
            int needOfHundred = (int)amount % 500;  //needOfHundred = 300
            needOfHundreds = needOfHundred / 100; //needOfHundreds = 3

            needOfFivehundreds = (int)(amount-needOfHundred)/500; //needOfFivehundreds = 1

            if (needOfFivehundreds > Fivehundreds)  //fivehundreds = 0
            {
                needOfHundreds += (needOfFivehundreds-Fivehundreds)*5; //needOfHundreds = 5        
                needOfFivehundreds = needOfFivehundreds - Fivehundreds;

                if (needOfHundreds > Hundreds)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
            else // needOfFivehundreds < Fivehundreds
            {
                return true;          
            }
        }

        public void LoadATM(int atmID)
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=ACADEMY18;Initial Catalog=BankDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlDataReader myReader = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_getATMInfo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@ATMID", atmID));
                myReader = cmd.ExecuteReader();

                myReader.Read();
                Receipt = Convert.ToInt32(myReader["NumberOfReceipts"]);
                Hundreds = Convert.ToInt32(myReader["NumberOfHundreds"]);
                Fivehundreds = Convert.ToInt32(myReader["NumberOfFiveHundreds"]);
            }
            catch (Exception)
            {
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void SaveATM()
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=ACADEMY18;Initial Catalog=BankDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_updateATMInfo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@ATMID", AtmID));
                cmd.Parameters.Add(new SqlParameter("@NumberOfReceipts", Receipt));
                cmd.Parameters.Add(new SqlParameter("@NumberOfHundreds", Hundreds));
                cmd.Parameters.Add(new SqlParameter("@NumberOfFivehundreds", Fivehundreds));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}