<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportExcel.aspx.cs" Inherits="Demo.Forms.ExportExcel" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Export Excel</title>
</head>
<body>  
    <form id="form1" runat="server">  
        <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>  
            <asp:UpdatePanel ID="up1" runat="server">  
                <ContentTemplate>  
                    <fieldsetstyle="border: 1px dashed #ccc; margin-left: 10px; margin-top: 0px; text-align: right;  
padding-bottom: 10px; width: 20%; text-align: center;">  
                        <legendstyle="margin-right: 10px;"> 
                            <asp:Label ID="lblLegend" runat="server" Text="Export Gridview Data to Excel">

                            </asp:Label>
                                </legend>  
                                <tablewidth="80%" align="center">  
                                    <tr>  
                                        <td>  
                                            <asp:GridView ID="gvExport" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                <sortedascendingcellstyle backcolor="#F8FAFA" />
                                                <sortedascendingheaderstyle backcolor="#246B61" />
                                                <sorteddescendingcellstyle backcolor="#D4DFE1" />
                                                <sorteddescendingheaderstyle backcolor="#15524A" />
</asp:GridView>  
                                        </td>  
                                    </tr>  
                                    <tr>  
                                        <td>  
                                            <asp:Button ID="btnExcel" runat="server" Text="Excel" OnClick="btnExcel_Click" /> </td>  
                                    </tr>  
                          </table>  
                      </fieldset>  
                
                </ContentTemplate>  
                <Triggers >
                     <asp:PostBackTrigger ControlID="btnEXCEL" />   
                </Triggers>
       </asp:UpdatePanel>  
   </form>
</body>
</html>
