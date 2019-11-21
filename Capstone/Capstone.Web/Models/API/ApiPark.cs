using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ApiPark
    {
        public string total { get; set; }
        public ParkArray[] data { get; set; }
        public string limit { get; set; }
        public string start { get; set; }

    }

    public class ParkArray
    {
        public string states { get; set; }
        public Entrancefee[] entranceFees { get; set; }
        public string directionsInfo { get; set; }
        public string directionsUrl { get; set; }
        public string url { get; set; }
        public string weatherInfo { get; set; }
        public string name { get; set; }
        public string latLong { get; set; }
        public string description { get; set; }
        public Image[] images { get; set; }
        public string designation { get; set; }
        public string parkCode { get; set; }
        public string id { get; set; }
        public string fullName { get; set; }

        public string latitude
        {
            get
            {
                string[] array = latLong.Split(":");
                string lat = array[1].Substring(0, 2);
                return lat;

            }
        }

        public string longitude
        {
            get
            {
                string[] array = latLong.Split(":");
                string[] arrayTwo = array[2].Split(".");
                string longi = arrayTwo[0];
                return longi;

            }
        }

    }

    public class Entrancefee
    {
        public string cost { get; set; }
        public string description { get; set; }
        public string title { get; set; }
    }

    public class Image
    {
        public string credit { get; set; }
        public string altText { get; set; }
        public string title { get; set; }
        public string id { get; set; }
        public string caption { get; set; }
        public string url { get; set; }
    }



    //public class ParkArray
    //{
    //    public string states { get; set; }
    //    public string latLong { get; set; }
    //    public string description { get; set; }
    //    public string designation { get; set; }
    //    public string parkCode { get; set; }
    //    public string id { get; set; }
    //    public string directionsInfo { get; set; }
    //    public string directionsUrl { get; set; }
    //    public string fullName { get; set; }
    //    public string url { get; set; }
    //    public string weatherInfo { get; set; }
    //    public string name { get; set; }
    //}



}
