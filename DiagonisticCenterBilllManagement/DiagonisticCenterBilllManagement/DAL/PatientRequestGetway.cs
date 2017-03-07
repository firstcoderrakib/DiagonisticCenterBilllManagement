using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagonisticCenterBilllManagement.Model;

namespace DiagonisticCenterBilllManagement.DAL
{
    public class PatientRequestGetway
    {
        string Connection = WebConfigurationManager.ConnectionStrings["DCMDBConnectionString"].ConnectionString;
        public virtual int AddTestRequest(PatientRequest testRequest)
        {
            SqlConnection connection = new SqlConnection(Connection);

            string query = "INSERT INTO [PatientRequestTest] VALUES(@PatientID,@TestID)";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", testRequest.patientID);
            command.Parameters.AddWithValue("@TestID", testRequest.TestID);
          
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        public virtual List<PatientRequest> GetAllTestRequest()
        {

            SqlConnection connection = new SqlConnection(Connection);

            string query = "SELECT *FROM [PatientRequestTest]";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<PatientRequest> TestRequestList = new List<PatientRequest>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int patientId = (int)reader["PatientID"];
                    int testID = (int)reader["TestID"];
                    PatientRequest TestRequest = new PatientRequest(patientId, testID);

                    TestRequestList.Add(TestRequest);
                }
                reader.Close();
            }
            connection.Close();
            return TestRequestList;
        }
    }
}