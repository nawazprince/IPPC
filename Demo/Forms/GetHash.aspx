<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetHash.aspx.cs" Inherits="Demo.Forms.GetHash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txt" runat="server"></asp:TextBox>
            <asp:Button runat="server" ID="btnClick" Text="Click" OnClick="btnClick_Click"/>
            <asp:Label runat="server" ID="lbl"></asp:Label>
        </div>
    </form>
</body>
</html>
