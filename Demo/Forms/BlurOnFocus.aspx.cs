using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class BlurOnFocus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt1.Focus();
            }
        }

        protected void btnAllow_Click(object sender, EventArgs e)
        {
            txt1.Enabled = true;
            lbl.Text = "";
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            txt1.Enabled = false;
            lbl.Text = "";
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            lbl.Text = txt1.Text;
        }
    }
}