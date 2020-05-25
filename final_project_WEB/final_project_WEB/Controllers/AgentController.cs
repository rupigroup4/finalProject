using System;
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

        // GET api/<controller>/5

        public string Get(string id)
        {
            Agent agent = new Agent();
            return agent.Get_Agentname(id);
        }
        [HttpGet]
        [Route("api/Agent/Check_agent")]
        public Agent Get_Check_agent(string email, string password)
        {
            Agent agent = new Agent();
            return agent.Get_Check_agent(email,password);
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