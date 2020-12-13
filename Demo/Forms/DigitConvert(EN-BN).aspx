<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DigitConvert(EN-BN).aspx.cs" Inherits="Demo.Forms.DigitConvert_E_BN_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
        <asp:Button ID="btnClick" Text="Click" runat="server" OnClick="btnClick_Click"/>
        <asp:Label ID="lblNum" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
