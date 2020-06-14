using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;

namespace final_project_WEB.Controllers
{
    public class PromotionController : ApiController
    {

        public List<Promotion> GetPromotedAttraction(int Agent_ID)
        {
            Promotion promotion = new Promotion();
            return promotion.GetPromotedAttraction(Agent_ID); 
        }


        [HttpPut]
        [Route("api/Promotion/Add_Rate")]
        public int AddRate(string attractionID, int rate, string cityName, int AgentID)
        {
            Promotion promotion = new Promotion();
            return promotion.CheckattractionID(attractionID, rate, cityName, AgentID);
        }

        [HttpPut]
        [Route("api/Promotion/promote_att")] 
        public int Promote_att([FromBody] Promotion promote)
        {
            return promote.Promote_att(promote);
        }

        [HttpPut]
        [Route("api/Promotion/Remove_TripProfile")] // Add Trip Profile
        public int RemoveTripProfile(string attractionID, int TripProfile, int AgentID)
        {
            Promotion promotion = new Promotion();
            return promotion.RemoveTripProfile(attractionID, TripProfile, AgentID);
        }


        [HttpPut]
        [Route("api/Promotion/removePromotion")]
        // PUT api/<controller>/5
        public int PUT_removePromotion(string attractionID, int AgentID)
        {
            Promotion promotion = new Promotion();
            return promotion.RemovePromotion(attractionID, AgentID);
        }

        public int Put(string Attraction_ID)//Update_status
        {
            Promotion promotion = new Promotion();
            int numEffected = promotion.Increase_OrderNum(Attraction_ID);
            return numEffected;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        //Mobile//
        [HttpGet]
        [Route("api/Promotion/getpromotionbycity/{agentId}/{city}/{tripProfile}")]
        public List<string> getPromotionByCity(int agentId,string city,int tripProfile)
        {
            Promotion p = new Promotion();
            return p.getPromotionByCity(agentId, city, tripProfile);
        }
        //Mobile//
    }
}