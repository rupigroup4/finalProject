using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Add_Attraction.Models
{
    public class Attraction
    {
        private int id_attraction;
        private string name_attraction;

        public int Id_attraction { get => id_attraction; set => id_attraction = value; }
        public string Name_attraction { get => name_attraction; set => name_attraction = value; }

        public Attraction(int id_attraction, string name_attraction)
        {
            this.id_attraction = id_attraction;
            this.name_attraction = name_attraction;
        }

        public Attraction() { }

        public void INSERT(Attraction attraction)
        {
            DBservices dbs = new DBservices();
            dbs.add_attraction(attraction);
        }
    }

}