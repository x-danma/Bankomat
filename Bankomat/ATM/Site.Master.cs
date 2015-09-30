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
             atm = new ATM();
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
                }
            }
            catch (Exception ex )
            {

                Label warninglabel2 = (Label)MainContent.FindControl("warninglabel");
                warninglabel2.Text = ex.Message;
            }

            

        }
        
    }

}