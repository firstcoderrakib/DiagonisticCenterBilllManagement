using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticCenterBilllManagement.Model;
namespace DiagonisticCenterBilllManagement.Model
{
    [Serializable]

    public class Tests
    {
        public int ID { get; set; }
        public string tName { get; set; }
        public decimal testFee { get; set; }
        public Nullable<int> typeID { get; set; }
        public Tests()
        {

        }
        public Tests(string tName, decimal testFee, int typeId)
        {
            this.tName = tName;
            this.testFee = testFee;
            this.typeID = typeId;
        }

    }
}