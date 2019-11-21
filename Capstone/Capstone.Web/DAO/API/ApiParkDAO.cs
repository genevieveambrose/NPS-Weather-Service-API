using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Capstone.Web.DAO
{
    public class ApiParkDAO : IApiParkDAO
    {
        public ApiVM GetFeaturedParks()
        {
            ApiVM vm = new ApiVM();
            vm.Parks = new List<ParkArray>();
            vm.EntranceFees = new List<Entrancefee>();
            vm.Images = new List<Image>();

            string json;

            using (var web = new WebClient())
            {
                var url = $"https://developer.nps.gov/api/v1/parks?parkCode=cuva,ever,grca,glac,grsm,grte,mora,romo,yell,yose&fields=images,entranceFees&api_key=3LhuGLctiucHmnyRqehk6AgUF4jFY5NlnLVJHtK3";
                json = web.DownloadString(url);
            }

             for(int i = 0; i < 10; i++)
            {
                ParkArray park = JObject.Parse(json)["data"][i].ToObject<ParkArray>();
                vm.Parks.Add(park);
                Entrancefee entrancefee = JObject.Parse(json)["data"][i]["entranceFees"][0].ToObject<Entrancefee>();
                vm.EntranceFees.Add(entrancefee);
                for (int j = 0; j < 4; j++)
                {
                    Image image = JObject.Parse(json)["data"][i]["images"][j].ToObject<Image>();
                    vm.Images.Add(image);
                }

            }
            return vm;
        }

        public ApiVM GetParkByStateCode(string stateCode)
        {
            ApiVM vm = new ApiVM();
            vm.Parks = new List<ParkArray>();
            vm.EntranceFees = new List<Entrancefee>();
            vm.Images = new List<Image>();

            string json;

            using (var web = new WebClient())
            {
                var url = $"https://developer.nps.gov/api/v1/parks?stateCode={stateCode}&fields=images,entranceFees&api_key=3LhuGLctiucHmnyRqehk6AgUF4jFY5NlnLVJHtK3";
                json = web.DownloadString(url);
            }

            var test = JObject.Parse(json);
            JArray items = (JArray)test["data"];
            int length = items.Count;

            for (int i = 0; i < length; i++)
            {
                ParkArray park = JObject.Parse(json)["data"][i].ToObject<ParkArray>();
                vm.Parks.Add(park);
                for (int k = 0; k < Math.Min(1, park.entranceFees.Length); k++)
                {
                    Entrancefee entrancefee = park.entranceFees[0];
                    vm.EntranceFees.Add(entrancefee);
                }
                for (int j = 0; j < Math.Min(4, park.images.Length); j++)
                {
                    Image image = park.images[j];
                    vm.Images.Add(image);
                }
            }
            return vm;
        }

        public ApiVM GetSpecificPark(string parkCode)
        {
            ApiVM vm = new ApiVM();
            string json;
            vm.Images = new List<Image>();

            using (var web = new WebClient())
            {
                var url = $"https://developer.nps.gov/api/v1/parks?parkCode={parkCode}&fields=images,entranceFees&api_key=3LhuGLctiucHmnyRqehk6AgUF4jFY5NlnLVJHtK3";
                json = web.DownloadString(url);
            }

            vm.Park = JsonConvert.DeserializeObject<ApiPark>(json);
            vm.ParkData = JObject.Parse(json)["data"][0].ToObject<ParkArray>();
            if (vm.ParkData.entranceFees.Length > 0)
            {
                vm.EntranceFee = JObject.Parse(json)["data"][0]["entranceFees"][0].ToObject<Entrancefee>();
            }
            //else
            //{
            //    vm.EntranceFee.title = "None";
            //    vm.EntranceFee.cost = "0.00";
            //    vm.EntranceFee.description = "This park has no entrance fee!";
            //}

            for (int j = 0; j < Math.Min(4, vm.ParkData.images.Length); j++)
            {
                Image image = JObject.Parse(json)["data"][0]["images"][j].ToObject<Image>();
                vm.Images.Add(image);
            }

            return vm;
        }
    }
}
