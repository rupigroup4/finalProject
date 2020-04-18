using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_project_WEB.Models
{
    public class authentication
    {
        string email;
        string token;

        public string Email { get { return email; } set { email = value; } }
        public string Token { get { return token; } set { token = value; } }



        public int insertUserToken(authentication a)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.insertUserToken(a);
        }

        public Customer getUserByToken(string token)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            return dbs.getUserByToken(token);
        }

        public void insertPnToken(string pnToken, string token)
        {
            DBservicesMobile dbs = new DBservicesMobile();
            int numEffected = dbs.insertPnToken(pnToken , token);
        }
    }
}