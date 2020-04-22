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


        public Request() { }

        public Request(int id, int tripID, string order_date, int numTickets, string status, string pdfFile, string attractionID, string attractionName)
        {
            Id = id;
            TripID = tripID;
            Order_date = order_date;
            NumTickets = numTickets;
            Status = status;
            PdfFile = pdfFile;
            AttractionID = attractionID;
            AttractionName = attractionName;
        }

        public int Id { get { return id; } set { id = value; } }
        public int NumTickets { get { return numTickets; } set { numTickets = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string PdfFile { get { return pdfFile; } set { pdfFile = value; } }
        public string Order_date { get { return order_date; } set { order_date = value; } }
        public int TripID { get { return tripID; } set { tripID = value; } }
        public string AttractionID { get { return attractionID; } set { attractionID = value; } }
        public string AttractionName { get { return attractionName; } set { attractionName = value; } }


        public int Update_status(string stat, int RequestID)
        {
            DBservices dbs = new DBservices();
            return dbs.Update_status(stat, RequestID);
        }

        public int getCountNEWRequest(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.getCountNEWRequest(Agent_ID); ;
        }

        public int getCountALLRequest(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.getCountALLRequest(Agent_ID); ;
        }

        public List<Request> getShowALLRequest(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.getShowALLRequest(Agent_ID); ;
        }

        //Mobile//

        public List<Request> getTripNotification(int customerId)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.getTripNotification(customerId);
        }

        public int insertNewNotification(Request notification)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.insertNewNotification(notification);
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