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

        ATM theAtm;
        protected void Page_Load(object sender, EventArgs e)
		{
            theAtm = new ATM();

            if (!theAtm.IsthereHundreds())
            {
                getMoneyMessage.Text = "Det finns inga hundralappar i denna bankomat";
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

                if (GetMyMoney(Convert.ToInt32(inputField.Text)))
                {
                    getMoneyMessage.Text = "Uttaget genomförs";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Give money", "toggleMoney()", true);
                    System.Threading.Thread.Sleep(2000);
                    HttpContext.Current.Response.Redirect("Default.aspx");
                }

            }
            catch (Exception)
            {
                getMoneyMessage.Text = "Fel";
                
            }
            
        }

        bool GetMyMoney(int input)
        {
            bool isItTrue = false;

            isItTrue = true;

            return isItTrue;
        }

    }
}