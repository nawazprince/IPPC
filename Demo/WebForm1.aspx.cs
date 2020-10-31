using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbInsert_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["ItemName"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
            SqlDataSource1.InsertParameters["ItemRate"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtRate")).Text;
            SqlDataSource1.InsertParameters["ItemBrand"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtBrand")).Text;

            SqlDataSource1.Insert();
        }
    }
}