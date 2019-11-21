using Capstone.Web.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ApiVM
    {
        public ApiPark Park { get; set; }
        public ParkArray ParkData { get; set; }
        public Entrancefee EntranceFee { get; set; }
        public Image Image { get; set; }

        public ApiWeather WeatherObject { get; set; }

        public List<ParkArray> Parks { get; set; }
        public List<Entrancefee> EntranceFees { get; set; }
        public List<Image> Images { get; set; }

        public string StateCode { get; set; }

    }
}
