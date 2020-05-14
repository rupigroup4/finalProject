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

        public List<ToDoList> Get(int Agent_ID)
        {
            ToDoList taskList = new ToDoList();
            return taskList.Read_AllTasks(Agent_ID);
        }

        public int PUT(int taskID, int agent_ID, int completed)
        {
            ToDoList task = new ToDoList();
            return task.updateTask(taskID, agent_ID, completed);
        }

        public int Delete(int taskID)
        {
            ToDoList task = new ToDoList();
            return task.removeTask(taskID);
        }
    }
}