using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagonisticCenterBilllManagement.BLL;
using DiagonisticCenterBilllManagement.Model;

namespace DiagonisticCenterBilllManagement.UI
{
    public partial class Payment : System.Web.UI.Page
    {
        PatientManager patientManager = new PatientManager();
        TestRequestManager testRequest = new TestRequestManager();
        TestManager testManager = new TestManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowPayment();
        }

        protected void paySave_Click(object sender, EventArgs e)
        {
            Patients patient = new Patients(); 
            patient.BillNo = HiddenFieldBillNo.Value;
            decimal Amount;
            bool IsExistsAmount = decimal.TryParse(txtAmount.Text, out Amount);
            if (IsExistsAmount)
            {
                if (Amount >= 0)
                {
                    lblPaymentMsg.Visible = false;
                    patient.PaidBill = Amount;


                }

                else
                {
                    lblPaymentMsg.Text = "Amount must be greater than or equal 0";
                    lblPaymentMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            
            patientManager.GetPatientUpdate(patient);
            lblPaid.Text = patientManager.GetPatientUpdateBill(patient.BillNo, Convert.ToDecimal(patient.PaidBill));
            lblDue.Text = patientManager.GetPatientDueBill(patient.BillNo, Convert.ToDecimal(patient.PaidBill));
            
        }

        public void ShowPayment()
        {
            try
            {
                Label1.Visible = false;
                List<Payments> PatientdetailsList = patientManager.GetPatientDetails(txtBillNoSearch.Text);
                PaymentGridView.DataSource = PatientdetailsList.ToList();
                PaymentGridView.DataBind();

                foreach (var item in PatientdetailsList)
                {
                    HiddenFieldBillNo.Value = item.BillNo.ToString();
                    lblBillDate.Text = item.BillDate.ToString();
                    lblTotalFee.Text = item.TotalFee.ToString();
                    lblPaid.Text = item.PaidBill.ToString();
                    lblDue.Text = (item.TotalFee - item.PaidBill).ToString();
                }
            }
           catch(Exception ex)
            {
                Label1.Visible = true;
              Label1.Text=  ex.Message;
              Label1.ForeColor = System.Drawing.Color.Red;
            }

           



        }

       

       
    }
}