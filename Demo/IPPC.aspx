<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IPPC.aspx.cs" Inherits="Demo.IPPC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    <script type="text/javascript">

        //function load() {

        //    try {
        //        var ax = new ActiveXObject("WScript.Network");
        //        alert('User: ' + ax.UserName);
        //        alert('Computer: ' + ax.ComputerName);
        //    }
        //    catch (e) {
        //        document.write('Permission to access computer name is denied' + '<br />');
        //    }

        //};
        //function GetLocalIPAddr() {
        //    var oSetting = null;
        //    var ip = null;
        //    try {
        //        oSetting = new ActiveXObject("rcbdyctl.Setting");
        //        ip = oSetting.GetIPAddress;
        //        if (ip.length == 0)
        //        { return "Not connected Internet"; }
        //        oSetting = null;
        //    }
        //    catch (e) {
        //        return ip;
        //    }
        //    return ip;
        //}
        //document.write(GetLocalIPAddr() + "<br/>")

        //var WshShell = new ActiveXObject("WScript.Shell");
        //var com = "";
        //var user = "";
        //try{
        //    document.write("Computer name = " + WshShell.ExpandEnvironmentStrings("%COMPUTERNAME%") + "<br/>");
        //    document.write("Username = " + WshShell.ExpandEnvironmentStrings("%USERNAME%") + "<br/>");
        //}
        //catch(e){
        //    document.write(e.message)
        //}
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
                <asp:Label runat="server" ID="lblPc"></asp:Label>
            </h3>
            <br />
            <h3>
                <asp:Label runat="server" ID="lblIp"></asp:Label>
            </h3>
            <br />
            <h3>
                <asp:Label runat="server" ID="lblMac"></asp:Label>
            </h3>
            <br />
            <h3>
                <asp:Label runat="server" ID="lblWirelessMac"></asp:Label>
            </h3>
        </div>
    </form>
</body>
</html>
