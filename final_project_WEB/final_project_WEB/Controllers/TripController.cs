using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;

namespace final_project_WEB.Controllers
{
    public class TripController : ApiController
    {
        // GET api/<controller>
        public List<Trip> Get(int Agent_ID)
        {
            Trip trip = new Trip();
            return trip.Read_AllTrips(Agent_ID);
        }
        
        //Mobile//
        [HttpGet]
        [Route("api/Trip/customertrips/{id}")]
        public List<Trip> getCustomerTrips(int id)
        {
            Trip t = new Trip();
            return t.getCustomerTrips(id);
        }

        //[HttpGet]
        //[Route("api/Trip/customertripsprofile/{id}")]
        //public List<Trip> getCustomerTripsProfile(int id)
        //{
        //    Trip t = new Trip();
        //    return t.getCustomerTripsProfile(id);
        //}


        //Mobile//

        //POST api/<controller>
        public int Post([FromBody]Trip trip)
        {
            return trip.insert_trip(trip);
        }

        [HttpPost]
        [Route("api/Trip/Add_pdf_Flightticket")]
        public int Post(string id, string pdf)
        {
            Trip trip = new Trip();
            return trip.Add_pdf_Flightticket( id, pdf);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}