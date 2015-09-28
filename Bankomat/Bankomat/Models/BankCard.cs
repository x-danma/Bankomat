using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat.Models
{
    public class BankCard
    {
        public string CardNumber { get; set; }
        public int PinCode { get; set; }
        public bool CardIsActivated { get; set; }
        public int PinFailsInRow { get; set; }

        private void DeactivateCard()
        {

        }

    }
}