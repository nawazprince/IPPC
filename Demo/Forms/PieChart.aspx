<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PieChart.aspx.cs" Inherits="Demo.Forms.PieChart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"  
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h4 style="color: forestgreen;">  
        Pie Chart  
    </h4>  
    <asp:Chart ID="Chart1" AlternateText="No data" runat="server"
        BorderlineWidth="0" Height="300px" Width="300px" Palette="SeaGreen">  
        <%--<Titles>  
            <asp:Title ShadowOffset="10" Name="Items" />  
        </Titles>--%>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="True" Name="Default"  
                ForeColor="Black"/>  
        </Legends>  
        <Series>  
            <asp:Series Name="Default" Label="#PERCENT{P2}" LegendText="#VALX(#VALY)"/>  
        </Series>  
        <ChartAreas>  
            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />  
        </ChartAreas>  
    </asp:Chart>  
    </div>
    </form>
</body>
</html>
