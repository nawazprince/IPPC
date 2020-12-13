<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlurOnFocus.aspx.cs" Inherits="Demo.BlurOnFocus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:TextBox CssClass="form-control" Width="200px" runat="server" ID="txt1"></asp:TextBox>
            <br />
            <%--<asp:Button CssClass="btn btn-success" runat="server" ID="btnAllow" Text="Focus Allow" OnClientClick="enable()" />
             <asp:Button CssClass="btn btn-default" runat="server" ID="btnDeny" Text="Focus Deny" OnClientClick="disable()"/>--%>

            <asp:Button CssClass="btn btn-default" runat="server" ID="btnGet" Text="Get Value" OnClick="btnGet_Click" />
            <button id="btn_disable" type="button">Disable the input</button>
            <button id="btn_enable" type="button">Enable the input</button>
            <br />
            <asp:Label runat="server" ID="lbl" CssClass="control-label" BorderStyle="Solid" Width="200px" Height="40px"></asp:Label>
        </div>
    </form>
    <script>
        $(document).ready(function () {
            //$("#btn_disable").click(function () {
            //    $("#txt1").attr("onfocus", "blur()");
            //});
            //$("#btn_enable").click(function () {
            //    $("#txt1").removeAttr("onfocus");
            //});

            $("#btn_disable").click(function () {
                $("#txt1").prop("readOnly", true);
            });
            $("#btn_enable").click(function () {
                $("#txt1").prop("readOnly",false)
            });

        });
    </script>

</body>
</html>
