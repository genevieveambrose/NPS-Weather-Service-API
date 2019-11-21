using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Capstone.Web.Models.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Capstone.Web.DAO
{
    public class ApiWeatherDAO: IApiWeatherDAO
    {
        public APIWeatherVM GetCurrentWeatherZip(string zipCode)
        {
            APIWeatherVM vm = new APIWeatherVM();
            string json;

            using (var web = new WebClient())
            {
                var url = $"https://samples.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid=8bbed561c536bc5d41ca9cc0711fd113";
                json = web.DownloadString(url);
            }

            vm.apiWeather = JsonConvert.DeserializeObject<ApiWeather>(json);
            vm.coord = JObject.Parse(json)["coord"].ToObject<Coord>();
            vm.main = JObject.Parse(json)["main"].ToObject<Main>();
            vm.wind = JObject.Parse(json)["wind"].ToObject<Wind>();
            vm.clouds = JObject.Parse(json)["clouds"].ToObject<Clouds>();
            vm.sys = JObject.Parse(json)["sys"].ToObject<Sys>();
            vm.weather = JObject.Parse(json)["weather"][0].ToObject<Weather>();
            return vm;
        }

        public ApiWeather GetCurrentWeatherLatLong(string lat, string longi)
        {
            ApiWeather weather = new ApiWeather();
            string json;

            using (var web = new WebClient())
            {
                var url = $"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={longi}&units=imperial&appid=8bbed561c536bc5d41ca9cc0711fd113";
                json = web.DownloadString(url);
            }

            weather = JsonConvert.DeserializeObject<ApiWeather>(json);
            //vm.coord = JObject.Parse(json)["coord"].ToObject<Coord>();
            //vm.main = JObject.Parse(json)["main"].ToObject<Main>();
            //vm.wind = JObject.Parse(json)["wind"].ToObject<Wind>();
            //vm.clouds = JObject.Parse(json)["clouds"].ToObject<Clouds>();
            //vm.sys = JObject.Parse(json)["sys"].ToObject<Sys>();
            //vm.weather = JObject.Parse(json)["weather"][0].ToObject<Weather>();
            return weather;
        }
    }
}
