using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassportBusinessLayer;
using PassportDataLayer;
using System.Data;

public partial class Application_full_deatils : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    [WebMethod]
    public static string ApplicantDetails(string ApplicationID)
    {
        PassportBusinessLayer.PassportBL pbl = new PassportBusinessLayer.PassportBL();
        DataTable dt = pbl.ApplicantDetails(ApplicationID);
        string applicantDetails = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                applicantDetails += dt.Rows[i][j].ToString() + ",";
            }
        }
        return applicantDetails;

    }
}