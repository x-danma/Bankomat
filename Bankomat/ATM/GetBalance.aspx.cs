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
        protected void Page_Load(object sender, EventArgs e)
        {
            theAtm = new ATM();
            LabelBalance.Text = theAtm.

        }

    }
}