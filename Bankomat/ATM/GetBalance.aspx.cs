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
            try
            {
                LabelBalance.Text = theAtm.GetBalance(cardNumber).ToString(); // Vadå kortnummer????
            }
            catch (Exception ex)
            {
                LabelBalance.Text = ex.Message; 
                
            }


            

        }

        protected void button1Right_Click(object sender, EventArgs e)
        {
            GetFiveTransaction();
        }

        private void GetFiveTransaction()
        {
            try
            {

                List<string> theTransactions = new List<string>();//theAtm.GetTransactions(cardNumber, 5);

                PanelTransactions.Controls.Add(new LiteralControl("<div class='transactions'>")); // Css-referens!!!
                foreach (var transaction in theTransactions)
                {
                    Label theTransaction = new Label();
                    //theTransaction.ID = transaction.;
                    //theTransaction.Text = transaction.;
                    theTransaction.CssClass = "singleTransaction";
                    PanelTransactions.Controls.Add(theTransaction);
                    PanelTransactions.Controls.Add(new LiteralControl("<br />"));

                }
                PanelTransactions.Controls.Add(new LiteralControl("</div>"));


            }
            catch (Exception ex)
            {
                LabelBalance.Text = ex.Message;

            }

        }
    

        protected void button2Right_Click(object sender, EventArgs e)
        {
            try
            {

                List<string> theTransactions = new List<string>();//theAtm.GetTransactions(cardNumber, 25);

                PanelTransactions.Controls.Add(new LiteralControl("<div class='transactions'>")); // Css-referens!!!
                foreach (var transaction in theTransactions)
                {
                    Label theTransaction = new Label();
                    //theTransaction.ID = transaction.;
                    //theTransaction.Text = transaction.;
                    theTransaction.CssClass = "singleTransaction";
                    PanelTransactions.Controls.Add(theTransaction);
                    PanelTransactions.Controls.Add(new LiteralControl("<br />"));

                }
                PanelTransactions.Controls.Add(new LiteralControl("</div>"));


            }
            catch (Exception ex)
            {
                LabelBalance.Text = ex.Message;

            }
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