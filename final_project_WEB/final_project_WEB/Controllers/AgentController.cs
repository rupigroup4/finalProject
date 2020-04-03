﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;

namespace final_project_WEB.Controllers
{
    public class AgentController : ApiController
    {
        // GET api/<controller>
        public List<Agent> Get()
        {
            Agent agent = new Agent();
            return agent.Read_agent();
        }

        [HttpGet]
        [Route("api/Agent/email_list")]
        public List<string> GET_Email_list()
        {
            Agent agent = new Agent();
            return agent.Read_Email_list();
        }

        public int Post([FromBody] Agent agent)
        {
            return agent.insert_agent(agent);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

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