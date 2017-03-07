using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticCenterBilllManagement.Model;

namespace DiagonisticCenterBilllManagement.Model
{
    public class PatientRequest
    {
        public int ID { get; set; }
        public Nullable<int> patientID { get; set; }
        public Nullable<int> TestID { get; set; }

        public PatientRequest()
        {
            
        }
        public PatientRequest(int patientID,int testID)
        {
            this.patientID = patientID;
            this.TestID = testID;
        }

    }
}