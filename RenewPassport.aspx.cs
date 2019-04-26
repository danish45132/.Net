using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassportBusinessLayer;
using PassportDataLayer;
using System.Data;

public partial class RenewPassport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string PassportNumber = Request.Params["passport_number"].ToString();
        string Name = Request.Params["name"].ToString();
        string Months = Request.Params["months"].ToString();
        string Year = Request.Params["year"].ToString();

        PassportBusinessLayer.PassportBL pbl = new PassportBusinessLayer.PassportBL();
        DataTable dt = pbl.PassPortDetails(PassportNumber, Name);
        string str = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j<dt.Columns.Count; j++)
            {
                str += dt.Rows[i][j].ToString()+",";
            }
        }
    }
}