using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static String Connection = new SqlConnectionStringBuilder { DataSource = ".\\local", InitialCatalog = "Stock", UserID = "sa", Password = "1231" }.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ShowGrid();
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void ShowGrid()
        {
            DataTable tb = new DataTable();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from ItemInformation", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();
            conn.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            TextBox txtItemFooter = (TextBox)GridView1.FooterRow.FindControl("txtItemFooter");
            TextBox txtBrandFooter = (TextBox)GridView1.FooterRow.FindControl("txtBrandFooter");
            TextBox txtRateFooter = (TextBox)GridView1.FooterRow.FindControl("txtRateFooter");

            if (e.CommandName.Equals("Add"))
            {
                SqlConnection conn = new SqlConnection(Connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"Insert into ItemInformation (ItemName,ItemBrand,ItemRate) values('{txtItemFooter.Text}','{txtBrandFooter.Text}','{txtRateFooter.Text}')", conn);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    DataTable tb = new DataTable();
                    cmd = new SqlCommand($"select * from ItemInformation", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tb);
                    GridView1.DataSource = tb;
                    GridView1.DataBind();
                    conn.Close();
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblId = (Label)GridView1.Rows[e.RowIndex].FindControl("lblId");
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"delete from ItemInformation where Id={lblId.Text}", conn);
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                DataTable tb = new DataTable();
                cmd = new SqlCommand($"select * from ItemInformation", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tb);
                GridView1.DataSource = tb;
                GridView1.DataBind();
                conn.Close();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            SqlConnection conn = new SqlConnection(Connection);

            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand($"select * from ItemInformation", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();
            conn.Close();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtItemEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtItemEdit");
            TextBox txtBrandEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBrandEdit");
            TextBox txtRateEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRateEdit");
            Label txtIdEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("txtIdEdit");
            
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"update ItemInformation set ItemName='{txtItemEdit.Text}', ItemBrand='{txtBrandEdit.Text}',ItemRate='{txtRateEdit.Text}' where Id={txtIdEdit.Text}", conn);
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                GridView1.EditIndex = -1;
                DataTable tb = new DataTable();
                cmd = new SqlCommand($"select * from ItemInformation", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tb);
                GridView1.DataSource = tb;
                GridView1.DataBind();
                conn.Close();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;

            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand($"select * from ItemInformation", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();
            conn.Close();

        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetItemName(string itemName)
        {
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Top 10 ItemName from ItemInformation where ItemName LIKE '"+ itemName + "%'", conn);
            //   cmd.Parameters.AddWithValue("@SearchItemName", );
            List<string> itemResult = new List<string>();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                itemResult.Add(dr["ItemName"].ToString());
            }
            conn.Close();
            dr.Close();
            return itemResult;
        }

        //public List<string> GetItemName(string itemName)
        //{
        //    // your code to query the database goes here
        //    List<string> result = new List<string>();

        //    SqlConnection Conn = new SqlConnection(Connection);
        //    using (SqlCommand obj_Sqlcommand = new SqlCommand("select Top 10 ItemName from ItemInformation where ItemName LIKE @SearchItemName+'%'", Conn))
        //    {
        //        if (Conn.State != ConnectionState.Open) Conn.Open();
        //        obj_Sqlcommand.Parameters.AddWithValue("@SearchItemName", itemName);
        //        SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
        //        while (obj_result.Read())
        //        {
        //            result.Add(obj_result["ItemName"].ToString().TrimEnd());
        //        }
        //        if (Conn.State != ConnectionState.Closed) Conn.Close();
        //    }
        //    return result;
        //}

    }
}