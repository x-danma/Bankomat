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
		protected void Page_Load(object sender, EventArgs e)
		{

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
            
        }
    }
}