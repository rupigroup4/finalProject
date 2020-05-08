using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class Promotion
    {
        private int agentID;
        private string attracionID;
        private int ordersQuantity;
        private int rate;
        private string cityName;
        private int tripProfile_1;
        private int tripProfile_2;
        private int tripProfile_3;
        private int tripProfile_4;
        private int tripProfile_5;
        

        public Promotion(int agentID, string attracionID, int ordersQuantity, int rate, string cityName, int tripProfile_1, int tripProfile_2, int tripProfile_3, int tripProfile_4, int tripProfile_5)
        {
            AgentID = agentID;
            AttracionID = attracionID;
            OrdersQuantity = ordersQuantity;
            Rate = rate;
            CityName = cityName;
            TripProfile_1 = tripProfile_1;
            TripProfile_2 = tripProfile_2;
            TripProfile_3 = tripProfile_3;
            TripProfile_4 = tripProfile_4;
            TripProfile_5 = tripProfile_5;

        }

        public Promotion(){}
        
        public int AgentID { get { return agentID; } set { agentID = value; } }
        public string AttracionID { get { return attracionID; } set { attracionID = value; } }
        public int OrdersQuantity { get { return ordersQuantity; } set { ordersQuantity = value; } }
        public int Rate { get { return rate; } set { rate = value; } }
        public string CityName { get { return cityName; } set { cityName = value; } }
        public int TripProfile_1 { get { return tripProfile_1; } set { tripProfile_1 = value; } }
        public int TripProfile_2 { get { return tripProfile_2; } set { tripProfile_2 = value; } }
        public int TripProfile_3 { get { return tripProfile_3; } set { tripProfile_3 = value; } }
        public int TripProfile_4 { get { return tripProfile_4; } set { tripProfile_4 = value; } }
        public int TripProfile_5 { get { return tripProfile_5; } set { tripProfile_5 = value; } }


        public int CheckAttracionID(string attracionID,int rate, string cityName, int AgentID)
        {
            DBservices dbs = new DBservices();
             int ans =dbs.ExistsAttraction(attracionID, AgentID);
            if (ans == 0)
            {
                int numaffected = dbs.insert_Attraction_promotion(attracionID,rate, cityName, AgentID);
                return numaffected;
            }
            else
                return dbs.changePromotion(attracionID, rate);

        }

        public int RemovePromotion (string attracionID, int AgentID)
        {
            DBservices dbs = new DBservices();
            int ans = dbs.ExistsAttraction(attracionID, AgentID);
            if (ans==1)
                return dbs.changePromotion(attracionID,0);
            return 0;
        }

        public int AddTripProfile(string attracionID, int tripProfile, string cityName, int AgentID)
        {
            DBservices dbs = new DBservices();
            int ans = dbs.ExistsAttraction(attracionID, AgentID);
            if (ans == 0) //attraction doesn't exist - Add atraction with Promotion 0 and trip profile
            {
                int numaffected = dbs.insert_TripProfile(attracionID, tripProfile, cityName, AgentID);
                return numaffected;
            }
            else
            {
                return dbs.AddTripProfile(attracionID, tripProfile, AgentID);
            }
        }

        public int RemoveTripProfile(string attracionID, int tripProfile, int AgentID)
        {
            DBservices dbs = new DBservices();
            return dbs.RemoveTripProfile(attracionID, tripProfile, AgentID);
        }

        public List<Promotion> GetPromotedAttraction(int Agent_ID)
        {
            DBservices dbs = new DBservices();
            return dbs.GetPromotedAttraction(Agent_ID); ;
        }
    }
}