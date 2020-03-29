using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class Agent
    {
        private string firstName;
        private string sureName;
        private string userName;
        private string password;
        private int phoneNumber;
        private string email;
        private string agencyName;


        public Agent() { }

        public Agent(string firstName, string sureName, string userName, string password, int phoneNumber, string email, string agencyName)
        {
            FirstName = firstName;
            SureName = sureName;
            UserName = userName;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
            AgencyName = agencyName;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string SureName { get => sureName; set => sureName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string AgencyName { get => agencyName; set => agencyName = value; }

        public List<Agent> Read_agent()
        {
            DBservices dbs = new DBservices();
            return dbs.Read_agent();
        }
    }
}