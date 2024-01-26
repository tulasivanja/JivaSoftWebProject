<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JivaSoftWebProject._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Widget Inventory</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Widget Inventory List</h2>
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text="" />
            <asp:GridView ID="GridViewWidget" runat="server" AutoGenerateColumns="False" DataKeyNames="WidgetID" OnRowDeleting="GridViewWidget_RowDeleting" OnRowEditing="GridViewWidget_RowEditing" OnRowUpdating="GridViewWidget_RowUpdating" OnRowCancelingEdit="GridViewWidget_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="WidgetID" HeaderText="Widget ID" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="InventoryCode" HeaderText="Inventory Code" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="QuantityOnHand" HeaderText="Quantity on Hand" />
                    <asp:BoundField DataField="ReorderQuantity" HeaderText="Reorder Quantity" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnAddNew" runat="server" Text="Add New Widget" OnClick="btnAddNew_Click" />
        </div>
    </form>
</body>
</html>
