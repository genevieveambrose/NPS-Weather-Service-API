using Capstone.Web.DAO;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests.DAL
{
    public class ParkMockDAO : IParkDAO
    {
        private Park testPark = new Park(1, "CVNP", "Cuyahoga Valley National Park", "Ohio", 32832, 696, 125, 0, "Woodland", 2000, 2189848, "Of all the paths...", "John Muir", "Through a short distance...", 0, 390);

        private List<Park> parks = new List<Park>()
        {
            new Park(1, "CVNP", "Cuyahoga Valley National Park", "Ohio", 32832, 696, 125, 0, "Woodland", 2000, 2189848, "Of all the paths...", "John Muir", "Through a short distance...", 0, 390),
            new Park(2, "CVNP", "Cuyahoga Valley National Park", "Ohio", 32832, 696, 125, 0, "Woodland", 2000, 2189848, "Of all the paths...", "John Muir", "Through a short distance...", 0, 390),
            new Park(3, "CVNP", "Cuyahoga Valley National Park", "Ohio", 32832, 696, 125, 0, "Woodland", 2000, 2189848, "Of all the paths...", "John Muir", "Through a short distance...", 0, 390),
            new Park(4, "CVNP", "Cuyahoga Valley National Park", "Ohio", 32832, 696, 125, 0, "Woodland", 2000, 2189848, "Of all the paths...", "John Muir", "Through a short distance...", 0, 390),
            new Park(5, "CVNP", "Cuyahoga Valley National Park", "Ohio", 32832, 696, 125, 0, "Woodland", 2000, 2189848, "Of all the paths...", "John Muir", "Through a short distance...", 0, 390)
        };

        public IList<Park> GetAllParks()
        {
            return new List<Park>(parks);
        }

        public Park GetParkDetail(string parkCode)
        {
            return testPark;
        }
    }
}
