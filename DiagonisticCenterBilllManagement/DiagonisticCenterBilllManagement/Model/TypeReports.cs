using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBilllManagement.Model
{
    public class TypeReports
    {
        public string TypeName { get; set; }

        public int TotalTest { get; set; }

        public decimal TotalAmount { get; set; }

        public TypeReports()
        {
            
        }

        public TypeReports(string typeName,int totalTest,decimal totalAmount)
        {
            this.TypeName = typeName;
            this.TotalTest = totalTest;
            this.TotalAmount = totalAmount;
        }

    }
}