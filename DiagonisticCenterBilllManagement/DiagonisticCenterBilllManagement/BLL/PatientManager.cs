using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using DiagonisticCenterBilllManagement.DAL;
using DiagonisticCenterBilllManagement.Model;

namespace DiagonisticCenterBilllManagement.BLL
{
    public class PatientManager:PatientGetway
    {
        PatientGetway patientGetway = new PatientGetway();
        

        public override int AddPatient(Patients patient)
        {
            if (IsBillNoExist(patient.BillNo))
                {
                    throw new Exception("Bill no already exist");
                }
            
            return base.AddPatient(patient);
        }
      
        public override List<Payments> GetPatientDetails(string billNo)
        {
            if (IsBillNoExist(billNo))
            {
                return base.GetPatientDetails(billNo);

            }

            throw new Exception("Bill no is not exist");
        }
        public string GetPatientUpdateBill(string billNo, decimal PaidBill)
        {
           Patients patient= patientGetway.GetPatientByBillNo(billNo);

            if(patient.TotalFee==patient.PaidBill && PaidBill>=patient.TotalFee)
            {
               return "Paid";
            }
            else if (patient.TotalFee == PaidBill || (patient.TotalFee - patient.PaidBill) == PaidBill)
            {
                return patient.TotalFee.ToString();
            }

            else if (PaidBill > patient.TotalFee || PaidBill > patient.PaidBill)
            {
                return " Please see due amount.";
            }
            else if (patient.TotalFee == patient.PaidBill && PaidBill < patient.PaidBill)
            {
                return "Paid";
            }
            
            else
            {
              return  (patient.PaidBill).ToString();
            }
        }

        public string GetPatientDueBill(string billNo, decimal PaidBill)
        {
            Patients patient = patientGetway.GetPatientByBillNo(billNo);

         
            if ((patient.TotalFee - patient.PaidBill) == 0 && PaidBill > patient.TotalFee)
            {
                return "0.0000";
            }
            else if (PaidBill > patient.TotalFee)
            {
                return patient.TotalFee.ToString();
            }
                else if(PaidBill>(patient.TotalFee-patient.PaidBill))
            {
                return (patient.TotalFee - patient.PaidBill).ToString();
            }

            else if ((patient.TotalFee - patient.PaidBill) == 0)
            {
                return "0.0000";
            }
            else if (patient.TotalFee == PaidBill || (patient.TotalFee - patient.PaidBill) == PaidBill)
            {
                return "0.0000";
            }
            else
            {
                return  (patient.TotalFee- patient.PaidBill).ToString();
            }
        }
        public bool IsBillNoExist(string billNo)
        {
            bool isBillNoExist = false;
            Patients patient = GetPatientByBillNo(billNo);
            if (patient != null)
            {
                isBillNoExist = true;
            }
            return isBillNoExist;

        }
        public string Get8Digits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 10000;
            return String.Format("{0:D4}", random);
        }
    }
}