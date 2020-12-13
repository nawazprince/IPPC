using AlchemyAccounting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Forms
{
    public partial class ExportExcel : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(dbFunctions.Connection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) bindGridview();
        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        #region User Defined Methods  
        //Bind Gridview using stored procedure  
        private void bindGridview()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("USP_GetAllEmployees", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);
                gvExport.DataSource = ds;
                gvExport.DataBind();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }
        //Export Gridview data to Excel  
        protected void ExportToExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=GridDataExport.xlsx");
                Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                Response.ContentType = "application/excel";
                //vnd.openxmlformats-officedocument.spreadsheetml.sheet
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gvExport.AllowPaging = false;
                    gvExport.RenderControl(hw);
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }

        #endregion
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);  
        }
    }
}