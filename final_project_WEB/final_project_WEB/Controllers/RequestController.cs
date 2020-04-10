﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;


namespace final_project_WEB.Controllers
{
    public class RequestController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/Request/CountRequest")]
        public int GetCount()
        {
            Request request = new Request();
            return request.getCountRequest();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public int Put(string stat,int RequestID)
        { 
            Request reques = new Request();
            return reques.Update_status(stat, RequestID);

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}