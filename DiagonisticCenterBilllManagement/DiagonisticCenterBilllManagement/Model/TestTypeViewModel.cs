using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticHospitalManagement.Model
{
    public class TestTypeViewModel
    {
        public string Test { get; set; }

        public decimal Fee { get; set; }

        public string Type { get; set; }

        public TestTypeViewModel() { }

        public TestTypeViewModel(string name,decimal fee,string type) {
            this.Test = name;
            this.Fee = fee;
            this.Type = type;
        
        }
    }
}