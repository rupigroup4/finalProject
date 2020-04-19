using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;

namespace final_project_WEB.Controllers
{
    public class CustomerController : ApiController
    {
      
        public List<Customer> Get(int Agent_ID)
        {
            Customer customer = new Customer();
            return customer.Read_customers(Agent_ID);
        }

        [HttpGet]
        [Route("api/Customer/email_list")]
        public List<string> GET_Email_list()
        {
            Customer customer = new Customer();
            return customer.Read_Customer_Email_list();
        }

        [HttpGet]
        [Route("api/Customer/ShowCustomerRequest/{Agent_ID}")]
        public List<Customer> GetShowALLCustomerRequest(int Agent_ID)
        {
            Customer customer = new Customer();
            return customer.getShowALLCustomerRequest(Agent_ID);
        }


        public int Post([FromBody] Customer customer)
        {
            return customer.insert_customer(customer);
        }

     

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public int Delete(int customerID)
        {
            Customer customer = new Customer();
            return customer.Delete_customer(customerID);

        }
    }
}