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
        private int phoneNumber;
        private string agencyName;


        public Agent() { }

        public Agent( int agentID, string firstName, string sureName, string password, int phoneNumber, string email, string agencyName)
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
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string AgencyName { get => agencyName; set => agencyName = value; }

        public List<Agent> Read_agent()
        {
            DBservices dbs = new DBservices();
            return dbs.Read_agent();
        }

        public int insert_agent(Agent agent)
        {
            DBservices dbs = new DBservices();
            int addedToAgentList = dbs.insert_agent(agent);
            return addedToAgentList;
        }
    }
}