<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Demo.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <link href="../JS/AutoComplete-jquery-ui.css" rel="stylesheet" />
    <script src="../JS/Autocomplete-jquery-ui.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" ShowFooter="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <EditItemTemplate>
                            <asp:Label ID="txtIdEdit" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtItemEdit" runat="server" Text='<%# Eval("ItemName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblItem" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtItemFooter" runat="server"></asp:TextBox>
                            <%-- <asp:AutoCompleteExtender ServiceMethod="GetItemName" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtItemFooter"
                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                            </asp:AutoCompleteExtender>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Brand">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBrandEdit" runat="server" Text='<%# Eval("ItemBrand") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblBrand" runat="server" Text='<%# Eval("ItemBrand") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtBrandFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rate">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtRateEdit" runat="server" Text='<%# Eval("ItemRate") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRate" runat="server" Text='<%# Eval("ItemRate") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtRateFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CommandName="Add" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    </form>

    <script>
        $("[id*=txtItemFooter]").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/WebService1.asmx/GetItem",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "{ 'txt' : '" + $("[id*=txtItemFooter]").val() + "'}",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item,
                                value: item
                            };

                        }));

                    },
                    error: function (result) {
                        alert('error')
                    }
                });
            },

            minLength: 1,
        });
    </script>
</body>
</html>
