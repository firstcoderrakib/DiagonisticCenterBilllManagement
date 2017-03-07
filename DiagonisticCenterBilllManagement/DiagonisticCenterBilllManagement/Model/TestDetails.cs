using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBilllManagement.Model
{
    public class TestDetails
    {
        public string Test { get; set; }

        public decimal Fee { get; set; }

        public string Type { get; set; }

        public TestDetails() { }

        public TestDetails(string name,decimal fee,string type) {
            this.Test = name;
            this.Fee = fee;
            this.Type = type;
        
        }
    }
}