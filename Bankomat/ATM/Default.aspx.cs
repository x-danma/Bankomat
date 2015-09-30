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
        ATM atm;

        protected void Page_Load(object sender, EventArgs e)
        {
           

            atm = new ATM(1);
            Session["theATM"] = atm;
        }
    }
}