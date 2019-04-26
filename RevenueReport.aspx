<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RevenueReport.aspx.cs" Inherits="RevenueReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceRevenue">
            <Columns>
                <asp:BoundField DataField="Column1" HeaderText="Revenue From Passport" ReadOnly="True" SortExpression="Column1" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceRevenue" runat="server" ConnectionString="<%$ ConnectionStrings:Proj_MFRPConnectionStringRevenue %>" SelectCommand="select sum(AmountDepit) from transactionDetails"></asp:SqlDataSource>
    </form>
</body>
</html>
