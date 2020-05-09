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
            return promotion.GetPromotedAttraction(Agent_ID); ;
        }


        [HttpPut]
        [Route("api/Promotion/Add_Rate")]
        public int AddRate(string AttracionID,int rate, string cityName, int AgentID)
        {
            Promotion promotion = new Promotion();
            return promotion.CheckAttracionID(AttracionID, rate, cityName, AgentID);
        }

        [HttpPut]
        [Route("api/Promotion/Add_TripProfile")] // Add Trip Profile
        public int AddTripProfile(string AttracionID, int TripProfile, string cityName, int AgentID)
        {
            Promotion promotion = new Promotion();
            return promotion.AddTripProfile(AttracionID, TripProfile, cityName, AgentID);
        }

        [HttpPut]
        [Route("api/Promotion/Remove_TripProfile")] // Add Trip Profile
        public int RemoveTripProfile(string AttracionID, int TripProfile, int AgentID)
        {
            Promotion promotion = new Promotion();
            return promotion.RemoveTripProfile(AttracionID, TripProfile, AgentID);
        }


        [HttpPut]
        [Route("api/Promotion/removePromotion")]
        // PUT api/<controller>/5
        public int PUT_removePromotion(string attracionID, int AgentID)
        {
            Promotion promotion = new Promotion();
            return promotion.RemovePromotion(attracionID, AgentID);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        //Mobile//
        [HttpGet]
        [Route("api/Promotion/getpromotionbycity/{agentId}/{city}/{tripProfile}")]
        public List<Promotion> getPromotionByCity(int agentId,string city,int tripProfile)
        {
            Promotion p = new Promotion();
            return p.getPromotionByCity(agentId, city, tripProfile);
        }
        //Mobile//
    }
}