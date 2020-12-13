using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class IPPC : System.Web.UI.Page
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblPc.Text ="PC: "+ GetPcName();
                lblIp.Text = "IP: " + GetIp();
                lblMac.Text = "Ethernet MAC: " + GetMACAddress();
                lblWirelessMac.Text = "Wireless lan adapter wifi mac: " + Mac();

                //int loop1, loop2;
                //NameValueCollection coll;

                //// Load ServerVariable collection into NameValueCollection object.
                //coll = Request.ServerVariables;
                //// Get names of all keys into a string array.
                //String[] arr1 = coll.AllKeys;
                //for (loop1 = 0; loop1 < arr1.Length; loop1++)
                //{
                //    Response.Write("Key: " + arr1[loop1] + "<br>");
                //    String[] arr2 = coll.GetValues(arr1[loop1]);
                //    for (loop2 = 0; loop2 < arr2.Length; loop2++)
                //    {
                //        Response.Write("Value " + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
                //    }
                //}

            }
        }
        public static string GetIp()
        {
            return HttpContext.Current.Request.UserHostAddress.ToString().Trim();
        }
        public static string GetPcName()
        {
            string cn = "";
            try
            {
                //IPAddress myIP = IPAddress.Parse(GetIp());
                //IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                //List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                //string mycompNameRemote = compName[0];
                //return mycompNameRemote;
                //string[] computer_name = System.Net.Dns.GetHostEntry(
                //       System.Web.HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]).HostName.Split(new Char[] { '.' });

                string[] computer_name = System.Net.Dns.GetHostEntry(System.Web.HttpContext.Current.Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
                 cn = computer_name[0].ToString();
            }
            catch
            {
                cn= Dns.GetHostName();
            }
            return cn;
        }
        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        public string Mac()
        {
            try
            {
                string userip = Request.UserHostAddress;
                string strClientIP = Request.UserHostAddress.ToString().Trim();
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
                return err.Message;
            }
        }

    }
}