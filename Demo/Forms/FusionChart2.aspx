<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FusionChart2.aspx.cs" Inherits="Demo.Forms.FusionChart2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/fusioncharts@3.12.2/fusioncharts.js"></script>
    <script type="text/javascript">
        //function myJS(myVar){
        //    window.alert(myVar);
        //}
    </script>
   

</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Literal ID="FCLiteral1" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
