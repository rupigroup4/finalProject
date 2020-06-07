using System;
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
        [Route("api/Request/CountNEWRequest")]
        public List<object> GetCountNEWRequest(int Agent_ID)
        {
            Request request = new Request();
            return request.getCountNEWRequest(Agent_ID);
        }

        [HttpGet]
        [Route("api/Request/CountALLRequest")]
        public int GetCountALLRequest(int Agent_ID)
        {
            Request request = new Request();
            return request.getCountALLRequest(Agent_ID);
        }

        [HttpGet]
        [Route("api/Request/ShowAllRequest")]
        public List<object> GetShowALLRequest(int Agent_ID)
        {
            Request request = new Request();
            return request.getShowALLRequest(Agent_ID);
        }

        [HttpGet]
        [Route("api/Request/GetAlbum")]
        public List<string> GetAlbum(int TripID)
        {
            Request request = new Request();
            return request.GetAlbum(TripID);
        }

        [HttpGet]
        [Route("api/Request/lupaExists/{tripId}")]
        public int lupaExists(int tripId)
        {
            Request request = new Request();
            return request.lupaExists(tripId);
        }


        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public int Put(string status,int RequestID, int Customer_Id)//Update_status
        { 
            Request reques = new Request();
            int numEffected = reques.Update_status(status, RequestID, Customer_Id);
            if (numEffected > 0)
            {
                return RequestID;
            }
            else return numEffected;
        }

        public int Put(int RequestID, int CustomerID)//Move request to archives
        {
            Request req = new Request();
            Request request = req.Move_to_archives(RequestID, CustomerID);
            Request ArchivesReq = new Request();
            return ArchivesReq.PutInArchives(request);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        [HttpPost]
        [Route("api/Request/Add_pdf_AttractionTicket")]
        public string Post(string id, string pdf)
        {
            Request request = new Request();
            int num_aff = request.Add_pdf_AttractionTicket(id, pdf);
            if (num_aff == 1)
                return pdf;
            return "";
        }
    }
}