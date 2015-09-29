using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bank
{
    class Card
    {
        public int CardNumber { get; set; }
        public int Pin { get; set; }
        public int PinFailsInRow { get; set; }
        public bool isActivated { get; set; }

        public bool LogIn(int cardNumber, int pin)
        {
            if (isActivated)
            {
                if (pin == Pin)
                {
                    PinFailsInRow = 0;
                    dbAdapter.UpdateCardState(PinFailsInRow, isActivated, CardNumber);
                    return true;
                }
                else
                {
                    if (PinFailsInRow + 1 >= 3)
                    {
                        PinFailsInRow++;
                        isActivated = false;
                        dbAdapter.UpdateCardState(PinFailsInRow, isActivated, CardNumber);
                        throw new CustomException("Fel pin. Kortet spärrat.");
                    }
                    else
                    {
                        PinFailsInRow++;
                        dbAdapter.UpdateCardState(PinFailsInRow, isActivated, CardNumber);
                        throw new CustomException($"Fel pin. Du har {3 - PinFailsInRow} försök kvar");
                    }
                }
            }
            else
            {
                throw new CustomException("Kortet är spärrat!");
            }
        }
    }
}
