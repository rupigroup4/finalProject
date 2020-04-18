using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class country
    {
        string iso2;

        public string Iso2 { get { return iso2; } set { iso2 = value; } }
        

        public string getCountryCode(string city)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.getCountryCode(city);
        }
    }
}