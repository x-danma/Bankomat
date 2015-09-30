using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATM
{
	public partial class GetMoney : System.Web.UI.Page
	{
        int cardNumber;
        ATM theAtm;
        protected void Page_Load(object sender, EventArgs e)
		{
            

            if (Session["LoggedIn"] == null)
            {
                System.Threading.Thread.Sleep(2000);
                HttpContext.Current.Response.Redirect("Default.aspx");

            }

            cardNumber = Convert.ToInt32(Session["LoggedIn"]);

            theAtm = Session["theAtm"] as ATM;

            if (!theAtm.IsthereHundreds())
            {
                getMoneyMessage.Text = "Det finns inga hundralappar i denna bankomat";
                
            }
            if (!theAtm.IsthereFiveHundreds())
            {
                getMoneyMessage.Text = "Det finns inga femhundralappar i denna bankomat";

            }

            if (!theAtm.IsthereFiveHundreds() && !theAtm.IsthereFiveHundreds())
            {
                getMoneyMessage.Text = "Det finns inga sedlar i denna bankomat";

            }

        }

        protected void button1Right_Click(object sender, EventArgs e)
        {
            inputField.Text = "100";
        }
        protected void button2Right_Click(object sender, EventArgs e)
        {
            inputField.Text = "200";
        }
        protected void button3Right_Click(object sender, EventArgs e)
        {
            inputField.Text = "300";
        }
        protected void button4Right_Click(object sender, EventArgs e)
        {
            getMoneyMessage.Visible = true;
         
            try
            {
                if(theAtm.IsMoneyAvailable(Convert.ToInt32(inputField.Text)))               
                {
                    if (Convert.ToInt32(inputField.Text) <= 5000)
                    {
                        if ((Convert.ToDecimal(inputField.Text) % 100) % 1 == 0)
                        {
                            theAtm.Withdrawal(cardNumber, Convert.ToInt32(inputField.Text));
                            getMoneyMessage.Text = "Uttaget genomförs";
                            Session["GetMoney"] = 1;
                            System.Threading.Thread.Sleep(2000);
                            HttpContext.Current.Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            getMoneyMessage.Text = "Du får inte göra orimliga uttag. Uttag måste vara i jämna hundrabelopp";
                        }
                    }
                    else
                    {
                        getMoneyMessage.Text = "Du får som mest ta ut 5000 kr per tillfället";
                    }
                    
                }

            }
            catch (Exception ex)
            {
                getMoneyMessage.Text = ex.Message;                
            }
            
        }

        bool GetMyMoney(int input)
        {
            bool isItTrue = false;

            isItTrue = true;

            return isItTrue;
        }

        protected void button4Left_Click(object sender, EventArgs e)
        {
            inputField.Text = "";
        }

        protected void button3Left_Click(object sender, EventArgs e)
        {
            theAtm.SaveATM();
            Session["LoggedIn"] = null;
            System.Threading.Thread.Sleep(2000);
            HttpContext.Current.Response.Redirect("Default.aspx");
        }

        protected void button2Left_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("GetBalance.aspx");
        }
    }
}