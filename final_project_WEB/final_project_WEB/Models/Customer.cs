using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace final_project_WEB.Models
{
    public class Customer
    {
        private string firstName;
        private string sureName;
        private int phoneNumber;
        private string birthDay;
        private string email;

        public string FirstName { get => firstName; set => firstName = value; }
        public string SureName { get => sureName; set => sureName = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string BirthDay { get => birthDay; set => birthDay = value; }
        public string Email { get => email; set => email = value; }
        
        public Customer() { }

        public Customer(string firstName, string sureName, int phoneNumber, string birthDay, string email)
        {
            FirstName = firstName;
            SureName = sureName;
            PhoneNumber = phoneNumber;
            BirthDay = birthDay;
            Email = email;
        }

        public List<Customer> Read_customers()
        {
            DBservices dbs = new DBservices();
            return dbs.Read_customers();
        }

        public int insert_customer(Customer customer)
        {
            DBservices dbs = new DBservices();
            int addedToCustomerList = dbs.insert_customer(customer);
            return addedToCustomerList;
        }
    }
}