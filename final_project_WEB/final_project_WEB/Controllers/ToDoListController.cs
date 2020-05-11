using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final_project_WEB.Models;


namespace final_project_WEB.Controllers
{
    public class ToDoListController : ApiController
    {

        public int Post([FromBody]ToDoList task)
        {
            return task.insert_task(task);
        }
    }
}