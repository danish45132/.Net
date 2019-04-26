using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using PassportBusinessObjects;
using PassportBusinessLayer;

public partial class Newpassport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Fname = Request.Params["fname"].ToString();
        string Mname = Request.Params["mname"].ToString();
        string Lname = Request.Params["lname"].ToString();
        string Gender = Request.Params["gender"].ToString();
        string D = Request.Params["date"].ToString();
        string Phone = Request.Params["phone"].ToString();
        string Email = Request.Params["email"].ToString();
        string pAddress = Request.Params["pAddress"].ToString();
        string perAddress = Request.Params["perAddress"].ToString();
        string pCode = Request.Params["pincode"].ToString();
        int pinCode = Convert.ToInt32(pCode);
        string city = Request.Params["city"].ToString();
        string state = Request.Params["state"].ToString();
        string Country = Request.Params["country"].ToString();
        string Education = Request.Params["education"].ToString();
        string HintQuestion = Request.Params["hintqusetion"].ToString();
        string HintAnswer = Request.Params["hintanswer"].ToString();
        string date1 = Convert.ToDateTime(D).ToString("dd-MM-yyyy");
        DateTime Date = DateTime.ParseExact(date1, "dd-MM-yyyy", null);
        DateTime Application_Date = DateTime.Now;
        string User_id = Request.Params["UserID"].ToString();
        Guid g;
        g = Guid.NewGuid();
        //Console.WriteLine(g);
        long Card_Number = 0;

        Random random = new Random();

        for (int i = 0; i < 17; i++)
        {
            Card_Number += (long)(Math.Pow(10, i) * random.Next(1, 10));
        }

        string Application_ID = Convert.ToString(g);
        
        PassportBusinessLayer.PassportBL pbl = new PassportBusinessLayer.PassportBL();

        int checkUser = pbl.CheckUser(User_id);

        if (checkUser ==0)
        {
            PassportBusinessObjects.Passport p = new PassportBusinessObjects.Passport(Application_ID, User_id, Fname, Mname, Lname, Gender, pAddress,
              perAddress, Country, Date, Phone, city, state, pinCode, Email, Education, HintQuestion, HintAnswer,
              Application_Date,Card_Number);
            PassportBusinessLayer.PassportBL Pbl = new PassportBL();
            int res = Pbl.PassPortRegister(p);
            if (res > 0)
            {
                var application_ID = Application_ID;
                Response.Write("<script>alert('Your Application Id = " + application_ID + "')</script><script>alert('Your Card Number Is = " + Card_Number + "')</script><script>window.location.href ='http://localhost:62241/Passport.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('Registration Failed')</script><script>window.location.href ='http://localhost:62241/Passport.aspx'</script>");
            }
        }
        else 
        {
            Response.Write("<script>alert('User Already Exit')</script><script>window.location.href ='http://localhost:62241/Passport.aspx'</script>");
        }


    }
}