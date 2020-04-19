﻿using System;
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
        string fullUrl = "http://proj.ruppin.ac.il/igroup4/mobile/servertest/" + url;
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

            String selectSTR = "SELECT * FROM Trip_igroup4 where _id_customer='" + id + "'";
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

    public List<Request> getTripNotification(int customerId)
    {
        List<Request> notifications = new List<Request>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "select * from Request_igroup4 where customerId ='" + customerId + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Request n = new Request();
                n.Id = Convert.ToInt16(dr["requestID"]);
                if ((string)dr["pdfFile"] != "")
                {
                    n.PdfFile = (string)dr["pdfFile"];
                }
                n.Status = (string)dr["status_"];
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

    public int insertNewNotification(Request notification)
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

        String cStr = BuildInsertCommand(notification);

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

            String selectSTR = "select * from Request_igroup4 left join Trip_igroup4 on Request_igroup4.TripID = Trip_igroup4._id where requestID ='" + requestId + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                if ((string)dr["pdfFile"] != "")
                {
                    n.PdfFile = (string)dr["pdfFile"];
                }
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

    private string BuildInsertCommand(Request notification)
    {
        String command;
        string newStatus = "new";
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}',{1},'{2}','{3}',{4},'{5}')", notification.Order_date, notification.NumTickets, newStatus, "", notification.Id, notification.AttractionID);
        String prefix = "INSERT INTO Request_igroup4 " + "(date_time , numTickets , status_,pdfFile,TripID,attractionId) ";
        command = prefix + sb.ToString();

        return command;
    }

    /////////////////////////////notification////////////////////////////////////////////////////////


}