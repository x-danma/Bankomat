using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATM
{
    public partial class GetBalance : System.Web.UI.Page
    {
        ATM theAtm;
        int cardNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            theAtm = new ATM();
            cardNumber = 12345;
            LabelBalance.Text = theAtm.GetBalance(cardNumber).ToString(); // Vadå kortnummer????

        }

        protected void button1Right_Click(object sender, EventArgs e)
        {

        }
        protected void button2Right_Click(object sender, EventArgs e)
        {

        }
        protected void button3Right_Click(object sender, EventArgs e)
        {

        }
        protected void button4Right_Click(object sender, EventArgs e)
        {
            

            try
            {

                

            }
            catch (Exception)
            {
                

            }

        }
    }
}