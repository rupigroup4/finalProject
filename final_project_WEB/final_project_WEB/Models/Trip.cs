using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class Trip
    {
        private int tripID;
        private string destination;
        private string departDate;
        private string returnDate;
        private int customerID;
        private int tripProfileID;
        private string pdf_Flightticket;


        public Trip() { }

        public Trip(int tripID, string destination, string departDate, string returnDate, int customerID, int tripProfileID, string pdf_Flightticket)
        {
            TripID = tripID;
            Destination = destination;
            DepartDate = departDate;
            ReturnDate = returnDate;
            CustomerID = customerID;
            TripProfileID = tripProfileID;
            Pdf_Flightticket = pdf_Flightticket;
        }

        public int TripID { get { return tripID; } set { tripID = value; } }
        public string Destination { get { return destination; } set { destination = value; } }
        public string DepartDate { get { return departDate; } set { departDate = value; } }
        public string ReturnDate { get { return returnDate; } set { returnDate = value; } }
        public int CustomerID { get { return customerID; } set { customerID = value; } }
        public int TripProfileID { get { return tripProfileID; } set { tripProfileID = value; } }
        public string Pdf_Flightticket { get { return pdf_Flightticket; } set { pdf_Flightticket = value; } }


        public int insert_trip(Trip trip)
        {
            DBservices dbs = new DBservices();
            int addedToTripList = dbs.insert_trip(trip);
            return addedToTripList;
        }

        public int Add_pdf_Flightticket(string id, string pdf)
        {
            DBservices dbs = new DBservices();
            return dbs.Add_pdf_Flightticket( id, pdf);
        }

        public List<Trip> Read_AllTrips(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.Read_AllTrips(Agent_ID);
        }

    }
}