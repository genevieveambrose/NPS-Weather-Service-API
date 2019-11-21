using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAO
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;
        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Park> GetAllParks()
        {
            try
            {
                IList<Park> parks = new List<Park>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT parkCode, parkName, parkDescription, state FROM park", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        parks.Add(new Park()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            ParkName = Convert.ToString(reader["parkName"]),
                            State = Convert.ToString(reader["state"]),
                            ParkDescription = Convert.ToString(reader["parkDescription"])
                        });
                         
                    }
                }

                return parks;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public Park GetParkDetail(string parkCode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM park WHERE parkCode = @parkCode", connection);
                    command.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    return new Park
                    {
                        ParkCode = Convert.ToString(reader["parkCode"]),
                        ParkName = Convert.ToString(reader["parkName"]),
                        State = Convert.ToString(reader["state"]),
                        Acreage = Convert.ToInt32(reader["acreage"]),
                        ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                        MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                        NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                        Climate = Convert.ToString(reader["climate"]),
                        YearFounded = Convert.ToInt32(reader["yearFounded"]),
                        AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                        InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                        InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                        ParkDescription = Convert.ToString(reader["parkDescription"]),
                        EntryFee = Convert.ToInt32(reader["entryFee"]),
                        NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
                    };

                }
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
