using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class Patient : System.Web.UI.Page
    {
        PatientManager patientManager = new PatientManager();
        TestManager testManager = new TestManager();
        TestRequestManager TestRequestManager = new TestRequestManager();
        List<Tests> testList = new List<Tests>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ShowTest();
            }
        }

        protected void Page_Render(object sender, EventArgs e)
        {


        }

        protected void btnTestRequst_Click(object sender, EventArgs e)
        {
            if (txtMobileNo.Text.Length != 11)
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = "Please Enter valid mobile No.";
                return;
            }
            else
            {
                messageLabel.Text = "";
                testList = (List<Tests>)ViewState["Test"];

                string name = txtPatientName.Text;
                DateTime dateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                int mobileNo = Convert.ToInt32(txtMobileNo.Text);
                HiddenField1.Value = patientManager.Get8Digits();
                string billNo = HiddenField1.Value;
                DateTime billDate = System.DateTime.Now;
                decimal totalFee = testList.Sum(x => x.testFee);
                decimal PaidBill = 0;

                Patients patient = new Patients(name, dateOfBirth, mobileNo, billNo, billDate, totalFee, PaidBill);

                try
                {

                    patientManager.AddPatient(patient);


                }
                catch (Exception exception)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = exception.Message;

                }
                int PatientId = patientManager.GetAllPatient().Max(x => x.ID);
                foreach (var test in testList)
                {
                    int patientID = PatientId;
                    int testID = test.ID;
                    PatientRequest testRequest = new PatientRequest(patientID, testID);
                    TestRequestManager.AddTestRequest(testRequest);

                }

                Generate_PDF();
            }

        }

        protected void btnTestAdd_Click(object sender, EventArgs e)
        {
            AddToGrid();
        }

        public void ShowTest()
        {
            var test = testManager.GetAllTest();
            ddlTestName.DataTextField = "tName";
            ddlTestName.DataValueField = "ID";
            ddlTestName.DataSource = test;
            ddlTestName.DataBind();
            ddlTestName.Items.Insert(0, "Select Test");
        }



        protected void ddlTestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTestName.SelectedIndex == 0)
            {
                txtFeeOfTest.Text = "";

            }
            else
            {
                var Value = Convert.ToInt32(ddlTestName.SelectedValue);
                decimal testFee = testManager.GetAllTest().Single(x => x.ID == Value).testFee;
                txtFeeOfTest.Text = testFee.ToString();
            }
        }

        public void AddToGrid()
        {

            if (ViewState["Test"] != null)
            {
                testList = (List<Tests>)ViewState["Test"];
            }
            Tests testReq = new Tests();
            testReq.tName = ddlTestName.SelectedItem.Text;
            testReq.ID = Convert.ToInt32(ddlTestName.SelectedValue);
            testReq.testFee = Convert.ToDecimal(txtFeeOfTest.Text);

            testList.Add(testReq);
            decimal total = 0;
            total = testList.Sum(x => x.testFee);
            txtTotalTestAmount.Text = total.ToString();
            ViewState["Test"] = testList;
            GridOfTestRequest.DataSource = testList;
            GridOfTestRequest.DataBind();
        }


        private void Generate_PDF()
        {

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();

            string name = txtPatientName.Text;
            string phone = txtMobileNo.Text;
            string dateTime = DateTime.Today.ToString();

            sb.Append("<table width = '100%' cellspacing='0' cellpadding ='2'>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0' colspan = '2'><b><h1>Unknown Diagnostic Center</h1></b></td></tr>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0' colspan = '2'><b>Address : 102/A , Rongdhonu towar,Mirpur-2, Dhaka-1216. </b></td></tr>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0' colspan = '2'><b>Contract No: 01732 349823 ,01932 349823,01532 349823</b></td></tr>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0;color:Blue;' colspan = '2'><b>Website: www.unknown.com</b></td></tr>");
            sb.Append("<tr><td align='center' colspan = '3' style='background-color: #18B5F0;color:Red;' colspan = '2'></br><b><h3></br></h3></b></td></tr>");
            sb.Append("<tr><td>Name : ");
            sb.Append(name);
            sb.Append("</td> ");
            sb.Append("<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </td");
            sb.Append("<td> Bill No : ");
            sb.Append(HiddenField1.Value);
            sb.Append("</td></tr>");

            sb.Append("<tr><td> Contract No : ");
            sb.Append(phone);
            sb.Append("</td> ");
            sb.Append("<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </td");
            sb.Append("<td> Date : ");
            sb.Append(dateTime);
            sb.Append("</td></tr></table>");

            GridOfTestRequest.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            StringReader sr1 = new StringReader(sb.ToString());
            sb1.Append("<table border = '1'>");
            sb1.Append("<tr><td align = 'right' colspan = '");
            sb1.Append(GridOfTestRequest.HeaderRow.Cells.Count - 1);
            sb1.Append("'>Total</td>");
            sb1.Append("<td>");
            sb1.Append(testList.Sum(x => x.testFee));
            sb1.Append("</td>");
            sb1.Append("</tr></table>");


            StringReader sr2 = new StringReader(sb1.ToString());
            testList.Clear();
            GridOfTestRequest.DataSource = null;
            GridOfTestRequest.DataBind();
            Document pdfDoc = new Document(PageSize.A5, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr1);
            htmlparser.Parse(sr);
            htmlparser.Parse(sr2);

            pdfDoc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=invoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Write(pdfDoc);

            Response.Flush();
            Response.ClearContent();
            Response.Clear();
            Response.Cookies.Clear();
            HttpContext.Current.ApplicationInstance.CompleteRequest();




        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //Clear();
        }
        private void Clear()
        {
            txtPatientName.Text = "";
            txtMobileNo.Text = "";
            txtDateOfBirth.Text = "";
            txtFeeOfTest.Text = "";
            txtTotalTestAmount.Text = "";
            ddlTestName.SelectedIndex = 0;
            GridOfTestRequest.DataSource = null;
            GridOfTestRequest.DataBind();
            testList.Clear();
            ViewState["Test"] = null;

        }

        protected void Application_End(object sender, EventArgs e)
        {
            Clear();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Clear();
        }
    }
}