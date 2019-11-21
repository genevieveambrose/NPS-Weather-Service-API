using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAO;
using Capstone.Web.Models;
using Capstone.Web.Models.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class APIController : Controller
    {
        private IApiParkDAO apiDAO;
        private IApiWeatherDAO apiWeatherDAO;
        public APIController(IApiParkDAO apiDAO, IApiWeatherDAO apiWeatherDAO)
        {
            this.apiDAO = apiDAO;
            this.apiWeatherDAO = apiWeatherDAO;
        }

        public IActionResult Index()
        {
            ApiVM vm = new ApiVM();
            ViewData["States"] = states;
            return View(vm);
        }

        public IActionResult StateParks(string stateCode)
        {
            ApiVM vm = apiDAO.GetParkByStateCode(stateCode);
            return View(vm);
        }

        public IActionResult FeaturedParks()
        {
            ApiVM vm = apiDAO.GetFeaturedParks();
            return View(vm);
        }

        public IActionResult ParkDetail(string parkCode)
        {
            ApiVM vm = apiDAO.GetSpecificPark(parkCode);
            vm.WeatherObject = apiWeatherDAO.GetCurrentWeatherLatLong(vm.ParkData.latitude, vm.ParkData.longitude);

            return View(vm);
        }

        //For debugging
        //ApiVM vm = apiDAO.GetFeaturedParks();
        //ApiVM vmState = apiDAO.GetParkByStateCode("oh");
        //APIWeatherVM vmWeatherZip = apiWeatherDAO.GetCurrentWeatherZip("44125");
        //APIWeatherVM vmWeatherLatLong = apiWeatherDAO.GetCurrentWeatherLatLong("41", "81");

        private List<SelectListItem> states = new List<SelectListItem>()
        {
                 new SelectListItem() { Text = "Alabama", Value = "AL" },
                 new SelectListItem() { Text = "Alaska",  Value = "AK" },
                 new SelectListItem() { Text = "Arizona", Value = "AZ" },
                 new SelectListItem() { Text = "Arkansas", Value = "AR" },
                 new SelectListItem() { Text = "California", Value = "CA" },
                 new SelectListItem() { Text = "Colorado", Value = "CO" },
                 new SelectListItem() { Text = "Connecticut",  Value = "CT" },
                 new SelectListItem() { Text = "Delaware",  Value = "DE" },
                 new SelectListItem() { Text = "Florida", Value = "FL" },
                 new SelectListItem() { Text = "Georgia", Value = "GA" },
                 new SelectListItem() { Text = "Hawaii", Value = "HI" },
                 new SelectListItem() { Text = "Idaho", Value = "ID" },
                 new SelectListItem() { Text = "Illinois", Value = "IL" },
                 new SelectListItem() { Text = "Indiana", Value = "IN" },
                 new SelectListItem() { Text = "Iowa", Value = "IA" },
                 new SelectListItem() { Text = "Kansas", Value = "KS" },
                 new SelectListItem() { Text = "Kentucky", Value = "KY" },
                 new SelectListItem() { Text = "Louisiana", Value = "LA" },
                 new SelectListItem() { Text = "Maine",  Value = "ME"},
                 new SelectListItem() { Text = "Maryland", Value = "MD" },
                 new SelectListItem() { Text = "Massachusetts", Value = "MA" },
                 new SelectListItem() { Text = "Michigan", Value = "MI" },
                 new SelectListItem() { Text = "Minnesota", Value = "MN" },
                 new SelectListItem() { Text = "Mississippi", Value = "MS" },
                 new SelectListItem() { Text = "Missouri", Value = "MO" },
                 new SelectListItem() { Text = "Montana",  Value = "MT"},
                 new SelectListItem() { Text = "Nebraska",  Value = "NE" },
                 new SelectListItem() { Text = "Nevada", Value = "NV" },
                 new SelectListItem() { Text = "New Hampshire", Value = "NH" },
                 new SelectListItem() { Text = "New Jersey", Value = "NJ" },
                 new SelectListItem() { Text = "New Mexico", Value = "NM" },
                 new SelectListItem() { Text = "New York", Value = "NY" },
                 new SelectListItem() { Text = "North Carolina", Value = "NC" },
                 new SelectListItem() { Text = "North Dakota", Value = "ND" },
                 new SelectListItem() { Text = "Ohio", Value = "OH" },
                 new SelectListItem() { Text = "Oklahoma", Value = "OK" },
                 new SelectListItem() { Text = "Oregon", Value = "OR" },
                 new SelectListItem() { Text = "Pennsylvania", Value = "PA" },
                 new SelectListItem() { Text = "Rhode Island", Value = "RI" },
                 new SelectListItem() { Text = "South Carolina", Value = "SC" },
                 new SelectListItem() { Text = "South Dakota", Value = "SD" },
                 new SelectListItem() { Text = "Tennessee", Value = "TN" },
                 new SelectListItem() { Text = "Texas", Value = "TX" },
                 new SelectListItem() { Text = "Utah", Value = "UT" },
                 new SelectListItem() { Text = "Vermont", Value = "VT" },
                 new SelectListItem() { Text = "Virginia", Value = "VA" },
                 new SelectListItem() { Text = "Washington",  Value = "WA"},
                 new SelectListItem() { Text = "West Virginia", Value = "WV" },
                 new SelectListItem() { Text = "Wisconsin", Value = "WI" },
                 new SelectListItem() { Text = "Wyoming", Value = "WY" }

        };
    }
}