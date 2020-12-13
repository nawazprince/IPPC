using AlchemyAccounting;
using InfoSoftGlobal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Forms
{
    public partial class FusionChart2 : System.Web.UI.Page
    {
        DataTable dt = new DataTable("Chart");

        string GraphWidth = "450";

        string GraphHeight = "420";

        string[] color = new string[12];
        

        SqlConnection conn = new SqlConnection(dbFunctions.Connection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                ConfigureColors();

                LoadGraphData();

                CreatePieGraph();

            }
        }
        private void ConfigureColors()

        {

            color[0] = "AFD8F8";

            color[1] = "F6BD0F";

            color[2] = "8BBA00";

            color[3] = "FF8E46";

            color[4] = "008E8E";

            color[5] = "D64646";

            color[6] = "8E468E";

            color[7] = "588526";

            color[8] = "B3AA00";

            color[9] = "008ED6";

            color[10] = "9D080D";

            color[11] = "A186BE";

        }

        private DataTable LoadGraphData()

        {

            conn.Open();

            string cmd = "select year,sale from Sales";

            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);

            adp.Fill(dt);

            conn.Close();

            return dt;

        }
        private void CreatePieGraph()

        {

            string strCaption = "Year wise Sales report";

            string strSubCaption = "2000 - 2008";

            string xAxis = "Year";

            string yAxis = "Sale";

            //strXML will be used to store the entire XML document generated

            string strXML = null;

            //Generate the graph element

            strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0'

                          pieSliceDepth='30' formatNumberScale='0'

                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'>";

            int i = 0;

            foreach (DataRow DR in dt.Rows)

            {

                strXML += "<set name='" + DR[0].ToString() + "' value='" + DR[1].ToString() + "' color='" + color[i] + @"'  link=&quot;JavaScript:myJS('" + DR["year"].ToString() + ", " + DR["sale"].ToString() + "'); &quot;/>";

                i++;

            }

            //Finally, close <graph> element

            strXML += "</graph>";

            FCLiteral1.Text = FusionCharts.RenderChartHTML(

                "FusionCharts/FCF_Pie3D.swf", // Path to chart's SWF

                "",                              // Leave blank when using Data String method

                strXML,                          // xmlStr contains the chart data

                "mygraph1",                      // Unique chart ID

                GraphWidth, GraphHeight,         // Width & Height of chart

                false

                );

        }
    }
}