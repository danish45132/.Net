<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportpassport.aspx.cs" Inherits="Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSourceApplicantTotal" runat="server" ConnectionString="<%$ ConnectionStrings:Proj_MFRPConnectionStringReport %>" SelectCommand="select count(Application_Id) from Passport"></asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceSuccessApplicant" Width="673px">
            <Columns>
                <asp:BoundField DataField="Column1" HeaderText="Total Number Of Applicant with Passport" ReadOnly="True" SortExpression="Column1" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceSuccessApplicant" runat="server" ConnectionString="<%$ ConnectionStrings:Proj_MFRPConnectionStringApp %>" SelectCommand="select count(ApplicationID) from transactionDetails td join Passport p on td.ApplicationID=p.Application_Id"></asp:SqlDataSource>
    </form>
</body>
</html>
