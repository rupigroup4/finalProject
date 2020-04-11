using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace final_project_WEB.Models
{
    public class City
    {
        private string cityName;
        private string iso2;

        public string CityName { get { return cityName; } set { cityName = value; } }
        public string Iso2 { get { return iso2; } set { iso2 = value; } }

        public City()
        {

        }

        public City(string cityName, string iso2)
        {
            CityName = cityName;
            Iso2 = iso2;
        }

        public List<string> Read_City_list()
        {
            DBservices dbs = new DBservices();
            return dbs.Read_City_list();
        }
    }
}