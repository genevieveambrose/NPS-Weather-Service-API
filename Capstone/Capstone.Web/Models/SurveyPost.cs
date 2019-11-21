using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyPost
    {
        public SurveyPost()
        {

        }

        public SurveyPost(int surveyId, string parkCode, string emailAddress, string state, string activityLevel)
        {
            this.SurveyId = surveyId;
            this.ParkCode = parkCode;
            this.EmailAddress = emailAddress;
            this.State = state;
            this.ActivityLevel = activityLevel;
        }

        public int SurveyId { get; set; }
        [Required]
        public string ParkCode { get; set; }
        [Required(ErrorMessage = "A valid email address is required")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string State { get; set; }
        [Required(ErrorMessage = "Please choose an activity level")]
        public string ActivityLevel { get; set; }
        public string ParkName { get; set; }
        public int SurveyCount { get; set; }
    }
}
