using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAO
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private string connectionString;
        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddSurvey(SurveyPost surveypost)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel)", connection);
                    command.Parameters.AddWithValue("@parkCode", surveypost.ParkCode);
                    command.Parameters.AddWithValue("@emailAddress", surveypost.EmailAddress);
                    command.Parameters.AddWithValue("@state", surveypost.State);
                    command.Parameters.AddWithValue("@activityLevel", surveypost.ActivityLevel);
                    command.ExecuteNonQuery();
                }
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public IList<SurveyPost> GetAllSurveys()
        {
            try
            {
                IList<SurveyPost> surveyposts = new List<SurveyPost>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select COUNT(sr.parkCode) as count, p.parkName, p.parkCode from survey_result sr JOIN park p ON p.parkCode = sr.parkCode GROUP BY p.parkName, p.parkCode ORDER BY count DESC", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        surveyposts.Add(new SurveyPost()
                        {
                            SurveyCount = Convert.ToInt32(reader["count"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            ParkName = Convert.ToString(reader["parkName"])
                        });

                    }
                }

                return surveyposts;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
