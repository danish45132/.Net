<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportVisa.aspx.cs" Inherits="ReportVisa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <link href="assets/css/RPO.css" rel="stylesheet" />
    <link href="StyleSheet2.css" rel="stylesheet" />
</head>
<body>
        
     <section>
            <div class="include">
                   <div class="container">
    <h3 class="heading1">Visa Report</h3>
     <div class="form-group">
    <form id="form1" runat="server" style="padding-left:80px;">
    <div>
    
    </div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceVisaRep">
            <Columns>
                <asp:BoundField DataField="Number Of Visa Applicants" HeaderText="Number Of Visa Applicants" ReadOnly="True" SortExpression="Number Of Visa Applicants" />
                <asp:BoundField DataField="Visa_id" HeaderText="Visa_id" SortExpression="Visa_id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField=" Type Of Visa" HeaderText=" Type Of Visa" SortExpression=" Type Of Visa" />
                <asp:BoundField DataField="Date Of Issue" HeaderText="Date Of Issue" SortExpression="Date Of Issue" />
                <asp:BoundField DataField="Date Of Expiry" HeaderText="Date Of Expiry" SortExpression="Date Of Expiry" />
            </Columns>
        </asp:GridView>
            
        <asp:SqlDataSource ID="SqlDataSourceVisaRep" runat="server" ConnectionString="<%$ ConnectionStrings:Proj_MFRPConnectionStringVisaReport %>" SelectCommand="select count(Visa_id) as &quot;Number Of Visa Applicants&quot;,Visa_id, Name,Visa_type as &quot; Type Of Visa&quot;,Issue_date as &quot;Date Of Issue&quot;,Validity_date as &quot;Date Of Expiry&quot; from VISA_Details group by Name,Visa_id,Visa_type,Issue_date,Validity_date;"></asp:SqlDataSource>
    </form>
    </div>
                       </div>
                </div>
    </section>
</body>
</html>
