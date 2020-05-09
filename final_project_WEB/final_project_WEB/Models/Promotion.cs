using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class Promotion
    {
        private int agentID;
        private string attractionID;
        private int ordersQuantity;
        private int rate;
        private string cityName;
        private int tripProfile_2;
        private int tripProfile_3;
        private int tripProfile_4;
        private int tripProfile_5;
        private int tripProfile_6;



        public Promotion(int agentID, string attractionID, int ordersQuantity, int rate, string cityName, int tripProfile_2, int tripProfile_3, int tripProfile_4, int tripProfile_5, int tripProfile_6)
        {
            AgentID = agentID;
            AttractionID = attractionID;
            OrdersQuantity = ordersQuantity;
            Rate = rate;
            CityName = cityName;
            TripProfile_2 = tripProfile_2;
            TripProfile_3 = tripProfile_3;
            TripProfile_4 = tripProfile_4;
            TripProfile_5 = tripProfile_5;
            TripProfile_6 = tripProfile_6;

        }

        public Promotion(){}
        
        public int AgentID { get { return agentID; } set { agentID = value; } }
        public string AttractionID { get { return attractionID; } set { attractionID = value; } }
        public int OrdersQuantity { get { return ordersQuantity; } set { ordersQuantity = value; } }
        public int Rate { get { return rate; } set { rate = value; } }
        public string CityName { get { return cityName; } set { cityName = value; } }
        public int TripProfile_2 { get { return tripProfile_2; } set { tripProfile_2 = value; } }
        public int TripProfile_3 { get { return tripProfile_3; } set { tripProfile_3 = value; } }
        public int TripProfile_4 { get { return tripProfile_4; } set { tripProfile_4 = value; } }
        public int TripProfile_5 { get { return tripProfile_5; } set { tripProfile_5 = value; } }
        public int TripProfile_6 { get { return tripProfile_6; } set { tripProfile_6 = value; } }


        public int CheckattractionID(string attractionID, int rate, string cityName, int AgentID)
        {
            DBservices dbs = new DBservices();
             int ans =dbs.ExistsAttraction(attractionID, AgentID);
            if (ans == 0)
            {
                int numaffected = dbs.insert_Attraction_promotion(attractionID, rate, cityName, AgentID);
                return numaffected;
            }
            else
                return dbs.changePromotion(attractionID, rate);

        }

        public int RemovePromotion (string attractionID, int AgentID)
        {
            DBservices dbs = new DBservices();
            int ans = dbs.ExistsAttraction(attractionID, AgentID);
            if (ans==1)
                return dbs.changePromotion(attractionID, 0);
            return 0;
        }

        public int AddTripProfile(string attractionID, int tripProfile, string cityName, int AgentID)
        {
            DBservices dbs = new DBservices();
            int ans = dbs.ExistsAttraction(attractionID, AgentID);
            if (ans == 0) //attraction doesn't exist - Add atraction with Promotion 0 and trip profile
            {
                int numaffected = dbs.insert_TripProfile(attractionID, tripProfile, cityName, AgentID);
                return numaffected;
            }
            else
            {
                return dbs.AddTripProfile(attractionID, tripProfile, AgentID);
            }
        }

        public int RemoveTripProfile(string attractionID, int tripProfile, int AgentID)
        {
            DBservices dbs = new DBservices();
            return dbs.RemoveTripProfile(attractionID, tripProfile, AgentID);
        }

        public List<Promotion> GetPromotedAttraction(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.GetPromotedAttraction(Agent_ID); ;
        }

        //Mobile//

        public List<Promotion> getPromotionByCity(int agentId,string city,int tripProfile)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.getPromotionByCity(agentId,city, tripProfile);
        }

        //Mobile//
    }
}