
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// ReSharper disable once CheckNamespace
namespace AlchemyAccounting
{    
    public static class dbFunctions
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        public static String Connection = new SqlConnectionStringBuilder { DataSource = ".\\local", InitialCatalog = "Demo", UserID="sa",Password="1231", MultipleActiveResultSets = true, ConnectTimeout=0 }.ToString();


        public static void DropDownAdd(DropDownList ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); list.Clear();
                //List.Add("Select");
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }

        public static void DropDownAddWithSelect(DropDownList ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); list.Clear();
                list.Add("--SELECT--");
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }

        public static void DropDownAddWithAll(DropDownList ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); list.Clear();
                list.Add("ALL");
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void EditableDropDownAdd(DropDownList ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); list.Clear();
                list.Add("Select");
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void ListAdd(ListBox ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                list.Clear();
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void TxtAdd(String sql, TextBox txtadd)
        {
            //String mystring = "";
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtadd.Text = reader[0].ToString();
                }
                if (con.State != ConnectionState.Closed) con.Close();
                reader.Close();
            }
            catch
            {
                //ignore
            }
            //return List;
        }

        public static void LblAdd(String sql, Label LblAdd)
        {
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    LblAdd.Text = reader[0].ToString();
                }
                if (con.State != ConnectionState.Closed) con.Close();
                reader.Close();
            }
            catch
            {
                //ignore
            }
        }

        public static string StringData(String sql)
        {
            string data = "";
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = reader[0].ToString();
                }
                if (con.State != ConnectionState.Closed) con.Close();
                reader.Close();
            }
            catch (Exception exception)
            {
                //ignore
            }
            return data;
        }
        public static string StringDataOneParameter(String sql, String parameterValue)
        {
            string data = "";
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PARAMETER", parameterValue);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = reader[0].ToString();
                }
                if (con.State != ConnectionState.Closed) con.Close();
                reader.Close();
            }
            catch
            {
                //ignore
            }
            return data;
        }

        public static void GridViewAdd(GridView ob, String sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
            }
            catch
            {
                //ignore
            }
            //return List;
        }
        public static void FormView(FormView ob, String sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
            }
            catch
            {
                //ignore
            }
            //return List;
        }
        public static string Dayformat(DateTime dt)
        {
            string mydate = dt.ToString("dd/MM/yyyy");
            return mydate;
        }
        public static string DayformatHifen(DateTime dt)
        {
            string mydate = dt.ToString("dd-MMM-yyyy");
            return mydate;
        }
        public static string TimeFormat(DateTime tt)
        {
            string myTime = tt.ToString("HH:mm:ss");
            return myTime;
        }
        public static string Monformat(DateTime mm)
        {
            string mymonth = mm.ToString("MMM");
            return mymonth;
        }
        public static DateTime Timezone(DateTime datetime)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime printDate = TimeZoneInfo.ConvertTime(datetime, timeZoneInfo);
            return printDate;
        }

        public static string IpAddress()
        {
            string clientIp="";
            try
            {
                clientIp = HttpContext.Current.Request.UserHostAddress.ToString().Trim();
            }
            catch
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                clientIp= ipAddress.ToString();
            }
            return clientIp;
        }
        public static string UserPc()
        {
            string cn="";
            try
            {
                string[] computer_name = System.Net.Dns.GetHostEntry(System.Web.HttpContext.Current.Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
                cn = computer_name[0].ToString();
            }
            catch
            {
                cn= Dns.GetHostName();
            }
            return cn;
        }
        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            try
            {
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
            }
           catch(Exception ex)
            {
                string msg = ex.Message;
            }
            return  sMacAddress;
        }

        public static string Mac()
        {
            try
            {
                //string userip =HttpContext.Current.Request.UserHostAddress;
                string strClientIP = HttpContext.Current.Request.UserHostAddress.ToString().Trim();
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");
                //if (mac_src == "0")
                //{
                //    if (userip == "127.0.0.1")
                //        Response.Write("visited Localhost!");
                //    else
                //        Response.Write("the IP from " + userip + "" + "<br>");
                //    return;
                //}

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                string mac_dest = "";

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }

                return mac_dest;
            }
            catch (Exception err)
            {
                return "";
            }
        }
        public static bool FieldCheck(string[] field)
        {
            bool checkResult = false;
            foreach (var data in field)
            {
                if (data == "")
                {
                    checkResult = false;
                    break;
                }
                else
                    checkResult = true;
            }
            return checkResult;
        }

        public static string FbProfilePicture(string userId)
        {
            string userid = userId;
            string fbusername = StringData("SELECT FBPIMG FROM ASL_USERCO WHERE USERID='" + userid + "'");
            var fbImageLink = "http:/" + "/graph.facebook.com/" + fbusername + "/picture?type=large";

            return fbImageLink;
        }

        public static string SliptText(string text, char sumbol)
        {
            string returnText = "";
            string searchPar = text;
            int splitter = searchPar.IndexOf(sumbol);
            if (splitter != -1)
            {
                string[] lineSplit = searchPar.Split(sumbol);

                returnText = lineSplit[1];
            }
            return returnText;
        }

        public static string SliptText(string text, char sumbol, int indexNo)
        {
            string returnText = "";
            string searchPar = text;
            int splitter = searchPar.IndexOf(sumbol);
            if (splitter != -1)
            {
                string[] lineSplit = searchPar.Split(sumbol);

                returnText = lineSplit[indexNo];
            }
            return returnText;
        }
        public static void DropDownAddSelectTextWithValue(DropDownList ob, String sql)
        {
            List<String> listName = new List<string>();
            List<String> listValue = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                listName.Clear();
                listValue.Clear();
                listName.Add("--SELECT--");
                listValue.Add("--SELECT--");
                while (rd.Read())
                {
                    listName.Add(rd[0].ToString());
                    listValue.Add(rd[1].ToString());
                }
                rd.Close();
                ob.Items.Clear();

                ob.Text = "";
                for (int i = 0; i < listName.Count; i++)
                {
                    ob.Items.Add(new ListItem(listName[i].ToUpper(), listValue[i]));
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void DropDownAddTextWithValue(DropDownList ob, String sql)
        {
            List<String> listName = new List<string>();
            List<String> listValue = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                listName.Clear();
                listValue.Clear();
                //List.Add("Select");
                while (rd.Read())
                {
                    listName.Add(rd[0].ToString());
                    listValue.Add(rd[1].ToString());
                }
                rd.Close();
                ob.Items.Clear();

                ob.Text = "";
                for (int i = 0; i < listName.Count; i++)
                {
                    ob.Items.Add(new ListItem(listName[i].ToUpper(), listValue[i]));
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void DropDownAddAllTextWithValue(DropDownList ob, String sql)
        {
            List<String> listName = new List<string>();
            List<String> listValue = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                listName.Clear();
                listValue.Clear();
                listName.Add("ALL");
                listValue.Add("ALL");
                while (rd.Read())
                {
                    listName.Add(rd[0].ToString());
                    listValue.Add(rd[1].ToString());
                }
                rd.Close();
                ob.Items.Clear();

                ob.Text = "";
                for (int i = 0; i < listName.Count; i++)
                {
                    ob.Items.Add(new ListItem(listName[i].ToUpper(), listValue[i]));
                }
            }
            catch
            {
                //ignore
            }
        }
        public static List<string> DataReaderAdd(String sql)
        {
            var list = new List<string>();
            try
            {
                var con = new SqlConnection(Connection);
                if (con.State != ConnectionState.Open) con.Open();
                var cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int count = rd.FieldCount;
                    for (int i = 0; i < count; i++)
                    {
                        list.Add(rd[i].ToString());
                    }
                }
                if (con.State != ConnectionState.Closed) con.Close();
                rd.Close();
                return list;
            }
            catch
            {
                return list;
            }
        }

        public static void GridBlankRow(GridView ob)
        {
            int columncount = ob.Rows[0].Cells.Count;
            ob.Rows[0].Cells.Clear();
            ob.Rows[0].Cells.Add(new TableCell());
            ob.Rows[0].Cells[0].ColumnSpan = columncount;
            ob.Rows[0].Cells[0].Text = "No Records Found";
        }

        public static string ExecuteQuery(String sql)
        {
            string data = "";
            SqlConnection con = new SqlConnection(Connection);
            if (con.State != ConnectionState.Open) con.Open();
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();
                tran = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sql, con) { Transaction = tran };

                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception exception)
            {
                tran.Rollback();
                data = exception.ToString();
            }
            return data;
        }

        public static string encrypt(string clearText)
        {
            try
            {
                byte[] hashBytes = computeHash(clearText + "asl");
                byte[] hashWithSaltBytes = new byte[hashBytes.Length];
                for (int i = 0; i < hashBytes.Length; i++)
                    hashWithSaltBytes[i] = hashBytes[i];
                string hashValue = Convert.ToBase64String(hashWithSaltBytes);

                return hashValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static byte[] computeHash(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            HashAlgorithm hash = new SHA256Managed();
            return hash.ComputeHash(plainTextBytes);
        }
    }
}
