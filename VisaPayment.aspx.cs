using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassportBusinessLayer;
using PassportDataLayer;
using PassportBusinessObjects;
using System.Data;
using System.Configuration;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Data.SqlClient;

public partial class VisaPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string VisaID = Request.Params["VisaID"].ToString();
        string Name = Request.Params["cc_name"].ToString();
        string CardNumber = Request.Params["Card_Number"].ToString();
        string amount = Request.Params["Amount"].ToString();
        long Card_Number = (long)Convert.ToDecimal(CardNumber);
        long Amount = (long)Convert.ToDecimal(amount);
        
        var strUniqueGuid = Guid.NewGuid().ToString();

        strUniqueGuid = strUniqueGuid.Substring(0, 16);
        string TransactionID = strUniqueGuid;
        PassportBusinessLayer.VisaBL vbl = new PassportBusinessLayer.VisaBL();
        DataTable dt = vbl.VisaApplicantDetails(CardNumber);
        string bal = dt.Rows[0][0].ToString();
        long balance = (long)Convert.ToDecimal(bal);
        PassportBusinessLayer.VisaBL vBl = new PassportBusinessLayer.VisaBL();
        DataTable Dt = vBl.VisaApplicantDetailsBYVisaID(VisaID);
        string str = "";
        for (int i = 0; i < Dt.Rows.Count; i++) 
        {
            for (int j = 0; j < Dt.Columns.Count; j++) 
            {
                str += Dt.Rows[i][j].ToString()+"&";
            }
        }
        string[] array = str.Split('&');
       // long Balance = long.Parse(array[0]);
        string name = array[0] + array[1] + array[2];
        string VisaType = array[3];
        string E_mail = array[4];
        string issue_Date = DateTime.Now.ToString("dd-MM-yyyy");
        DateTime IssueDate = DateTime.ParseExact(issue_Date, "dd-MM-yyyy", null);
        DateTime valid_date = DateTime.Now.AddMonths(6);
        string Val = valid_date.ToString("dd-MM-yyyy");
        DateTime ValidDate = DateTime.ParseExact(Val, "dd-MM-yyyy", null);
        if (balance >= Amount)
        {
            PassportBusinessLayer.VisaApplicantBL VBL = new PassportBusinessLayer.VisaApplicantBL();
            int res = VBL.VisaPayment(TransactionID, VisaID, CardNumber, Amount, balance, Name, VisaType, IssueDate, ValidDate, E_mail);
            if (res > 0)
            {
                Response.Write("<script>alert('Payment SucessFull')</script>");

                GridView2.DataSource = VBL.VisaApplicantDetailsFull(VisaID);
                GridView2.DataBind();
            }
                 
            else
            {
                Response.Write("<script>alert('Already Exist')</script>");
            }
        }
        else 
        {
            Response.Write("<script>alert('Payment UnSucessFull Due To Insufficient Balance')</script><script>windows.location.href='http://localhost:62241/demo/index.html'</script>");
        }
        //PassportBusinessLayer.VisaBL vbl = new PassportBusinessLayer.VisaBL();
        //int res = vbl.VisaPayment(VisaID, TransactionID, Card_Number, Amount);
        //if (res > 0) 
        //{
        //    Response.Write("<script>alert('Payment SucessFull')</script>");
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AppendHeader("content-disposition", "attachment;filename=Visa Details.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView2.AllowPaging = false;
        GridView2.DataBind();
        GridView2.RenderControl(hw);
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