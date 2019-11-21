using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAO
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private string connectionString;
        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IList<Forecast> Get5DayForecast(string parkCode)
        {
            try
            {
                IList<Forecast> forecasts = new List<Forecast>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM weather JOIN park ON park.parkCode = weather.parkCode WHERE park.parkCode = @parkCode", connection);
                    command.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        forecasts.Add(new Forecast()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            Low = Convert.ToInt32(reader["low"]),
                            High = Convert.ToInt32(reader["high"]),
                            ParkName = Convert.ToString(reader["parkName"]),
                            DailyForecast = Convert.ToString(reader["forecast"])
                        });
                    }
                }
                return forecasts;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
