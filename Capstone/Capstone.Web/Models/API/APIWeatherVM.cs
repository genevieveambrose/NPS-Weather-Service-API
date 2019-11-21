using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models.API
{
    public class APIWeatherVM
    {
        public ApiWeather apiWeather { get; set; }
        public Coord coord { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public Sys sys { get; set; }
        public Weather weather { get; set; }

    }
}
