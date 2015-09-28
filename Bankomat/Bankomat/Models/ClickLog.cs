using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat.Models
{
    public class ClickLog
    {
        public Customer LogCustomer { get; set; }
        public DateTime LogDate { get; set; }
        public string LogType { get; set; }
        public string LogResult { get; set; }



    }
}