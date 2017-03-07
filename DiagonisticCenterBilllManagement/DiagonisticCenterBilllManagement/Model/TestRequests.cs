using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticHospitalManagement.Model;

namespace DiagonisticHospitalManagement.Model
{
    #region Class
    public class TestRequests
    {
        #region Property
        public int ID { get; set; }
        public Nullable<int> patientID { get; set; }
        public Nullable<int> TestID { get; set; }

        #endregion
        #region Constructor
        public TestRequests() { }
        public TestRequests(int patientID,int testID)
        {
            this.patientID = patientID;
            this.TestID = testID;
        }
        #endregion

    }//cs
    #endregion
}//ns