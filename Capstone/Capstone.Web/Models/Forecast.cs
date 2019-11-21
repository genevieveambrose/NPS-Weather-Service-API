using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Forecast
    {
        public Forecast()
        {

        }

        public Forecast(int id, string parkCode, int fiveDayForecastValue, int low, int high, string dailyForecast)
        {
            this.Id = id;
            this.ParkCode = ParkCode;
            this.FiveDayForecastValue = fiveDayForecastValue;
            this.Low = low;
            this.High = high;
            this.DailyForecast = dailyForecast;
        }

        public int Id { get; set; }
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string DailyForecast { get; set; }
        public string ParkName { get; set; }

        public double LowCelsius
        {
            get
            {
                return Math.Round((Low - 32) * (5.0 / 9.0));
            }
        }

        public double HighCelsius
        {
            get
            {
                return Math.Round((High - 32) * (5.0 / 9.0));
            }
        }

        public int TempDifference
        {
            get
            {
                return High - Low;
            }
        }
    }
}
