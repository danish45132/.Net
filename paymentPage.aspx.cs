using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassportBusinessLayer;
using PassportDataLayer;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Configuration;

public partial class paymentPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ApplicationID = Request.Params["ApplicationID"].ToString();
        string CardNumber = Request.Params["Card_Number"].ToString();
        PassportBusinessLayer.PassportBL pbl = new PassportBusinessLayer.PassportBL();
        DataTable dt = pbl.Payment(CardNumber, ApplicationID);
        
        string s = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                s += dt.Rows[i][j].ToString() + ",";
            }
        }
        if (s != "")
        {
            string[] array = s.Split(',');
            string bal = array[2].ToString();
            long Balance = (long)Convert.ToDecimal(bal);
            if (Balance>=1500)
            {
                PassportBusinessLayer.PassportBL PBL = new PassportBusinessLayer.PassportBL();
                DataTable Dt = PBL.PassportName(ApplicationID);
                string str = "";
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    for (int j = 0; j < Dt.Columns.Count; j++) 
                    {
                        str += Dt.Rows[i][j].ToString();
                    }
                }
                
                Random random = new Random();
                long pass = 0;
                for (int i = 0; i < 12; i++)
                {
                    pass += (long)(Math.Pow(10, i) * random.Next(1, 10));
                }
                string PassportNumber = pass.ToString();
                string issue_Date = DateTime.Now.ToString("dd-MM-yyyy");
                DateTime IssueDate = DateTime.ParseExact(issue_Date, "dd-MM-yyyy", null);
                DateTime valid_date = DateTime.Now.AddYears(10);
                string Val = valid_date.ToString("dd-MM-yyyy");
                DateTime ValidDate = DateTime.ParseExact(Val, "dd-MM-yyyy", null);
                //int result = 
                PassportBusinessLayer.PassportBL pBl = new PassportBusinessLayer.PassportBL();
                int result = pBl.PassPortDetailsEntry(PassportNumber, IssueDate, ValidDate, str, ApplicationID);
                int res = paymentPage.PayMentEntry(ApplicationID, CardNumber, Balance);
                if (res > 0 && result>0)
                {
                    Response.Write("<script>alert('Payment SucessFull')</script>");
                    //Console.Write(result);
                }
                Gridview1.DataSource = pBl.PassportDetails(ApplicationID);
                Gridview1.DataBind();
            }
        }
        else 
        {
            Response.Write("<script>alert('Payment UnSucessFull Due To Insufficient Balance')</script>");
        }
    }
    //[WebMethod]
    //public static void Payment(string CardNumber,string ApplicationID)
    //{
    //    PassportBusinessLayer.PassportBL pbl = new PassportBusinessLayer.PassportBL();
    //    DataTable dt = pbl.Payment(CardNumber, ApplicationID);
    //    string s = "";
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        for (int j = 0; j < dt.Columns.Count; j++) 
    //        {
    //            s += dt.Rows[i][j].ToString()+",";
    //        }
    //    }
    //    string[] array = s.Split(',');
    //    long Balance = long.Parse(array[3]); 
    //    if (Balance!=0) 
    //    {
            
    //        int res = paymentPage.PayMentEntry(ApplicationID,CardNumber,Balance);
    //        if (res > 0) 
    //        {
    //            string result = "<script>alert('Payment SucessFull')</script>";
    //            Console.Write(result);
    //        }
    //    }
    //    //return s;
    //}
    public static int PayMentEntry(string ApplicationID, string CardNumber,long Balance)
    {
        PassportBusinessLayer.PassportBL pbl = new PassportBusinessLayer.PassportBL();
        int res = pbl.PassportPayMentEntry(ApplicationID, CardNumber, Balance);
        return res;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AppendHeader("content-disposition", "attachment;filename=Passport Details.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        Gridview1.AllowPaging = false;
        Gridview1.DataBind();
        Gridview1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 7f, 7f, 7f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);

        Response.End();
    }
}