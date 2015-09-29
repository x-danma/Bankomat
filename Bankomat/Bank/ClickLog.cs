using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class ClickLog
    {
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
    }
}
