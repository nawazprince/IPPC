using AlchemyAccounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace Demo.Forms
{
    public partial class PieChart : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(dbFunctions.Connection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindchart();
            }
        }
        protected void Bindchart()
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand($"SELECT Quarter,Sale FROM QuarterSale", con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable ChartData = ds.Tables[0];

                //storing total rows count to loop on each Record  
                string[] XPointMember = new string[ChartData.Rows.Count];
                int[] YPointMember = new int[ChartData.Rows.Count];

                for (int count = 0; count < ChartData.Rows.Count; count++)
                {
                    //storing Values for X axis  
                    XPointMember[count] = ChartData.Rows[count]["Quarter"].ToString();
                    //storing values for Y Axis  
                    YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Sale"]);

                }
                //binding chart control  
                Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);

                //Setting width of line  
                Chart1.Series[0].BorderWidth = 1;
                //setting Chart type   
                Chart1.Series[0].ChartType = SeriesChartType.Pie;
                // By sorting the data points, they show up in proper ascending order in the legend
                Chart1.DataManipulator.Sort(PointSortOrder.Descending, Chart1.Series[0]);
                foreach (Series charts in Chart1.Series)
                {
                    foreach (DataPoint point in charts.Points)
                    {
                        //switch (point.AxisLabel)
                        //{
                        //    case "Q1": point.Color = Color.RoyalBlue; break;
                        //    case "Q2": point.Color = Color.SaddleBrown; break;
                        //    case "Q3": point.Color = Color.SpringGreen; break;
                        //}                       
                        //point.Label = string.Format("{0:0}-{1}", point.YValues[0], point.AxisLabel);                      
                        point.LabelForeColor = Color.Black;
                        point.LabelBackColor = Color.White;

                    }
                }
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}