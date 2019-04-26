<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Passport.aspx.cs" Inherits="Passport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/css/Passport.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <style>
        #btn1 {
            position: absolute;
            top: 500px;
            left: 800px;
        }
        input[type='text']
        {

        }
        
    </style>
</head>
<body>
    <div class="box">
	    <div class="boxcontainer" runat="server" id="div1">
            <a id="newpassport" runat="server" value="1"  class="button">Apply New Passport</a>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <a class="button" href="RenewPassport.html">Renew Passport</a>         
        </div>
        <div class="boxcontainer" runat="server"  style="position:absolute;top:55%;left:42%;">
            <a id="A2" href="VisaPage1.html" runat="server" value="2" class="button">Apply For Visa</a>
            &nbsp;&nbsp;&nbsp;&nbsp;            
        </div>
    </div>
    <div class="container">  <!-- Trigger the modal with a button -->
  <button type="button" id="btn1" class="btn btn-info btn-md" data-toggle="modal" data-target="#myModal">Already Have Application ID?</button>

  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Modal Header</h4>
        </div>
        <div class="modal-body">
          <form action="passportApplication.aspx" method="post">
              <div class="row">
                  <div class="col-md-4">
                      Enter Application ID
                  </div>
                  <div class="col-md-6">
                      <input type="text" name="Application_ID" class="form-control" />
                  </div>
              </div>
              <br></br>
              <div class="row">
                  <div class="col-md-offset-6 ">
                      <input type="Submit" class="btn btn-danger" />
                  </div>
              </div>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
  
</div>
</body>
</html>
