using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat.Models
{
    public class Customer
    {

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }

        public List<Account> Accounts { get; set; }
        public List<Card> Cards { get; set; }
    }
}