using Capstone.Web.DAO;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Capstone.Tests.DAL
{
    public class SurveyMockDAO : ISurveyDAO
    {
        private List<SurveyPost> surveyPosts = new List<SurveyPost>()
        {
            new SurveyPost(1, "CVNP", "emailAddress@email.com", "Ohio", "active"),
            new SurveyPost(2, "CVNP", "emailAddress@email.com", "Ohio", "active"),
            new SurveyPost(3, "CVNP", "emailAddress@email.com", "Ohio", "active"),
            new SurveyPost(4, "CVNP", "emailAddress@email.com", "Ohio", "active")
        };

        public int MaxId
        {
            get
            {
                return surveyPosts.Max(s => s.SurveyId);
            }
        }

        public bool AddSurvey(SurveyPost surveypost)
        {
            surveypost.SurveyId = MaxId + 1;
            surveyPosts.Add(surveypost);
            if (surveyPosts.Count == surveypost.SurveyId)
            {
                return true;
            }
            return false;
        }

        public IList<SurveyPost> GetAllSurveys()
        {
            return new List<SurveyPost>(surveyPosts);
        }
    }
}
