using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ForecastVM
    {
        public IList<Forecast> Forecasts { get; set; }
        public string ParkCode { get; set; }
        public string TempUnit { get; set; }
    }
}
