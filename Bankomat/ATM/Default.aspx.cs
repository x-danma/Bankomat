using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATM
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(Session["GetMoney"]) != 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "document.getElementById('myMoney').style.visibility = 'visible';", true);

                Session["GetMoney"] = null;
            }
        }
    }
}