using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassportBusinessLayer;
using System.Data;
using System.Web.Services;
using PassportBusinessObjects;
using PassportBusinessLayer;

public partial class passportSatetDistrictRpo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string RpoState = Request.Params["State_Selection"].ToString();
        string District_Rpo = Request.Params["District_Rpo"].ToString();
        string ApplicationID = Request.Params["ApplicationID"].ToString();
        string Rpo = Request.Params["Rpo"].ToString();
        string Date = Request.Params["AppointmentDate"].ToString();
        string aD = Convert.ToDateTime(Date).ToString("dd-MM-yyyy");
        DateTime AppointmnetDate = DateTime.ParseExact(aD, "dd-MM-yyyy", null);

        PassportBusinessObjects.PassportRpo Prpo = new PassportRpo(RpoState, District_Rpo, Rpo, AppointmnetDate, ApplicationID);
        PassportBusinessLayer.PassportBL pbl = new PassportBusinessLayer.PassportBL();
        int res = pbl.RpoEntry(Prpo);
        if (res > 0)
        {
            Response.Redirect("http://localhost:62241/Applicant_full_details.html?=" + ApplicationID);
        } 
    }
    [WebMethod]
    public static string SelectDistrict(string stateID)
    {
        PassportBusinessLayer.PassportBL pbl = new PassportBusinessLayer.PassportBL();
        DataTable dt = pbl.SelectDistrict(stateID);
        string s = "";
        for (int i = 0; i<dt.Rows.Count; i++)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                s += dt.Rows[i][j].ToString()+",";
            }
        }
            return s;
        
        
    }
    [WebMethod]
    public static string SelectRpo(string stateID)
    {
        PassportBusinessLayer.PassportBL pbl = new PassportBusinessLayer.PassportBL();
        DataTable dt = pbl.SelectRpo(stateID);
        string Rpo = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                Rpo += dt.Rows[i][j].ToString() + ",";
            }
        }
        return Rpo;
    }
}