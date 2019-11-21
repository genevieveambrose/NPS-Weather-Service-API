using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAO
{
    public interface IApiParkDAO
    {
        ApiVM GetFeaturedParks();
        ApiVM GetParkByStateCode(string stateCode);
        ApiVM GetSpecificPark(string parkCode);
    }
}
