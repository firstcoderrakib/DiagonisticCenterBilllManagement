using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagonisticHospitalManagement.Model;
namespace DiagonisticHospitalManagement.DAL
{
    public class TestRequestGetway
    {
        string Connection = WebConfigurationManager.ConnectionStrings["HospitalDBConnectionString"].ConnectionString;
        public virtual int AddTestRequest(TestRequests testRequest)
        {
            SqlConnection connection = new SqlConnection(Connection);

            string query = "INSERT INTO TestRequestNo VALUES(@PatientID,@TestID)";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", testRequest.patientID);
            command.Parameters.AddWithValue("@TestID", testRequest.TestID);
          
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        public virtual List<TestRequests> GetAllTestRequest()
        {

            SqlConnection connection = new SqlConnection(Connection);

            string query = "SELECT *FROM TestRequestNo";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<TestRequests> TestRequestList = new List<TestRequests>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int patientId = (int)reader["PatientID"];
                    int testID = (int)reader["TestID"];
                    TestRequests TestRequest = new TestRequests(patientId, testID);

                    TestRequestList.Add(TestRequest);
                }
                reader.Close();
            }
            connection.Close();
            return TestRequestList;
        }
    }
}