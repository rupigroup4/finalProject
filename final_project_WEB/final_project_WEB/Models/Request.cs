using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class Request
    {
        private int id;
        private string request_dateTime;
        private int numTickets;
        private string status;
        private string pdfFile;
        private string order_date;
        private int tripID;
        private string attractionID;
        
        public Request() { }

        public Request(int id, string request_dateTime, int numTickets, string status, string pdfFile, string order_date, int tripID, string attractionID)
        {
           Id = id;
           Request_dateTime = request_dateTime;
           NumTickets = numTickets;
           Status = status;
           PdfFile = pdfFile;
           Order_date = order_date;
           TripID = tripID;
           AttractionID = attractionID;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Request_dateTime { get { return request_dateTime; } set { request_dateTime = value; } }
        public int NumTickets { get { return numTickets; } set { numTickets = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string PdfFile { get { return pdfFile; } set { pdfFile = value; } }

        public string Order_date { get { return order_date; } set { order_date = value; } }
        public int TripID { get { return tripID; } set { tripID = value; } }
        public string AttractionID { get { return attractionID; } set { attractionID = value; } }


        public int Update_status(string stat, int RequestID)
        {
            DBservices dbs = new DBservices();
            int numEffected = dbs.Update_status(stat, RequestID);
            return numEffected;
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
    }
}