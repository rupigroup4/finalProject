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
        private string sendDate;



        public Request() { }

        public Request(int id, int tripID, string order_date, int numTickets, string status, string pdfFile, string attractionID, string attractionName, int customerID,string sendDate)
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
            SendDate = sendDate;
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
        public string SendDate { get { return sendDate; } set { sendDate = value; } }


        public int Update_status(string stat, int RequestID, int Customer_Id)
        {
            DBservices dbs = new DBservices();
            dbs.updateBadge(Customer_Id);
            return dbs.Update_status(stat, RequestID);
        }

        public Request Move_to_archives(int RequestID, int CustomerID)
        {
            DBservices dbs = new DBservices();
            return dbs.Move_to_archives(RequestID, CustomerID);
        }

        public int PutInArchives(Request request)
        {
            DBservices dbs = new DBservices();
            int numAff = dbs.PutInArchives(request);
            if (numAff == 1)
                return dbs.Delete_Request(request);
            else
                return 0;
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


        public List<string> GetAlbum(int tripID)
        {
            DBservices dbs = new DBservices();
            return dbs.GetAlbum(tripID); ;
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

        public int getNumOfNotificationBefore (int customerId, string type)
        {
            DBservicesMobile dbsM = new DBservicesMobile();
            return dbsM.getNumOfNotificationBefore(customerId,type);
        }

        public void NoNewRequests(int customerId)
        {
            DBservicesMobile dbsM = new DBservicesMobile();
            dbsM.NoNewRequests(customerId);
        }

        //Mobile//

    }
}