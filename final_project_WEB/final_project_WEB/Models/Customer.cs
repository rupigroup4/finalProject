﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace final_project_WEB.Models
{
    public class Customer
    {
        private int id;
        private string firstName;
        private string sureName;
        private string phoneNumber;
        private string gender;
        private string birthDay;
        private string email;
        private string img;
        private string joinDate;

        public int Id { get {return id; }  set{ id = value; }}
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string SureName { get { return sureName; } set { sureName = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string BirthDay { get { return birthDay; } set { birthDay = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Img { get { return img; } set { img = value; } }
        public string JoinDate { get { return joinDate; } set { joinDate = value; } }

       

        public Customer() { }

        public Customer(int id, string firstName, string sureName, string phoneNumber, string gender, string birthDay, string email, string img, string joinDate)
        {
            Id = id;
            FirstName = firstName;
            SureName = sureName;
            PhoneNumber = phoneNumber;
            Gender = gender;
            BirthDay = birthDay; 
            Email = email;
            Img = img;
            JoinDate = joinDate;
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

        public List<string> Read_Email_list()
        {
            DBservices dbs = new DBservices();
            return dbs.Read_Customer_Email_list();
        }
    }
}