using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace ATM
{
    public partial class SiteMaster : MasterPage
    {
        ATM atm;
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             atm = new ATM(1);

            // Testkod då databusen jävlas med mig
            //List<string> hej = new List<string>();//----------

            //hej.Add("tja"); //----------
            //hej.Add("hej");//----------
            //hej.Add("hallå");//----------
            //hej.Add("hejdå");//----------

            //Session["PanelRecipe"] =hej; //----------

            // Slut på testkoden



            if (Session["PanelRecipe"] != null)
            {
                Create25Recipe();
                System.Threading.Thread.Sleep(500);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Toogle", "toggleRecipe()", true);
            }


            //// Testkod då databusen jävlas med mig
            //int[] nej = new int[2]; //----------

            //nej[0] = 3; //----------
            //nej[1] = 2; //----------

            //Session["GetMoney"] = nej; //----------
            //// Slut på testkoden

            if (Session["GetMoney"] != null)
            {
                GetMyMoney();
                System.Threading.Thread.Sleep(7000);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Toogle", "toggleMoney()", true);
            }


        }

        private void GetMyMoney()
        {
            int[] theMoney = Session["GetMoney"] as int[];

            for (int i = 0; i < theMoney[1]; i++)
            {
                if (theMoney[0] == 0 && i == theMoney[1] - 1)
                {
                    PanelMoney.Controls.Add(new LiteralControl("<div class='visibleFive'></div>"));
                }
                else
                {
                    PanelMoney.Controls.Add(new LiteralControl("<div class='hiddenFive'></div>"));
                }             
            }

            for (int i = 0; i < theMoney[0]; i++)
            {
                if (i == theMoney[0] - 1)
                {
                    PanelMoney.Controls.Add(new LiteralControl("<div class='visibleHundred'></div>"));
                }
                else
                {
                    PanelMoney.Controls.Add(new LiteralControl("<div class='hiddenHundred'></div>"));
                }
                
            }




            Session["GetMoney"] = null;
        }

        private void Create25Recipe()
        {
            List<string> theTransactions = Session["PanelRecipe"] as List<string>;
            
            foreach (var transaction in theTransactions)
            {
                Label theTransaction = new Label();
                theTransaction.ID = transaction;
                theTransaction.Text = transaction;
                theTransaction.CssClass = "singleTransaction";
                PanelRecipe.Controls.Add(theTransaction);
                PanelRecipe.Controls.Add(new LiteralControl("<br />"));

            }
            
            Session["PanelRecipe"] = null;
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void numberButton_Click(object sender, EventArgs e)
        {
            Button tmpButton = sender as Button;

            string input = tmpButton.Text;

            TextBox inputField = (TextBox)MainContent.FindControl("inputField");
            TextBox textbox1 = (TextBox)MainContent.FindControl("textbox1");

            if (inputField.Text.Length >= 4)
            {
                Label warningLabel = (Label)MainContent.FindControl("warningLabel");
                warningLabel.Text = "Varning, du kan endast fylla i 4 siffror!";
            }
            else
            {
                inputField.Text = inputField.Text + "" + input;
                textbox1.Text = "*" + textbox1.Text;
            }
          
        }

        protected void numberButtonClear_Click(object sender, EventArgs e)
        {
            Button tmpButton = sender as Button;

            string input = tmpButton.Text;

            TextBox inputField = (TextBox)MainContent.FindControl("inputField");

            inputField.Text = "";

            TextBox textBox1 = (TextBox)MainContent.FindControl("textBox1");
            textBox1.Text = "";


        }

        protected void numberButtonOk_Click(object sender, EventArgs e)
        {
            TextBox inputField = (TextBox)MainContent.FindControl("inputField");
            int CardNumber = 1000;
            int Pin = Convert.ToInt32(inputField.Text);

            try
            {
                if (atm.Login(CardNumber, Pin))
                {
                    Session["LoggedIn"] = CardNumber;
                    System.Threading.Thread.Sleep(2000);
                    Session["theAtm"] = atm;
                    HttpContext.Current.Response.Redirect("GetMoney.aspx");
                    
                }
            }
            catch (Exception ex )
            {

                Label warninglabel = (Label)MainContent.FindControl("warninglabel");
                warninglabel.Text = ex.Message;
            }



            

        }
        
    }

}