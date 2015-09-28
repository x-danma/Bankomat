using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Card
    {
        public Guid CardID { get; set; }
        public string CardNumber { get; set; }
        public int Pin { get; set; }
        public int PinFailsInRow { get; set; }
        public bool isActivated { get; set; }


        public Account Account { get; set; }
    }
}
