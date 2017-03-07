using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBilllManagement.Model
{
    public class Patients
    {
        public int ID { get; set; }
        public string patientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int MobileNO { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public decimal TotalFee { get; set; }
        public decimal PaidBill { get; set; }

        public Patients()
        {
            
        }
        public Patients(string name, DateTime Dob, int mobileNo, string billNo
            , DateTime billDate, decimal totalFee, decimal paidBill)
        {
            this.patientName = name;
            this.DateOfBirth = Dob;
            this.MobileNO = mobileNo;
            this.BillNo = billNo;
            this.BillDate = billDate;
            this.TotalFee = totalFee;
            this.PaidBill = paidBill;
        }
    }
}