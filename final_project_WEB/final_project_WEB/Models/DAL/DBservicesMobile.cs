using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using final_project_WEB.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservicesMobile
{

    public DBservicesMobile() { }

    /////////////////////////////General////////////////////////////////////////////////////////

    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

    /////////////////////////////General////////////////////////////////////////////////////////


    /////////////////////////////Authentication////////////////////////////////////////////////////////

    public int insertUserToken(authentication a)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = "UPDATE Customer_igroup4 SET authToken = '" + a.Token + "' where email='" + a.Email + "'";   // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public Customer getUserByToken(string token)
    {
        Customer c = new Customer();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Customer_igroup4 where authToken='" + token + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                c.Id = Convert.ToInt16(dr["CustomerId"]);
                c.FirstName = (string)dr["firstName"];
                c.SureName = (string)dr["sureName"];
                c.BirthDay = (string)dr["birthday"];
                c.Email = (string)dr["email"];
                c.Img = (string)dr["img"];
                c.PnToken = (string)dr["pnToken"];
                c.AgentID = Convert.ToInt16(dr["agentId"]);
            }
            return c;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    public int insertPnToken(string pnToken, string token)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = "UPDATE Customer_igroup4 SET pnToken = '" + pnToken + "'where authToken='" + token + "'";   // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    /////////////////////////////Authentication////////////////////////////////////////////////////////

    /////////////////////////////Customer////////////////////////////////////////////////////////

    public int postCustomerImage(string url, string token)
    {
        string fullUrl = "http://proj.ruppin.ac.il/igroup4/prod/" + url;
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = "UPDATE Customer_igroup4 SET img = '" + fullUrl + "' where authToken ='" + token + "'";

        cmd = CreateCommand(cStr, con);   // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    /////////////////////////////Customer////////////////////////////////////////////////////////

    /////////////////////////////trip////////////////////////////////////////////////////////

    public List<Trip> getCustomerTrips(int id)
    {
        List<Trip> trips = new List<Trip>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Trip_igroup4 where _id_customer='" + id + "'and active=1";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Trip t = new Trip();
                t.TripID = Convert.ToInt16(dr["_id"]);
                t.Destination = (string)dr["_destination"];
                t.DepartDate = (string)dr["_depart"];
                t.ReturnDate = (string)dr["_return"];
                t.TripProfileID = Convert.ToInt16(dr["_id_TripProfile"]);
                if ((string)dr["pdf_Flightticket"] != "")
                {
                    t.Pdf_Flightticket = (string)dr["pdf_Flightticket"];
                }
                trips.Add(t);
            }
            return trips;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }


    public List<string> getTripProfile()
    {
        List<string> tripProfile = new List<string>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT _name FROM TripProfile_igroup4 ";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {

                tripProfile.Add((string)dr["_name"]);
            }
            return tripProfile;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    public int updateTripProfile(int tripId, int tripProfile)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = "update Trip_igroup4 set _id_TripProfile='" + tripProfile + "' where _id='" + tripId + "'";

        cmd = CreateCommand(cStr, con);   // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }




    /////////////////////////////trip////////////////////////////////////////////////////////

    /////////////////////////////country////////////////////////////////////////////////////////

    public string getCountryCode(string city)
    {
        country c = new country();

        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT iso2 FROM CountryCode_igroup4 where city='" + city + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                c.Iso2 = (string)dr["iso2"];
            }
            return c.Iso2;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    /////////////////////////////country////////////////////////////////////////////////////////

    /////////////////////////////notification////////////////////////////////////////////////////////

    public List<Request> getCustomerNotification(int customerId)
    {
        List<Request> notifications = new List<Request>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "select * from Request_igroup4 where customerId ='" + customerId + "'order by send_date";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Request n = new Request();
                n.Id = Convert.ToInt16(dr["requestID"]);
                n.Order_date = (string)dr["date_time"];
                if (dr["pdfFile"] != System.DBNull.Value)
                {
                    n.PdfFile = (string)dr["pdfFile"];
                }
                n.Status = (string)dr["status_"];
                n.TripID = Convert.ToInt16(dr["TripID"]);
                n.AttractionName = (string)dr["attractionName"];
                notifications.Add(n);
            }
            return notifications;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    public int insertNewNotification(Request notification, int customerId)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(notification, customerId);

        cmd = CreateCommand(cStr, con);   // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    public Request GetLastNotification(int requestId)
    {
        Request n = new Request();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "select * from Request_igroup4 where requestID ='" + requestId + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                n.Id = Convert.ToInt16(dr["requestID"]);
                n.Order_date = (string)dr["date_time"];
                if ((string)dr["pdfFile"] != "")
                {
                    n.PdfFile = (string)dr["pdfFile"];
                }
                n.TripID = Convert.ToInt16(dr["TripID"]);
                n.AttractionName = (string)dr["attractionName"];
                n.Status = (string)dr["status_"];
            }
            return n;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    private string BuildInsertCommand(Request notification, int customerId)
    {
        String command;
        string newStatus = "new";
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}',{1},'{2}','{3}',{4},'{5}','{6}',{7})", notification.Order_date, notification.NumTickets, newStatus, "", notification.TripID, notification.AttractionID, notification.AttractionName, customerId);
        String prefix = "INSERT INTO Request_igroup4 " + "(date_time , numTickets , status_,pdfFile,TripID,attractionId,attractionName,customerId) ";
        command = prefix + sb.ToString();

        return command;
    }

    public string GetpnToken(int requestId)
    {
        string pnToken = "";
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "select pnToken from Request_igroup4 left join Customer_igroup4 on Request_igroup4.customerId = Customer_igroup4.CustomerID where requestID='" + requestId + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                pnToken = (string)dr["pnToken"];
            }
            return pnToken;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    /////////////////////////////notification////////////////////////////////////////////////////////


    /////////////////////////////Promotion////////////////////////////////////////////////////////

    public List<string> getPromotionByCity(int agentId, string city, int tripProfile)
    {
        List<string> PromotionAttractions = new List<string>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            String selectSTR = "";
            if (tripProfile == 1)
            {
                selectSTR = "select * from PromotedAttraction_igroup4 where agent_ID='" + agentId + "'and cityName ='" + city + "' order by rate DESC";
            }
            else
            {
                selectSTR = "select * from PromotedAttraction_igroup4 where agent_ID='" + agentId + "'and cityName ='" + city + "' and _" + tripProfile + "=1 order by rate DESC";
            }
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                PromotionAttractions.Add((string)dr["attractionID"]);
            }
            return PromotionAttractions;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    /////////////////////////////Promotion////////////////////////////////////////////////////////


}
