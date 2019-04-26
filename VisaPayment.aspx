<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisaPayment.aspx.cs" Inherits="VisaPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSourceVisapdf">
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Download Visa Details" />
    </form>
</body>
</html>
