using AlchemyAccounting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Forms
{
    public partial class ImportExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }
        private void BindGridview()
        {
            using (SqlConnection con = new SqlConnection(dbFunctions.Connection))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/UploadFile/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(path);
                    // Connection String to Excel Workbook  
                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        //string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(dbFunctions.Connection);
                        bulkInsert.DestinationTableName = "Employee";
                        bulkInsert.WriteToServer(dr);
                        BindGridview();
                        lblMessage.Text = "Your file uploaded successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    lblMessage.Text = "Your file not uploaded";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}