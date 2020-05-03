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
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        
        public int GET_AttracionID(string AttracionID, string cityName)
        {
            Promotion promotion = new Promotion();
            return promotion.CheckAttracionID(AttracionID, cityName);
        }

        [HttpGet]
        [Route("api/Promotion/Add_TripProfile")] // Add Trip Profile
        public int GET_AttracionID(string AttracionID, string TripProfile, string cityName)
        {
            Promotion promotion = new Promotion();
            return promotion.CheckAttractionTripProfile(AttracionID, TripProfile, cityName);
        }

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        [HttpPut]
        [Route("api/Promotion/removePromotion")]
        // PUT api/<controller>/5
        public int PUT_removePromotion(string attracionID)
        {
            Promotion promotion = new Promotion();
            return promotion.RemovePromotion(attracionID);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}