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

        public int CheckAttracionID(int AttracionID)
        {
            DBservices dbs = new DBservices();
            return dbs.check_AttracionID(AttracionID);
        }
    }
}