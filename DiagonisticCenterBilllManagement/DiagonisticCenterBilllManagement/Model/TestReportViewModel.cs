using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticHospitalManagement.Model
{
    #region Class
    public class TestReportViewModel
    {
        #region Property
        public string TestName { get; set; }
        public int TotalTest { get; set; }

        public decimal TotalAmount { get; set; }

        #endregion
        #region Constructor
        public TestReportViewModel() { }

        public TestReportViewModel(string testName, int totalTest, decimal totalAmount)
        {
            this.TestName = testName;
            this.TotalTest = totalTest;
            this.TotalAmount = totalAmount;
        }
        #endregion
    }//cs
    #endregion
}//ns