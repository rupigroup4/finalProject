using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;

namespace final_project_WEB.Controllers
{
    public class AuthController : ApiController
    {
        // GET api/<controller>
        public Customer Get()
        {
            var re = Request;
            var header = re.Headers;
            if (header.Contains("Authorization"))
            {
                string token = header.GetValues("Authorization").First();
                authentication a = new authentication();
                return a.getUserByToken(token);
            }
            return null;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]authentication a)
        {
            a.insertUserToken(a);
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