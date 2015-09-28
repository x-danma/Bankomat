using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat.Models
{
    public class Atm
    {
        public int AtmID { get; set; }
        public int Bills100 { get; set; }
        public int Bills500 { get; set; }
        public int Receipts { get; set; }

    }
}