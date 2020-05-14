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
        private int completed;

        public ToDoList() { }

        public ToDoList(int agent_ID, int taskID, string text, int completed)
        {
            Agent_ID = agent_ID;
            TaskID = taskID;
            Text = text;
            Completed = completed;

        }

        public int Agent_ID { get { return agent_ID; } set { agent_ID = value; } }
        public int TaskID { get { return taskID; } set { taskID = value; } }
        public string Text { get { return text; } set { text = value; } }
        public int Completed { get { return completed; } set { completed = value; } }

        public int insert_task(ToDoList task)
        {
            DBservices dbs = new DBservices();
            return dbs.insert_task(task);
        }

        public int removeTask(int taskID)
        {
            DBservices dbs = new DBservices();
            return dbs.remove_Task(taskID);
        }
        public int updateTask(int taskID, int agent_ID, int completed)
        {
            DBservices dbs = new DBservices();
            return dbs.updateTask(taskID,agent_ID, completed);
        }

        public List<ToDoList> Read_AllTasks(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.Read_AllTasks(Agent_ID);
        }
    }
}