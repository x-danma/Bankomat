using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Customer
    {
        private Guid id;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }

        public List<Account> Accounts { get; set; }
        public List<Card> Cards { get; set; }
    }
}
