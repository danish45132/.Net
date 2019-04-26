using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using PassportDataLayer;
using PassportBusinessObjects;
using PassportBusinessLayer;


public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string fname = Request.Params["fname"].ToString();
        string mname = Request.Params["mname"].ToString();
        string lname = Request.Params["lname"].ToString();
        string userID = Request.Params["UserID"].ToString();
        string password = Request.Params["password"].ToString();
        string email = Request.Params["email"].ToString();
        string cpassword = Request.Params["cpassword"].ToString();

        PassportBusinessLayer.RegisterBL rblCheck = new PassportBusinessLayer.RegisterBL();
        bool result = rblCheck.ValidateUserEmail(email);
        //string str = dt.Rows[0][0].ToString();
        if (result==false)
        {
            if (password.Equals(cpassword))
            {
                PassportBusinessObjects.Register r = new PassportBusinessObjects.Register(userID, email, fname, mname, lname, password);
                PassportBusinessLayer.RegisterBL rbl = new PassportBusinessLayer.RegisterBL();
                int res = rbl.RegisterUser(r);
                if (res > 0)
                {
                    Response.Write("<script>window.location.href ='http://localhost:62241/Login.html'</script>");
                }
                else
                {
                    Response.Write("<script>alert('User Already Exits')</script><script>window.location.href ='http://localhost:62241/Register.html'</script>");
                }
            }
        }
        else 
        {
            Response.Write("<script>alert('User Already Exits')</script><script>window.location.href ='http://localhost:62241/Register.html'</script>");
        }
       // string userid = Request.Params[""]
    }
}