using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;

namespace final_project_WEB.Controllers
{
    public class CityController : ApiController
    {

        [HttpGet]
        [Route("api/City/city_list")]
        public List<string> GET_City_list()
        {
            City city = new City();
            return city.Read_City_list();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        ////POST api/<controller>
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