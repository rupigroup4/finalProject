﻿using System;
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
        public List<object> Get(int Agent_ID)
        {
            Trip trip = new Trip();
            return trip.Read_AllTrips(Agent_ID);
        }

        [HttpGet]
        [Route("api/Trip/customertrips")] //Get all customer trips to do validation 
        public List<Trip> getAllCustomerTrips(int customerID)
        {
            Trip t = new Trip();
            return t.getAllCustomerTrips(customerID);
        }

        //Mobile//
        [HttpGet]
        [Route("api/Trip/customertrips/{id}")]
        public List<Trip> getCustomerTrips(int id)
        {
            Trip t = new Trip();
            return t.getCustomerTrips(id);
        }

        [HttpGet]
        [Route("api/Trip/tripProfile")]
        public List<string> getTripProfile()
        {
            Trip t = new Trip();
            return t.getTripProfile();
        }

        [HttpPut]
        [Route("api/Trip/updatetripprofile/{tripId}/{tripProfile}")]
        public int updateTripProfile(int tripId, int tripProfile)
        {
            Trip t = new Trip();
            return t.updateTripProfile(tripId, tripProfile);
        }

        [HttpGet]
        [Route("api/Trip/getTripAlbum/{tripId}")]
        public List<string> getTripAlbum(int tripId)
        {
            Trip t = new Trip();
            return t.getTripAlbum(tripId);
        }

        [HttpPost]
        [Route("api/Trip/addToAlbum/{tripId}")]
        public int addToAlbum(int tripId, [FromBody] string url)
        {
            Trip t = new Trip();
            return t.addToAlbum(tripId,url);
        }

        [HttpDelete]
        [Route("api/Trip/removeImage/{tripId}")]
        public int removeImage (int tripId, [FromBody] string url)
        {
            Trip t = new Trip();
            return t.removeImage(tripId,url);
        }


        //Mobile//

        //POST api/<controller>
        public int Post([FromBody]Trip trip)
        {
            return trip.insert_trip(trip);
        }

        [HttpPost]
        [Route("api/Trip/Add_pdf_Flightticket")]
        public string Post(string id, string pdf)
        {
            Trip trip = new Trip();
            int num_aff = trip.Add_pdf_Flightticket( id, pdf);
            if(num_aff==1)
                return pdf;
            return "";
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public int Delete(int tripID)
        {
            Trip trip = new Trip();
            return trip.Delete_trip(tripID);

        }

        [HttpPut]
        [Route("api/Trip/ActiveTrips")]
        public int UpDateActiveTrips(int Agent_ID)
        {
            DateTime today = new DateTime();
            today = DateTime.Now;
            Trip t = new Trip();
            return t.getActiveTrips(Agent_ID, today);
        }
    }
}