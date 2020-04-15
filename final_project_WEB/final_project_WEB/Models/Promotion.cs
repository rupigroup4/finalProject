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

        public Promotion(string attracionID, int ordersQuantity, bool promoted)
        {
            AttracionID = attracionID;
            OrdersQuantity = ordersQuantity;
            Promoted1 = promoted;
        }

        public Promotion(){}
            
        public string AttracionID { get { return attracionID; } set { attracionID = value; } }
        public int OrdersQuantity { get { return ordersQuantity; } set { ordersQuantity = value; } }
        public bool Promoted1 { get { return Promoted; } set { Promoted = value; } }

        public int CheckAttracionID(string attracionID)
        {
            DBservices dbs = new DBservices();
             int ans =dbs.check_AttracionID(attracionID);
            if (ans == 0)
            {
                int numaffected = dbs.insert_Attraction_promotion(attracionID);
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


    }
}