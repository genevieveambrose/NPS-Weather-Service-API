using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        public Park()
        {

        }

        public Park(int id, string parkCode, string parkName, string state, int acreage, int elevationInFeet, int milesOfTrail, int numberOfCampsites, string climate, int yearFounded, int annualVisitorCount, string inspirationalQuote, string inspirationalQuoteAuthor, string parkDescription, int entryFee, int numberOfAnimalSpecies)
        {
            Id = id;
            ParkCode = parkCode;
            ParkName = parkName;
            State = state;
            Acreage = acreage;
            ElevationInFeet = elevationInFeet;
            MilesOfTrail = milesOfTrail;
            NumberOfCampsites = numberOfCampsites;
            Climate = climate;
            YearFounded = yearFounded;
            AnnualVisitorCount = annualVisitorCount;
            InspirationalQuote = inspirationalQuote;
            InspirationalQuoteSource = inspirationalQuoteAuthor;
            ParkDescription = parkDescription;
            EntryFee = entryFee;
            NumberOfAnimalSpecies = numberOfAnimalSpecies;
        }

        public int Id { get; set; }
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public int MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }


    }
}
