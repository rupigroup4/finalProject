using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class Agent
    {
        private int agentID;
        private string firstName;
        private string sureName;
        private string email;
        private string password;
        private string phoneNumber;
        private string agencyName;


        public Agent() { }

        public Agent( int agentID, string firstName, string sureName, string password, string phoneNumber, string email, string agencyName)
        {
            AgentID = agentID;
            FirstName = firstName;
            SureName = sureName;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
            AgencyName = agencyName;
        }

        public int AgentID { get => agentID; set => agentID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string SureName { get => sureName; set => sureName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string AgencyName { get => agencyName; set => agencyName = value; }

        public List<Agent> Read_agent()
        {
            DBservices dbs = new DBservices();
            return dbs.Read_agent();
        }

        public string Get_Agentname(string id)
        {
            DBservices dbs = new DBservices();
            return dbs.Get_Agentname(id);
        }

        public int insert_agent(Agent agent)
        {
            DBservices dbs = new DBservices();
            int addedToAgentList = dbs.insert_agent(agent);
            return addedToAgentList;
        }

        public List<string> Read_Email_list()
        {
            DBservices dbs = new DBservices();
            return dbs.Read_Agent_Email_list();
        }
    }
}