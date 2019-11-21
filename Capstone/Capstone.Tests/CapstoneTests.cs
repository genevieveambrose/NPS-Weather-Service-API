using Capstone.Tests.DAL;
using Capstone.Web.Controllers;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Capstone.Tests
{
    [TestClass]
    public class CapstoneTests
    {

        [TestMethod]
        public void TestAddSurvey()
        {
            // Arrange
            SurveyMockDAO surveyDAO = new SurveyMockDAO();
            ParkMockDAO parkDAO = new ParkMockDAO();
            SurveyController controller = new SurveyController(surveyDAO, parkDAO);

            // Act
            SurveyPost survey = new SurveyPost();
            bool result = surveyDAO.AddSurvey(survey);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetAllSurveys()
        {
            // Arrange
            SurveyMockDAO surveyDAO = new SurveyMockDAO();
            ParkMockDAO parkDAO = new ParkMockDAO();
            SurveyController controller = new SurveyController(surveyDAO, parkDAO);

            // Act
            SurveyVM vm = new SurveyVM();
            IActionResult result = controller.FavoriteParks();
            ViewResult vr = result as ViewResult;
            IList<SurveyPost> surveys = surveyDAO.GetAllSurveys();
            surveys = vr.Model as IList<SurveyPost>;

            // Assert
            Assert.IsNotNull(vr, "Index did not return a ViewResult");
            Assert.AreEqual(4, surveys.Count);
            Assert.IsInstanceOfType(vr.Model, typeof(IList<SurveyPost>));
        }

        [TestMethod]
        public void TestGetParkDetail()
        {
            //Arrange 
            ParkMockDAO parkDAO = new ParkMockDAO();
            WeatherMockDAO weatherDAO = new WeatherMockDAO();
            ParkController controller = new ParkController(weatherDAO, parkDAO);

            //Act
            Park park = parkDAO.GetParkDetail("CVNP");
            IActionResult result = controller.ParkDetail("CVNP");

            //Assert
            ViewResult vr = result as ViewResult;
            Assert.IsNotNull(vr);

            Assert.AreEqual("CVNP", park.ParkCode);
            Assert.AreEqual("Ohio", park.State);
            Assert.AreEqual("Woodland", park.Climate);
        }


        [TestMethod]
        public void TestGetAllParks()
        {
            //Arrange 
            ParkMockDAO parkDAO = new ParkMockDAO();
            WeatherMockDAO weatherDAO = new WeatherMockDAO();
            ParkController controller = new ParkController(weatherDAO, parkDAO);

            //Act
            IList<Park> parks = parkDAO.GetAllParks();

            //Assert
            Assert.AreEqual(parks.Count, 5, "Testing the number of Parks returned");
        }

 //Could not test controller with HttpSession, got permission from Mike to leave it alone

        //[TestMethod]
        //public void TestWeatherSearch()
        //{
        //    // Arrange
        //    WeatherMockDAO weatherDAO = new WeatherMockDAO();
        //    ParkMockDAO parkDAO = new ParkMockDAO();
        //    ParkController controller = new ParkController(weatherDAO, parkDAO);

        //    // Act
        //    ForecastVM vm = new ForecastVM()
        //    {
        //        ParkCode = "CVNP"
        //    };
        //    //HttpContext.Session.GetString("Choice");
        //    IActionResult result = controller.ParkForecast(vm.ParkCode);

        //    // Assert
        //    ViewResult vr = result as ViewResult;
        //    Assert.IsNotNull(vr, "Index did not return a ViewResult");

        //    vm.Forecasts = vr.Model as List<Forecast>;
        //    Assert.IsNotNull(vm.Forecasts, "Viewresult.Model is not a valid IList");
        //    Assert.AreEqual(5, vm.Forecasts.Count);
        //}

    }
}
