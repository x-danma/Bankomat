﻿using System;
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
        decimal needOfHundreds;
        decimal needOfFivehundreds;
        Bank.Bank bank;

        public ATM(int atmID)
        {
            AtmID = atmID;
            LoadATM(AtmID);
            bank = new Bank.Bank();
           
        }

        public int AtmID { get; set; }
        public int Reciept { get; set; }
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
            }
            else
            {
                //Felmeddelande! Pengar slut i bankomaten
            }
        }

        private bool IsRecieptAvailable()
        {
            if (1 > Reciept)
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
            decimal needOfHundred = amount % 500;  //needOfHundred = 300
            needOfHundreds = needOfHundred / 100; //needOfHundreds = 3

            needOfFivehundreds = (amount-needOfHundred)/500; //needOfFivehundreds = 1

            if (needOfFivehundreds > Fivehundreds)  //fivehundreds = 0
            {
                needOfHundreds = (needOfFivehundreds-Fivehundreds)*5; //needOfHundreds = 5

                if (needOfHundreds > Hundreds)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
            else //if needOfFivehundreds < Fivehundreds
            {
                if (needOfHundreds > Hundreds)
                {
                    return false;
                }

                else
                {
                    return true;
                }            
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
                Reciept = Convert.ToInt32(myReader["NumberOfReceipts"]);
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

        public void SaveATM(int amtID)
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=ACADEMY18;Initial Catalog=BankDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand cmd = new SqlCommand();

            try
            {
                myConnection.Open();
                cmd.Connection = myConnection;
                cmd.CommandText = "sp_getATMInfo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@ATMID", AtmID));
                cmd.Parameters.Add(new SqlParameter("@NumberOFReceipts", Reciept));
                cmd.Parameters.Add(new SqlParameter("@NumberOFHundreds", Hundreds));
                cmd.Parameters.Add(new SqlParameter("@NumberOFFivehundreds", Fivehundreds));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}