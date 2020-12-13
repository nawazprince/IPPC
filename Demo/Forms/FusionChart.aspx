<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FusionChart.aspx.cs" Inherits="Demo.Forms.FusionChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fusion Chart</title>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/fusioncharts@3.12.2/fusioncharts.js"></script>  
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/fusioncharts@3.12.2/fusioncharts.charts.js"></script> 
     <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/fusioncharts@3.15.3/themes/fusioncharts.theme.zune.js"></script> 

    <script type="text/javascript">  
    FusionCharts.ready(function() { //FusionCharts Constructor    
        var demoChart = new FusionCharts({  
            //Instance    
            type: "pie2d",  
            renderAt: "chart-container", //ID of div element created in HTML
            height: "400",  
            width: "400",  
            dataFormat: "json",  
            dataSource: {  
                //Basic Chart Configuration & Cosmetics    
                "chart": {  
                    "caption": "Split of Food Sales by Category",  
                    "subCaption": "Last Year",  
                    "pieRadius": "75",  
                    "showPercentValues": "1",  
                    "theme": "zune"  
                },  
                "data": [{  
                    "Label": "Starters",  
                    "Value": "1050700"  
                }, {  
                    "label": "Snacks",  
                    "value": "1250400"  
                }, {  
                    "label": "Main Course",  
                    "value": "1463300"  
                }, {  
                    "label": "Desserts",  
                    "value": "491000"  
                }]  
            }  
        }).render();  
    });  
    </script>  
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="chart-container">Awesome Chart on its way!</div>
        </div>
    </form>
</body>
</html>
