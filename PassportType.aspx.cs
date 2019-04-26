using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassportBusinessObjects;
using PassportBusinessLayer;

public partial class PassportTypr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Application_ID = Request.Params["Application_ID"].ToString();
        string passportType = Request.Params["passportType"].ToString();
        string noP = Request.Params["NoOfPages"].ToString();
        int noOfPages = int.Parse(noP);
        PassportBusinessLayer.PassportBL Pbl = new PassportBusinessLayer.PassportBL();
        int result = Pbl.CheckApplicationID(Application_ID);
        if (result == 0)
        {
            PassportBusinessObjects.PassportType pType = new PassportType(passportType, noOfPages, Application_ID);
            PassportBusinessLayer.PassportBL pTypeBL = new PassportBusinessLayer.PassportBL();
            int res = pTypeBL.PassportTypeEntry(pType);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/passportStateDistrictRpo.html?=" + Application_ID);
            }
            else
            {
                Response.Write("<script>alert('Invalid Application Id')</script><script>window.location.href ='http://localhost:62241/Passport.aspx'</script>");
            }
        }
        else 
        {
            Response.Write("<script>alert('Application ID already Exits')</script><script>window.location.href ='http://localhost:62241/Passport.aspx'</script>");
        }
    }
}