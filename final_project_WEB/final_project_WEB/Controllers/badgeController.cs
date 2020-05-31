using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;

namespace final_project_WEB.Controllers
{
    public class badgeController : ApiController
    {

        [HttpGet]
        [Route("api/badge/{customerId}/{type}")]
        public int getBadge (int customerId , string type)
        {
            Request r = new Request();
            return r.getNumOfNotificationBefore(customerId, type);
        }

        [HttpPut]
        [Route("api/badge/{customerId}")]
        public void noNewRequests(int customerId)
        {
            Request r = new Request();
            r.NoNewRequests(customerId);
        }

        [HttpPut]
        [Route("api/badge/newMessage/{customerId}")]
        public void NewMessage(int customerId)
        {
            Request r = new Request();
            r.NewMessage(customerId);
        }

        [HttpPut]
        [Route("api/badge/noNewMessage/{customerId}")]
        public void noNewMessage(int customerId)
        {
            Request r = new Request();
            r.noNewMessage(customerId);
        }



        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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