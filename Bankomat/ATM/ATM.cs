using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM
{
    public class ATM
    {
        decimal needOfHundreds;
        decimal needOfFivehundreds;

        public int Reciept { get; set; }
        public int Hundreds { get; set; }
        public int Fivehundreds { get; set; }

        public void Withdrawal (decimal amount)
        {
            if (IsMoneyAvailable(amount))
            {

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
    }
}