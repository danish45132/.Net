using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassportBusinessLayer;
using PassportBusinessObjects;
using PassportDataLayer;

public partial class VisaPage1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string First_name = Request.Params["First_Name"].ToString();
        string Middle_name = Request.Params["Middle_Name"].ToString();
        string Last_name = Request.Params["Last_Name"].ToString();
        string Email_address = Request.Params["Email_address"].ToString();
        string Date_of_birth = Request.Params["dob"].ToString();
        string d = Convert.ToDateTime(Date_of_birth).ToString("dd-MM-yyyy");
        DateTime DOB = DateTime.ParseExact(d, "dd-MM-yyyy", null);
        string gender = Request.Params["gender"].ToString();
        string origin_country1 = Request.Params["origin_country1"].ToString();
        string destination_country1 = Request.Params["destination_country1"].ToString();
        string visatype_id = Request.Params["visaType"].ToString();
        int visa_type_id = 0;
        string visa_type = "";
        if (visatype_id == "1")
        {
            visa_type = "Student";
            visa_type_id = 1;
        }
        else if (visatype_id == "2")
        {
            visa_type = "Business";
            visa_type_id = 2;
        }
        else if (visatype_id == "3")
        {
            visa_type = "Tourist";
            visa_type_id = 3;
        }
        else if (visatype_id == "4")
        {
            visa_type = "Employment";
            visa_type_id = 4;
        }
        else if (visatype_id == "5")
        {
            visa_type = "Medical";
            visa_type_id = 5;
        }
        string Period = Request.Params["Period"].ToString();
        string purpose = Request.Params["purpose"].ToString();
        string invite = Request.Params["invite"].ToString();
        string Address = Request.Params["Address"].ToString();
        string Proof_Address = Request.Params["Proof_Address"].ToString();
        string NID = Request.Params["NID"].ToString();
        string National_ID_type = Request.Params["National_ID_type"].ToString();
        string National_ID = Request.Params["National_ID"].ToString();
        string passportMain = Request.Params["passportMain"].ToString();
        string passportMatch = Request.Params["passportMatch"].ToString();
        string Bank_Statement = Request.Params["Bank_Statement"].ToString();
        string phone = Request.Params["phone"].ToString();
        string Phone_number = Request.Params["Phone_number"].ToString();
        string Mobile_number = phone + "" + Phone_number;
        string picker = Request.Params["picker"].ToString();
        string Minor_certificate = Request.Params["Minor_certificate"].ToString();
        string Minors_parents_visa = Request.Params["Minors_parents_visa"].ToString();
        string Minors_parents_passport = Request.Params["Minors_parents_passport"].ToString();
        string Letter_of_authorisation = Request.Params["Letter_of_authorisation"].ToString();
        var strUniqueGuid = Guid.NewGuid().ToString();
        string VisaID = strUniqueGuid.Substring(0, 16);

        PassportBusinessLayer.VisaApplicantBL vbl = new PassportBusinessLayer.VisaApplicantBL();
        PassportBusinessObjects.VisaApplicant Vs = null;
        int res = 0;
        //US VISA DATA

        if (destination_country1 == "usa")
        {
            string citizen_type = Request.Params["citizen_type"].ToString();
            string Medical_report = Request.Params["Medical_report"].ToString();
            string Driving_Licence = Request.Params["Driving_Licence"].ToString();
            string Visit_US = Request.Params["Visit_US"].ToString();
            string Social_Security_Number = Request.Params["Social_Security_Number"].ToString();
            Vs = new PassportBusinessObjects.VisaApplicant(VisaID, First_name,
                Middle_name, Last_name, Email_address, origin_country1, destination_country1, passportMain, DOB, gender, Address, Proof_Address,
                purpose, Bank_Statement, visa_type, National_ID_type, National_ID, visa_type_id, Minor_certificate, Minors_parents_visa, Minors_parents_passport, citizen_type, Medical_report,
                Driving_Licence, Visit_US, Social_Security_Number);

            res = vbl.VisaApplicantUS(Vs);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPage2.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Register UnsucessFull')</script><script>windows.location.href='http://localhost:62241/VisaPage1.html'</script>");
            }
        }
        //UK VISA Data
        else if (destination_country1 == "uk")
        {

            string Earlier_visa = Request.Params["Earlier_visa"].ToString();
            string PrevVisa = Request.Params["PrevVisa"].ToString();
            string Medical_cert = Request.Params["Medical_cert"].ToString();
            string Marriage_cert = Request.Params["Marriage_cert"].ToString();
            string TravelHistory = Request.Params["TravelHistory"].ToString();
            string Highest_edu = Request.Params["Highest_edu"].ToString();
            Vs = new PassportBusinessObjects.VisaApplicant(VisaID, First_name,
                Middle_name, Last_name, Email_address, origin_country1, destination_country1, passportMain, DOB, gender, Address, Proof_Address,
                purpose, Bank_Statement, visa_type, National_ID_type, National_ID, visa_type_id, Minor_certificate, Minors_parents_visa, Minors_parents_passport, Earlier_visa,
                PrevVisa, Medical_cert, Marriage_cert, TravelHistory, Highest_edu);
            res = vbl.VisaApplicantUK(Vs);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPage2.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Register UnsucessFull')</script><script>windows.location.href='http://localhost:62241/VisaPage1.html'</script>");
            }
        }
        //China VISA Data
        else if (destination_country1 == "china")
        {
            string business_letter = Request.Params["business_letter"].ToString();
            string Salary_Slip = Request.Params["Salary_Slip"].ToString();
            string ChVisa = Request.Params["ChVisa"].ToString();
            string prevChina = Request.Params["prevChina"].ToString();
            string medi_report = Request.Params["medi_report"].ToString();
            Vs = new PassportBusinessObjects.VisaApplicant(VisaID, First_name,
                Middle_name, Last_name, Email_address, origin_country1, destination_country1, passportMain, DOB, gender, Address, Proof_Address,
                purpose, Bank_Statement, visa_type, National_ID_type, National_ID, visa_type_id, Minor_certificate, Minors_parents_visa, Minors_parents_passport,
                business_letter, Salary_Slip, prevChina, medi_report);
            res = vbl.VisaApplicantCHINA(Vs);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPage2.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Register UnsucessFull')</script><script>windows.location.href='http://localhost:62241/VisaPage1.html'</script>");
            }
        }
        //Germany VISA Data
        else if (destination_country1 == "germany")
        {
            string Health_Insurance = Request.Params["Health_Insurance"].ToString();
            string Proof_of_accomodation = Request.Params["Proof_of_accomodation"].ToString();
            string Acceptance_letter_student = Request.Params["Acceptance_letter_student"].ToString();
            string Financial_sustainability = Request.Params["Financial_sustainability"].ToString();
            Vs = new PassportBusinessObjects.VisaApplicant(VisaID, First_name,
                Middle_name, Last_name, Email_address, origin_country1, destination_country1, passportMain, DOB, gender, Address, Proof_Address,
                purpose, Bank_Statement, visa_type, National_ID_type, National_ID, visa_type_id, Minor_certificate, Minors_parents_visa, Minors_parents_passport,
                Health_Insurance, Proof_of_accomodation, Acceptance_letter_student, Financial_sustainability);
            res = vbl.VisaApplicantGERMANY(Vs);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPage2.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Register UnsucessFull')</script><script>windows.location.href='http://localhost:62241/VisaPage1.html'</script>");
            }
        }
        //France VISA Data
        else if (destination_country1 == "france")
        {
            string Bank_details = Request.Params["Bank_details"].ToString();
            string income_tax_return = Request.Params["income_tax_return"].ToString();
            string civil_status = Request.Params["civil_status"].ToString();
            string Accomodation = Request.Params["Accomodation"].ToString();
            Vs = new PassportBusinessObjects.VisaApplicant(VisaID, First_name,
                Middle_name, Last_name, Email_address, origin_country1, destination_country1, passportMain, DOB, gender, Address, Proof_Address,
                purpose, Bank_Statement, visa_type, National_ID_type, National_ID, visa_type_id, Minor_certificate, Minors_parents_visa, Minors_parents_passport,
                Bank_details, income_tax_return, civil_status, Accomodation);
            res = vbl.VisaApplicantFrance(Vs);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPage2.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Register UnsucessFull')</script><script>windows.location.href='http://localhost:62241/VisaPage1.html'</script>");
            }
        }
        //India VISA Data
        else if (destination_country1 == "india")
        {
            string HealthInsurance = Request.Params["HealthInsurance"].ToString();
            string proof_accomodation = Request.Params["proof_accomodation"].ToString();
            string Acceptance_letter = Request.Params["Acceptance_letter"].ToString();
            string financial_status = Request.Params["financial_status"].ToString();
            Vs = new PassportBusinessObjects.VisaApplicant(VisaID, First_name,
                Middle_name, Last_name, Email_address, origin_country1, destination_country1, passportMain, DOB, gender, Address, Proof_Address,
                purpose, Bank_Statement, visa_type, National_ID_type, National_ID, visa_type_id, Minor_certificate, Minors_parents_visa, Minors_parents_passport,
                HealthInsurance, proof_accomodation, Acceptance_letter, financial_status);
            res = vbl.VisaApplicantIndia(Vs);
            if (res > 0)
            {
                Response.Redirect("http://localhost:62241/VisaPage2.html?=" + VisaID);
            }
            else
            {
                Response.Write("<script>alert('Register UnsucessFull')</script><script>windows.location.href='http://localhost:62241/VisaPage1.html'</script>");
            }

        }
            

        }
    }
