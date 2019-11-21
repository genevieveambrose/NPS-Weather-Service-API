using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAO;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {
        private string tempChoice = "Choice";

        private IWeatherDAO weatherDAO;
        private IParkDAO parkDAO;
        public ParkController(IWeatherDAO weatherDAO, IParkDAO parkDAO)
        {
            this.weatherDAO = weatherDAO;
            this.parkDAO = parkDAO;
        }

        public IActionResult Index()
        {
            
            IList<Park> parks = parkDAO.GetAllParks();
            return View(parks);
        }

        public IActionResult ParkDetail(string parkCode)
        {
            Park park = parkDAO.GetParkDetail(parkCode);
            return View(park);
        }

        public IActionResult SaveTempPref(string tempUnit, string parkCode)
        {
            HttpContext.Session.SetString(tempChoice, tempUnit);
            string s = HttpContext.Session.GetString(tempChoice);
            ViewData["TempPref"] = s;
            return RedirectToAction("ParkForecast", new { @parkCode = parkCode });
        }

        public IActionResult ParkForecast(string parkCode)
        {
            string s = HttpContext.Session.GetString(tempChoice);
            ViewData["TempPref"] = s;
            ForecastVM forecastVM = new ForecastVM();
            forecastVM.ParkCode = parkCode;
            forecastVM.Forecasts = weatherDAO.Get5DayForecast(parkCode);
            return View(forecastVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
