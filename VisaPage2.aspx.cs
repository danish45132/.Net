using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VisaPage2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string VisaID = Request.Params["VisaID"].ToString();
        string delivery_date = Request.Params["delivery_date"].ToString();
        string dD = Convert.ToDateTime(delivery_date).ToString("dd-MM-yyyy");
        DateTime DeliveryDate = DateTime.ParseExact(dD, "dd-MM-yyyy", null);
        string entry_date = Request.Params["entry_date"].ToString();
        string eD = Convert.ToDateTime(entry_date).ToString("dd-MM-yyyy");
        DateTime EntryDate = DateTime.ParseExact(eD, "dd-MM-yyyy", null);
        string exit_date = Request.Params["exit_date"].ToString();
        string exD = Convert.ToDateTime(exit_date).ToString("dd-MM-yyyy");
        DateTime ExitDate = DateTime.ParseExact(exD, "dd-MM-yyyy", null);
        string First_Name = Request.Params["First_Name"].ToString();
        string Middle_Name = Request.Params["Middle_Name"].ToString();
        string Last_Name = Request.Params["Last_Name"].ToString();
        string dob = Request.Params["date_of_birth"].ToString();
        string db = Convert.ToDateTime(dob).ToString("dd-MM-yyyy");
        DateTime DOB = DateTime.ParseExact(db, "dd-MM-yyyy", null);
        string Mobile_Number = Request.Params["Mobile_Number"].ToString();
        string Email = Request.Params["Email"].ToString();
        string Passport = Request.Params["Passport_Number"].ToString();
        string pexpireDate = Request.Params["pass_expiry_date"].ToString();
        string expd = Convert.ToDateTime(pexpireDate).ToString("dd-MM-yyyy");
        DateTime PassportExpireDate = DateTime.ParseExact(expd, "dd-MM-yyyy", null);

        PassportBusinessLayer.VisaApplicantBL vbl = new PassportBusinessLayer.VisaApplicantBL();
        DataTable dt = vbl.VisaApplicationID(VisaID);
        int visaTypeId = int.Parse(dt.Rows[0][0].ToString());

        var strUniqueGuid = Guid.NewGuid().ToString();

        string ID = strUniqueGuid.Substring(0, 16);

        PassportBusinessObjects.VisaTypeDetails vtd = new PassportBusinessObjects.VisaTypeDetails(ID, DeliveryDate, EntryDate,
            ExitDate, First_Name, Middle_Name, Last_Name, Mobile_Number, DOB, Email, Passport, PassportExpireDate, visaTypeId);
        PassportBusinessLayer.VisaApplicantBL Vbl = new PassportBusinessLayer.VisaApplicantBL();
        int res = 0;
        if (visaTypeId == 1) 
        {
            res = Vbl.VisaTypeStudent(vtd);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPayment.html?=" + VisaID);
            }
            else 
            {
                Response.Write("<script>alert('Registration UnsuccessFull')</script><script>windows.location.href='http://localhost:62241/demo/index.html'</script>");
            }
        }
        else if (visaTypeId == 2) 
        {
            res = Vbl.VisaTypeBusiness(vtd);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPayment.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Registration UnsuccessFull')</script><script>windows.location.href='http://localhost:62241/demo/index.html'</script>");
            }
        }
        else if (visaTypeId == 3)
        {
            res = Vbl.VisaTypeEmployment(vtd);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPayment.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Registration UnsuccessFull')</script><script>windows.location.href='http://localhost:62241/demo/index.html'</script>");
            }
        }
        else if (visaTypeId == 4)
        {
            res = Vbl.VisaTypeTourist(vtd);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPayment.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Registration UnsuccessFull')</script><script>windows.location.href='http://localhost:62241/demo/index.html'</script>");
            }
        }
        else if (visaTypeId == 5)
        {
            res = Vbl.VisaTypeMedical(vtd);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPayment.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Registration UnsuccessFull')</script><script>windows.location.href='http://localhost:62241/demo/index.html'</script>");
            }
        }
        

        
    }
}