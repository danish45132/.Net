<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RevenueReportVisa.aspx.cs" Inherits="RevenueReportVisa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceVisaRevenue">
            <Columns>
                <asp:BoundField DataField="Total Revenue" HeaderText="Total Revenue by Visa" ReadOnly="True" SortExpression="Total Revenue" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceVisaRevenue" runat="server" ConnectionString="<%$ ConnectionStrings:Proj_MFRPConnectionStringRevenue %>" SelectCommand="select sum(AmountDebit) as &quot;Total Revenue&quot; from transactionDetailsVisa "></asp:SqlDataSource>
    </form>
</body>
</html>
