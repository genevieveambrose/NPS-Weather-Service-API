using Capstone.Web.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAO
{
    public interface IApiWeatherDAO
    {
        ApiWeather GetCurrentWeatherLatLong(string lat, string longitude);
        APIWeatherVM GetCurrentWeatherZip(string zipCode);
    }
}
