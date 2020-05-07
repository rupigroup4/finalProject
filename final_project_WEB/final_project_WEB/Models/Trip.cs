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
        private bool activeTrip;


        public Trip() { }

        public Trip(int tripID, string destination, string departDate, string returnDate, int customerID, int tripProfileID, string pdf_Flightticket, bool activeTrip)
        {
            TripID = tripID;
            Destination = destination;
            DepartDate = departDate;
            ReturnDate = returnDate;
            CustomerID = customerID;
            TripProfileID = tripProfileID;
            Pdf_Flightticket = pdf_Flightticket;
            ActiveTrip = activeTrip;
        }

        public int TripID { get { return tripID; } set { tripID = value; } }
        public string Destination { get { return destination; } set { destination = value; } }
        public string DepartDate { get { return departDate; } set { departDate = value; } }
        public string ReturnDate { get { return returnDate; } set { returnDate = value; } }
        public int CustomerID { get { return customerID; } set { customerID = value; } }
        public int TripProfileID { get { return tripProfileID; } set { tripProfileID = value; } }
        public string Pdf_Flightticket { get { return pdf_Flightticket; } set { pdf_Flightticket = value; } }
        public bool ActiveTrip { get { return activeTrip; } set { activeTrip = value; } }


        public int insert_trip(Trip trip)
        {
            DBservices dbs = new DBservices();
            int addedToTripList = dbs.insert_trip(trip);
            return addedToTripList;
        }

        public int Add_pdf_Flightticket(string id, string pdf)
        {
           string  pdf1 = "http://proj.ruppin.ac.il/igroup4/prod/"+pdf;
            DBservices dbs = new DBservices();
            return dbs.Add_pdf_Flightticket( id, pdf1);
        }

        public List<Trip> Read_AllTrips(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.Read_AllTrips(Agent_ID);
        }

        public int getActiveTrips(int Agent_ID, DateTime today)
        {
            DBservices dbs = new DBservices();
            List <Trip> trip_list = dbs.Read_NotActiveTrips(Agent_ID);
            int count = 0;
            foreach (var item in trip_list)
            {
                string[] ReturnDate_arr = item.ReturnDate.Split('-');
                DateTime ReturnDate = new DateTime(Convert.ToInt32(ReturnDate_arr[0]), Convert.ToInt32(ReturnDate_arr[1]) - 1, Convert.ToInt32(ReturnDate_arr[2]));
                if (ReturnDate <= today)
                {
                    dbs.SetTripToNotActive(item.TripID);
                    count++;
                }
            }
            return count;
        }


        //Mobile//

        public List<Trip> getCustomerTrips(int id)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.getCustomerTrips(id);
        }

        public List<string> getTripProfile()
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.getTripProfile();
        }

        public int updateTripProfile(int tripId, int tripProfile)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.updateTripProfile(tripId, tripProfile);
        }

        //Mobile//

    }
}