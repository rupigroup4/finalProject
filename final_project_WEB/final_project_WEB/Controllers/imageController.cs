using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using final_project_WEB.Models;


namespace final_project_WEB.Controllers
{
    public class imageController : ApiController
    {

        [HttpPost]
        [Route("api/image/uploadimage")]
        public HttpResponseMessage Post()
        {
            List<string> imageLinks = new List<string>();
            var httpContext = HttpContext.Current;

            if (httpContext.Request.Files.Count > 0)
            {
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContext.Request.Files[i];

                    if (httpPostedFile != null)
                    {
                        string fname = httpPostedFile.FileName;
                        var fileSavePath = Path.Combine(HostingEnvironment.MapPath("~/uploadImages"), fname);

                        httpPostedFile.SaveAs(fileSavePath);
                        imageLinks.Add("uploadImages/" + fname);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.Created, imageLinks);
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
        public void Post([FromBody]string url)
        {
            var re = Request;
            var header = re.Headers;
            if (header.Contains("Authorization"))
            {
                string token = header.GetValues("Authorization").First();
                Customer c = new Customer();
                c.postCustomerImage(url, token);
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