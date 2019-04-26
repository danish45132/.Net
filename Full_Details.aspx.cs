using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassportBusinessObjects;
using PassportBusinessLayer;
public partial class Full_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ApplicationID = Request.Params["ApplicationID"].ToString();
        string F_name = Request.Params["F_name"].ToString();
        string M_name = Request.Params["M_name"].ToString();
        string L_name = Request.Params["L_name"].ToString();
        string Father_Name = Request.Params["Father_Name"].ToString();
        string Mother_Name = Request.Params["Mother_Name"].ToString();
        string Dob = Request.Params["DateOfBirth"].ToString();
        string Email = Request.Params["Email"].ToString();
        string Phone_No = Request.Params["Phone_no"].ToString();
        string Present_Address = Request.Params["Present_Address"].ToString();
        string Permanent_Address = Request.Params["Permanent_Address"].ToString();
        string City = Request.Params["City"].ToString();
        string State = Request.Params["State"].ToString();
        string Pin_Code = Request.Params["Pin_Code"].ToString();
        int PinCode = int.Parse(Pin_Code);
        string Country = Request.Params["Country"].ToString();
        string Crime_Record = Request.Form["record"].ToString();
        string C_Record="";
        if(Crime_Record=="Yes")
        C_Record = Request.Params["C_Record"].ToString();
        string Running_Case = Request.Form["r_case"].ToString();
        string r_case = "";
        if (Running_Case == "Yes")
            r_case = Request.Params["r_case"].ToString();
        string Pan_Number = Request.Params["Pan_Card"].ToString();
        string Aadhar_Number = Request.Params["Aadhar_Card"].ToString();
        string Edu_Details = Request.Params["Education_Details"].ToString();
        string Edu_Proof = Request.Params["Education_Proof"].ToString();
        string Birth_Certificate = Request.Params["Birth_Certificate"].ToString();
        string Address_Proof = Request.Params["Address_Proof"].ToString();

        string d = Convert.ToDateTime(Dob).ToString("dd-MM-yyyy");
        DateTime DOB = DateTime.ParseExact(d, "dd-MM-yyyy", null);

        PassportBusinessObjects.ApplicantDetails PAD = new PassportBusinessObjects.ApplicantDetails(ApplicationID,Father_Name,
            Mother_Name, Present_Address, Permanent_Address, C_Record, r_case, Country, DOB, Phone_No, City, State, PinCode, Email,
            Pan_Number,Aadhar_Number,Address_Proof,Edu_Proof,Edu_Details,Birth_Certificate);
        PassportBusinessLayer.PassportBL PBL = new PassportBusinessLayer.PassportBL();
        int res = PBL.ApplicantDetails(PAD);
        if (res > 0) 
        {
            
            Response.Redirect("http://localhost:62241/paymentPage.html?="+ApplicationID);
            //Response.Write("<script>alert('Details Filled')</script>");
        }

        
        

    }
}