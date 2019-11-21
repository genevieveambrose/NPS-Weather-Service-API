using Capstone.Web.DAO;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests.DAL
{
    public class WeatherMockDAO : IWeatherDAO
    {
        private List<Forecast> forecasts = new List<Forecast>()
        {
            new Forecast(1, "CVNP", 1, 38, 62, "rain"),
            new Forecast(2, "CVNP", 2, 38, 56, "partly cloudy"),
            new Forecast(3, "CVNP", 3, 51, 66, "partly cloudy"),
            new Forecast(4, "CVNP", 4, 55, 65, "rain"),
            new Forecast(5, "CVNP", 5, 53, 69, "thunderstorms"),
        };

        public IList<Forecast> Get5DayForecast(string parkCode)
        {
            return new List<Forecast>(forecasts);
        }
    }
}
