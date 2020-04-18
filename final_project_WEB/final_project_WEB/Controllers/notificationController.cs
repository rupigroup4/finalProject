using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;

namespace final_project_WEB.Controllers
{
    public class notificationController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet]
        [Route("api/notification/specificNotification/{requestId}")]
        public Request GetLastNotification (int requestId)
        {
            Request n = new Request();
            return n.GetLastNotification(requestId);
        }

        [HttpGet]
        [Route("api/notification/{customerId}")]
        public List<Request> Get(int customerId)
        {
            Request n = new Request();
            return n.getTripNotification(customerId);
        }

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{

        //}

        [HttpPost]
        [Route("api/notification/insertNewNotification")]
        public int insertNewNotification([FromBody] Request notification)
        {
            return notification.insertNewNotification(notification);
        }

        [HttpPost]
        [Route("api/notification/pntoken/{pnToken}")]
        public void insertPnToken(string pnToken)
        {
            var re = Request;
            var header = re.Headers;
            if (header.Contains("Authorization"))
            {
                string token = header.GetValues("Authorization").First();
                authentication a = new authentication();
                a.insertPnToken(pnToken, token);
            }
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