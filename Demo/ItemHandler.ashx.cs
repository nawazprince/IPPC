using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Demo
{
    /// <summary>
    /// Summary description for ItemHandler
    /// </summary>
    public class ItemHandler : IHttpHandler
    {
        public static String Connection = new SqlConnectionStringBuilder { DataSource = ".\\local", InitialCatalog = "Stock", UserID = "sa", Password = "1231" }.ToString();


        
        public void ProcessRequest(HttpContext context)
        {
            string term = context.Request["term"] ?? "";
            List<string> listItemNames = new List<string>();

            SqlConnection conn = new SqlConnection(Connection);
            
            SqlCommand cmd = new SqlCommand("spGetItemNames", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@term",
                Value = term
            });
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                listItemNames.Add(rdr["ItemName"].ToString());
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(listItemNames));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}