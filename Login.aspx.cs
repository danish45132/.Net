using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using PassportBusinessLayer;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userID = Request.Params["user_id"].ToString();
        string password = Request.Params["password"].ToString();
        RegisterBL rbl = new RegisterBL();
        if (rbl.ValidateUser(userID,password))
        {
            Session["UserName"] = userID;
            //string username = Session["UserName"];
            //Session["Pwd"] = tbpwd.Text;  
            Response.Write("<script>window.location.href ='http://localhost:62241/Passport.aspx'</script>");
        }
        else
        {
            ViewState["UserName"] = userID;
            
            Response.Write("<script>alert('Incorrect User ID PASSWORD')</script><script>window.location.href ='http://localhost:62241/Login.html'</script>");

        }
        
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {

        
    }
}