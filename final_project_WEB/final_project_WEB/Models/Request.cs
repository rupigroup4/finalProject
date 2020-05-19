using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class Request
    {
        private int id;
        private int tripID;
        private string order_date;
        private int numTickets;
        private string status;
        private string pdfFile;
        private string attractionID;
        private string attractionName;
        private int customerID;



        public Request() { }

        public Request(int id, int tripID, string order_date, int numTickets, string status, string pdfFile, string attractionID, string attractionName, int customerID)
        {
            Id = id;
            TripID = tripID;
            Order_date = order_date;
            NumTickets = numTickets;
            Status = status;
            PdfFile = pdfFile;
            AttractionID = attractionID;
            AttractionName = attractionName;
            CustomerID = customerID;
        }

        public int Id { get { return id; } set { id = value; } }
        public int NumTickets { get { return numTickets; } set { numTickets = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string PdfFile { get { return pdfFile; } set { pdfFile = value; } }
        public string Order_date { get { return order_date; } set { order_date = value; } }
        public int TripID { get { return tripID; } set { tripID = value; } }
        public string AttractionID { get { return attractionID; } set { attractionID = value; } }
        public string AttractionName { get { return attractionName; } set { attractionName = value; } }
        public int CustomerID { get { return customerID; } set { customerID = value; } }


        public int Update_status(string stat, int RequestID)
        {
            DBservices dbs = new DBservices();
            return dbs.Update_status(stat, RequestID);
        }

        public List<object> getCountNEWRequest(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.getCountNEWRequest(Agent_ID); ;
        }

        public int getCountALLRequest(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.getCountALLRequest(Agent_ID); ;
        }

        public List<object> getShowALLRequest(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.getShowALLRequest(Agent_ID); ;
        }

        public int Add_pdf_AttractionTicket(string id, string pdf)
        {
            string pdf1 = "http://proj.ruppin.ac.il/igroup4/prod/" + pdf;
            DBservices dbs = new DBservices();
            return dbs.Add_pdf_AttractionTicket(id, pdf1);
        }

        //Mobile//

        public List<Request> getCustomerNotification(int customerId)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.getCustomerNotification(customerId);
        }

        public int insertNewNotification(Request notification,int customerId)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.insertNewNotification(notification, customerId);
        }

        public Request GetLastNotification(int requestId)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.GetLastNotification(requestId);
        }

        public string GetpnToken(int requestId)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.GetpnToken(requestId);
        }

        //Mobile//

    }
}