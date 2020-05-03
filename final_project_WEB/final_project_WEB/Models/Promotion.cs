using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class Promotion
    {
        private string attracionID;
        private int ordersQuantity;
        private bool Promoted;
        private string TripProfile;
        private string CityName;

        public Promotion(string attracionID, int ordersQuantity, bool promoted, string tripProfile, string cityName)
        {
            AttracionID = attracionID;
            OrdersQuantity = ordersQuantity;
            Promoted1 = promoted;
            TripProfile1 = tripProfile;
            CityName1 = cityName;
        }

        public Promotion(){}
            
        public string AttracionID { get { return attracionID; } set { attracionID = value; } }
        public int OrdersQuantity { get { return ordersQuantity; } set { ordersQuantity = value; } }
        public bool Promoted1 { get { return Promoted; } set { Promoted = value; } }
        public string TripProfile1 { get { return TripProfile; } set { TripProfile = value; } }
        public string CityName1 { get { return CityName; } set { CityName = value; } }

        public int CheckAttracionID(string attracionID, string cityName)
        {
            DBservices dbs = new DBservices();
             int ans =dbs.check_AttracionID(attracionID);
            if (ans == 0)
            {
                int numaffected = dbs.insert_Attraction_promotion(attracionID, cityName);
                return numaffected;
            }
            else
                return dbs.changePromotion(attracionID, 1);

        }

        public int RemovePromotion (string attracionID)
        {
            DBservices dbs = new DBservices();
            int ans = dbs.check_AttracionID(attracionID);
            if (ans==1)
                return dbs.changePromotion(attracionID,0);
            return 0;
        }

        public int CheckAttractionTripProfile(string attracionID, string tripProfile, string cityName)
        {
            string[] arr_TP;
            DBservices dbs = new DBservices();
            string ans = dbs.getTripProfile(attracionID);
            if (ans == "") //attraction doesn't exist - Add atraction with Promotion 0 and trip profile
            {

                int numaffected = dbs.insert_TripProfile(attracionID, tripProfile, cityName);
                return numaffected;
            }
            else
            {
                arr_TP = ans.Split(',');
                for (int i = 0; i < arr_TP.Length; i++)
                {
                    if (arr_TP[i]== tripProfile)
                    {
                        return -1;
                    }
                }
                ans += "," + tripProfile;
                return dbs.updateTripProfile(attracionID, ans);

            }

        }

    }
}