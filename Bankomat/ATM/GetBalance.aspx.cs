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
            

            if (Session["LoggedIn"] == null)
            {
                System.Threading.Thread.Sleep(2000);
                HttpContext.Current.Response.Redirect("Default.aspx");
            }

            theAtm = Session["theAtm"] as ATM;
            cardNumber = Convert.ToInt32(Session["LoggedIn"]);

            try
            {
                LabelBalance.Text = theAtm.GetBalance(cardNumber).ToString(); 
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
                List<string> theTransactions = theAtm.GetTransactions(cardNumber, 5);

                PanelTransactions.Controls.Add(new LiteralControl("<div class='transactions'>")); // Css-referens!!!
                foreach (var transaction in theTransactions)
                {
                    Label theTransaction = new Label();
                    theTransaction.ID = transaction;
                    theTransaction.Text = transaction;
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
                Panel PanelRecipe = Page.Master.FindControl("PanelRecipe") as Panel;

                List<string> theTransactions = theAtm.GetTransactions(cardNumber, 25);

                PanelRecipe.Controls.Add(new LiteralControl("<div class='transactionsRecipe'>")); // Css-referens!!!
                foreach (var transaction in theTransactions)
                {
                    Label theTransaction = new Label();
                    theTransaction.ID = transaction;
                    theTransaction.Text = transaction;
                    theTransaction.CssClass = "singleTransaction";
                    PanelTransactions.Controls.Add(theTransaction);
                    PanelTransactions.Controls.Add(new LiteralControl("<br />"));
                }
                PanelRecipe.Controls.Add(new LiteralControl("</div>"));
                try
                {
                    theAtm.PrintReciept();
                }
                catch (Exception ex)
                {
                    LabelBalance.Text = ex.Message;
                }

                theAtm.SaveATM();
                Session["LoggedIn"] = null;
                HttpContext.Current.Response.Redirect("Default.aspx");
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

        protected void button3Left_Click(object sender, EventArgs e)
        {
            theAtm.SaveATM();
            Session["LoggedIn"] = null;
            HttpContext.Current.Response.Redirect("Default.aspx");
        }

        protected void button1Left_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("GetMoney.aspx");
        }
    }
}