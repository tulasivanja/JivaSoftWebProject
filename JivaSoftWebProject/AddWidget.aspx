<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWidget.aspx.cs" Inherits="JivaSoftWebProject.AddWidget" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Widget</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add New Widget</h2>
            <asp:Label runat="server" Text="Inventory Code:" />
            <asp:TextBox ID="txtInventoryCode" runat="server" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Inventory Code is required." ControlToValidate="txtInventoryCode" ForeColor="Red" /><br />
            <asp:Label runat="server" Text="Description:" />
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" /><br />
            <asp:Label runat="server" Text="Quantity on Hand:" />
            <asp:TextBox ID="txtQuantityOnHand" runat="server" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Quantity on Hand is required." ControlToValidate="txtQuantityOnHand" ForeColor="Red" /><br />
            <asp:Label runat="server" Text="Reorder Quantity:" />
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ErrorMessage="Reorder Quantity must be a valid integer." ControlToValidate="txtReorderQuantity" 
                Operator="DataTypeCheck" Type="Integer" ForeColor="Red" />
            <br />
            <asp:TextBox ID="txtReorderQuantity" runat="server" /><br />
            <asp:Button ID="btnAdd" runat="server" Text="Add Widget" OnClick="btnAdd_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  CausesValidation="false" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" />
        </div>
    </form>
</body>
</html>
