using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat.Models
{
    public class Card
    {
        public int CardID { get; set; }
        //public int CustomerID { get; set; }
        public int AccountID { get; set; }
        public string CardNumber { get; set; }
        public int Pin { get; set; }
        public int PinFailsInRow { get; set; }
        public bool isActivated { get; set; }


        public Customer Customer { get; set; }
        public Account Account { get; set; }

    }
}