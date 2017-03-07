using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagonisticCenterBilllManagement.BLL;
using DiagonisticCenterBilllManagement.Model;

namespace DiagonisticCenterBilllManagement.UI
{
    public partial class TestReport : System.Web.UI.Page
    {
        TestManager testManager = new TestManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowTest_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);

            List<TestReports> TestReport = testManager.GetReportByTestName(fromDate, toDate);

            GridViewTestShow.DataSource = TestReport.ToList();
            GridViewTestShow.DataBind();

            decimal sumOfAmount = 0;
            foreach (var test in TestReport)
            {
                sumOfAmount += test.TotalAmount;
            }
            HiddenField1.Value = sumOfAmount.ToString();
            txtTestTotal.Text = HiddenField1.Value;
            Clear();
        }

        private void Clear()
        {
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }

        protected void btnPDFShow_Click(object sender, EventArgs e)
        {
           
            ExportGridToPDF();
           
           
        }



        private void ExportGridToPDF()
        {



            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            sb.Append("<table width = '100%' cellspacing='0' cellpadding ='2'>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0' colspan = '2'><b><h1>Unknown Diagnostic Center</h1></b></td></tr>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0' colspan = '2'><b>Address : 102/A , Rongdhonu towar,Mirpur-2, Dhaka-1216. </b></td></tr>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0' colspan = '2'><b>Contract No: 01732 349823 ,01932 349823,01532 349823</b></td></tr>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0;color:Blue;' colspan = '2'><b>Website: www.unknown.com</b></td></tr>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0;color:Red;' colspan = '2'></br><b><h3>Test Wise Bill Riport</h3></b></td></tr></table>");

            GridViewTestShow.RenderControl(hw);
            sb1.Append("<table border = '1'>");
            sb1.Append("<tr><td align = 'right' colspan = '");
            sb1.Append(GridViewTestShow.HeaderRow.Cells.Count - 1);
            sb1.Append("'>Total</td>");
            sb1.Append("<td>");
            sb1.Append(HiddenField1.Value);
            sb1.Append("</td>");
            sb1.Append("</tr></table>");


            StringReader sr2 = new StringReader(sb1.ToString());
            StringReader sr1 = new StringReader(sb.ToString());
            StringReader sr = new StringReader(sw.ToString());

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr1);
            htmlparser.Parse(sr);
            htmlparser.Parse(sr2);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestWiseBillReport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.Flush();

            Response.Clear();
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }



    }

}
