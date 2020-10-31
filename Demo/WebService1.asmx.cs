using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Demo
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    
    public class WebService1 : System.Web.Services.WebService
    {
        public static String Connection = new SqlConnectionStringBuilder { DataSource = ".\\local", InitialCatalog = "Stock", UserID = "sa", Password = "1231" }.ToString();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
         
        //[WebMethod] 
        //public List<string> GetItemName(string itemName)
        //{
        //    // your code to query the database goes here
        //    List<string> result = new List<string>();

        //    SqlConnection Conn = new SqlConnection(Connection);
        //    using (SqlCommand obj_Sqlcommand = new SqlCommand("select Top 10 ItemName from ItemInformation where ItemName LIKE '%'+@SearchItemName+'%'", Conn))
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
        [WebMethod]        public List<string> GetItem(string txt)        {            SqlConnection conn = new SqlConnection(Connection);            List<string> result = new List<string>();            try            {
                string query = @"select Top 10 ItemName txt from ItemInformation where ItemName LIKE '%'+@SearchItemName+'%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchItemName", txt);
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(reader["txt"].ToString().TrimEnd());
                }
            }            catch (Exception ex) { }            return result;        }
    }
}
