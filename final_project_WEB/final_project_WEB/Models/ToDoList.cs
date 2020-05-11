using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class ToDoList
    {
        private int agent_ID;
        private int taskID;
        private string text;

        public ToDoList() { }

        public ToDoList(int agent_ID, int taskID, string text)
        {
            Agent_ID = agent_ID;
            TaskID = taskID;
            Text = text;
        }

        public int Agent_ID { get { return agent_ID; } set { agent_ID = value; } }
        public int TaskID { get { return taskID; } set { taskID = value; } }
        public string Text { get { return text; } set { text = value; } }

        public int insert_task(ToDoList task)
        {
            DBservices dbs = new DBservices();
            int addTask = dbs.insert_task(task);
            return addTask;
        }
    }
}