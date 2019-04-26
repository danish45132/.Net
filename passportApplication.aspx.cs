using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassportBusinessObjects;
using PassportBusinessLayer;

public partial class passportApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Application_ID = Request.Params["Application_ID"].ToString();
            PassportBusinessLayer.PassportBL Pbl = new PassportBusinessLayer.PassportBL();
            int res = Pbl.ApplicationUser(Application_ID);
            if (res > 0)
            {
                ViewState["Application_ID"] = Application_ID;
                Response.Redirect("http://localhost:62241/Passport_Type.html?=" + Application_ID);
            }
            else
            {
                Response.Write("<script>alert('Invalid Application Id')</script><script>window.location.href ='http://localhost:62241/Passport.aspx'</script>");
            }
        
    }
}