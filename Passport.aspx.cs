using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PassportBusinessLayer;

public partial class Passport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            string s = Session["UserName"].ToString();
            RegisterBL b = new RegisterBL();
            DataTable dt = b.UserInfo(s);
            string fname = dt.Rows[0][0].ToString();
            string mname = dt.Rows[0][1].ToString();
            string lname = dt.Rows[0][2].ToString();
            string email = dt.Rows[0][3].ToString();
            string User_ID = dt.Rows[0][4].ToString();
            ViewState["fname"] = fname;
            ViewState["mname"] = mname;
            ViewState["lname"] = lname;
            ViewState["e_mail"] = email;
            ViewState["User_ID"] = User_ID;
                       
                newpassport.HRef = "newpassport.html?" + fname + "&" + mname + "&" + lname + "&" + email + "&" + User_ID;
        }
        
    }
}