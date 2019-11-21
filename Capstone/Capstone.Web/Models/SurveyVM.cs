using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyVM
    {
        public SurveyPost Survey { get; set; }
        public SelectList ParkDropdown { get; set; }

    }
}
