<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" >
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<link href="StyleSheet2.css" rel="stylesheet" />
<!------ Include the above in your HEAD tag ---------->
    <title></title>
</head>
<body>
    <div class="wrapper fadeInDown">
  <div id="formContent">
    <!-- Tabs Titles -->

    <!-- Icon -->
    <div class="fadeIn first">
     <img src="assets/img/images.png" id="icon" alt="USERLOGO" />
    </div>

    <
    </div>

    <!-- Login Form -->
      <form id="form1" runat="server">
      <input type="text" id="login" class="fadeIn second" name="user_id" placeholder="login">
      <input type="password" id="password" class="fadeIn third" name="password" placeholder="password">
          <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
&nbsp;</form>

    <!-- Remind Passowrd -->
    <div id="formFooter">
      <a class="underlineHover" href="#">Forgot Password?        <a href="Register.html" class="underlineHover">Register</a>
        <br/>
         <a href="demo/index.html">Home</a>
    </div>

  </div>
</div>
</body>
</html>
