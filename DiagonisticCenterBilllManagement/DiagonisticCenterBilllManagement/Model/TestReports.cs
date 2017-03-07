using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBilllManagement.Model
{
    public class TestReports
    {
        public string TestName { get; set; }
        public int TotalTest { get; set; }

        public decimal TotalAmount { get; set; }

        public TestReports()
        {
            
        }

        public TestReports(string testName, int totalTest, decimal totalAmount)
        {
            this.TestName = testName;
            this.TotalTest = totalTest;
            this.TotalAmount = totalAmount;
        }
    }
}