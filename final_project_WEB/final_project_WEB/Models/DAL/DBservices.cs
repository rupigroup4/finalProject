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
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
    }
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    public int insert_customer(Customer customer)
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

        String cStr = BuildInsertCommand(customer);      // helper method to build the insert string

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

    private String BuildInsertCommand(Customer customer)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}','{8}')", customer.FirstName, customer.SureName, customer.PhoneNumber, customer.Gender.ToString(), customer.BirthDay.ToString(), customer.Email, customer.Img ,customer.JoinDate, customer.AgentID);
        String prefix = "INSERT INTO Customer_igroup4 " + "(firstName,sureName,phoneNumber,gender,birthday,email,img,joinDate,AgentID)";
        command = prefix + sb.ToString();

        return command;
    }

    public int insert_agent(Agent agent)
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

        String cStr = BuildInsertCommand(agent);      // helper method to build the insert string

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

    private String BuildInsertCommand(Agent agent)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", agent.FirstName, agent.SureName, agent.Email , agent.Password, agent.PhoneNumber, agent.AgencyName);
        String prefix = "INSERT INTO Agent_igroup4 " + "(firstName,sureName,email,password1,phoneNumber,agencyName)";
        command = prefix + sb.ToString();

        return command;
    }
    public int insert_trip(Trip trip)
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

        String cStr = BuildInsertCommand(trip);      // helper method to build the insert string

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

    private String BuildInsertCommand(Trip trip)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}','{4}')", trip.CustomerID.ToString(),trip.Destination, trip.DepartDate, trip.ReturnDate, "1");
        String prefix = "INSERT INTO Trip_igroup4 " + "(_id_customer,_destination,_depart,_return,_id_TripProfile)";
        command = prefix + sb.ToString();

        return command;
    }

    public int Add_pdf_Flightticket(string id, string pdf)
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

        String rStr = "update Trip_igroup4 set pdf_Flightticket ='" + pdf + "' where _id = '" + id + "'";      // helper method to build the insert string

        cmd = CreateCommand(rStr, con);             // create the command

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
    public int changePromotion(string attractionID, int rate)
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

        String rStr = "UPDATE PromotedAttraction_igroup4 SET rate = "+rate+ " WHERE attractionID = '" + attractionID + "'";

        cmd = CreateCommand(rStr, con);             // create the command

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

    public int AddTripProfile(string attractionID, int new_tripProfile,int AgentID)
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

        String rStr = "UPDATE PromotedAttraction_igroup4 SET _"+ new_tripProfile + "= 1 WHERE agent_ID=" + AgentID + "AND attractionID = '" + attractionID + "'";

        cmd = CreateCommand(rStr, con);             // create the command

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

    public List<Promotion> GetPromotedAttraction(int Agent_ID)
    {
        List<Promotion> promotion_list = new List<Promotion>();


        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM PromotedAttraction_igroup4 where Agent_ID=" + Agent_ID;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Promotion p = new Promotion();
                p.AttractionID = (string)dr["attractionID"];
                p.TripProfile_1 = Convert.ToInt32(dr["_1"]);
                p.TripProfile_2 = Convert.ToInt32(dr["_2"]);
                p.TripProfile_3 = Convert.ToInt32(dr["_3"]);
                p.TripProfile_4 = Convert.ToInt32(dr["_4"]);
                p.TripProfile_5 = Convert.ToInt32(dr["_5"]);
                p.Rate = Convert.ToInt32(dr["rate"]);
                promotion_list.Add(p);
            }

            return promotion_list;
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

    public int RemoveTripProfile(string attractionID, int new_tripProfile, int AgentID)
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

        String rStr = "UPDATE PromotedAttraction_igroup4 SET _" + new_tripProfile + "= 0 WHERE agent_ID=" + AgentID + "AND attractionID = '" + attractionID + "'";

        cmd = CreateCommand(rStr, con);             // create the command

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

    public int Update_status(string stat, int RequestID)
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

        String command = "UPDATE Request_igroup4 SET status_ = '" + stat + "' WHERE requestID = " + RequestID.ToString();


        cmd = CreateCommand(command, con);             // create the command

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

    public int insert_Attraction_promotion(string attractionID, int rate, string cityName, int AgentID)
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

        String cStr = BuildInsertATT_PROCommand(attractionID, rate, cityName, AgentID);      // helper method to build the insert string

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

    private String BuildInsertATT_PROCommand(string attractionID, int rate, string cityName, int AgentID)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}','{1}','{2}','{3}')", attractionID, rate, cityName, AgentID);
        String prefix = "INSERT INTO PromotedAttraction_igroup4 " + "(attractionID,rate,cityName,agent_ID)";
        command = prefix + sb.ToString();

        return command;
    }


    public int insert_TripProfile(string attractionID, int tripProfile, string cityName, int AgentID)
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

        String cStr = BuildInsertTripProfile(attractionID, tripProfile, cityName, AgentID);      // helper method to build the insert string

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

    private String BuildInsertTripProfile(string attractionID, int tripProfile, string cityName, int AgentID)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}','{1}','{2}','{3}','{4}')", AgentID, attractionID, 0, cityName ,1);
        String prefix = "INSERT INTO PromotedAttraction_igroup4 " + "(agent_ID,attractionID,rate,cityName,_" + tripProfile+ ")";
        command = prefix + sb.ToString();

        return command;
    }



    public int getCountNEWRequest(int Agent_ID)
    {
        var CountRequest = 0;
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT COUNT(requestID) as count_ FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where status_='new' AND Customer_igroup4.AgentID=" + Agent_ID;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                CountRequest = Convert.ToInt32(dr["count_"]);
            }

            return CountRequest;
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
    public int getCountALLRequest(int Agent_ID)
    {
        var CountRequest = 0;
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT COUNT(requestID) as count_ FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Customer_igroup4.AgentID=" + Agent_ID;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                CountRequest = Convert.ToInt32(dr["count_"]);
            }

            return CountRequest;
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

    public List<object> getShowALLRequest(int Agent_ID)
     {
        List<object> Request_customer_list = new List<object>();
        

        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Customer_igroup4.AgentID=" + Agent_ID;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Request r = new Request();
                r.Id = Convert.ToInt32(dr["requestID"]);
                r.Status = (string)dr["status_"];
                r.AttractionID = (string)dr["attractionID"];
                r.AttractionName = (string)dr["attractionName"];
                r.CustomerID = Convert.ToInt32(dr["CustomerId"]);
                Request_customer_list.Add(r);
                Customer c = new Customer();
                c.Id = Convert.ToInt32(dr["CustomerID"]);
                c.FirstName = (string)dr["firstName"];
                c.SureName = (string)dr["sureName"];
                Request_customer_list.Add(c);

                //CustomersRequest_list.Add(c);
                //Request_list.Add(r);

            }

            return Request_customer_list;
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

    public List<Customer> getShowALLCustomerRequest(int Agent_ID)
    {
        List<Customer> CustomersRequest_list = new List<Customer>();


        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Agent_igroup4.AgentID=" + Agent_ID;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Customer c = new Customer();
                c.Id = Convert.ToInt32(dr["CustomerID"]);
                c.FirstName = (string)dr["firstName"];
                c.SureName = (string)dr["sureName"];
                CustomersRequest_list.Add(c);

            }

            return CustomersRequest_list;
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

    public int Delete_customer(int customerID)
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

        String rStr = BuildDelete_CustomerCommand(customerID);      // helper method to build the insert string

        cmd = CreateCommand(rStr, con);             // create the command

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

    private String BuildDelete_CustomerCommand(int customerID)
    {
        String command;
        command = "DELETE FROM Customer_igroup4 WHERE CustomerID='"+ customerID+"'";//להוסיף פקודת מחיקה מהSQL
        return command;
    }





    public List<Customer> Read_customers(int Agent_ID)
    {
        List<Customer> customer_list = new List<Customer>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Customer_igroup4 where AgentID="+Agent_ID ;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Customer c = new Customer();
                c.Id = Convert.ToInt32(dr["CustomerID"]);
                c.FirstName = (string)dr["firstName"];
                c.SureName = (string)dr["sureName"];
                c.PhoneNumber = (string)dr["phoneNumber"];
                c.BirthDay = (string)dr["birthDay"];
                string[] bday = c.BirthDay.Split('-');
                c.BirthDay = bday[2] + "/" + bday[1] + "/" + bday[0];
                c.Gender = (string)dr["gender"];
                c.Img = (string)dr["img"];
                c.Email = (string)dr["email"];
                c.JoinDate = (string)dr["joinDate"];
                c.AgentID = Convert.ToInt32(dr["AgentID"]);
                
                customer_list.Add(c);
            }

            return customer_list;
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

    public List<Trip> Read_AllTrips(int Agent_ID)
    {
        List<Trip> trip_list = new List<Trip>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Trip_igroup4 LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Agent_igroup4.AgentID=" + Agent_ID;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Trip t = new Trip();
                t.TripID = Convert.ToInt32(dr["_id"]);
                t.CustomerID = Convert.ToInt32(dr["_id_customer"]);
                t.Destination = (string)dr["_destination"];
                t.DepartDate = (string)dr["_depart"];
                string[] DepartDate_arr = t.DepartDate.Split('-');
                t.DepartDate = DepartDate_arr[2] + "/" + DepartDate_arr[1] + "/" + DepartDate_arr[0];
                t.ReturnDate = (string)dr["_return"];
                string[] ReturnDate_arr = t.ReturnDate.Split('-');
                t.ReturnDate = ReturnDate_arr[2] + "/" + ReturnDate_arr[1] + "/" + ReturnDate_arr[0];
                t.TripProfileID = 1;//Convert.ToInt32(dr["_id_TripProfile"]);
                t.Pdf_Flightticket = "";//(string)dr["pdf_Flightticket"];
                trip_list.Add(t);
            }

            return trip_list;
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

    public List<Trip> Read_NotActiveTrips(int Agent_ID)
    {
        List<Trip> trip_list = new List<Trip>();
        SqlConnection con = null;


        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Trip_igroup4 LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Agent_igroup4.AgentID=" + Agent_ID+ " and Trip_igroup4.active=1";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Trip t = new Trip();
                t.TripID = Convert.ToInt32(dr["_id"]);
                t.ReturnDate = (string)dr["_return"];
                trip_list.Add(t);
            }

            return trip_list;
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

    public int SetTripToNotActive(int tripID)
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

        String rStr = "UPDATE Trip_igroup4 SET active= 0 WHERE _id =" + tripID ;

        cmd = CreateCommand(rStr, con);             // create the command

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



    public DBservices readTable()
    {
        int AgentID = 1;// לשלוח את המספר סוכן לפונקציה  
        SqlConnection con = null;
        try
        {
            con = connect("DBConnectionString");
            da = new SqlDataAdapter("select * from Customer_igroup4 where agent_ID=" + AgentID, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
        }

        catch (Exception ex)
        {
            // write errors to log file
            // try to handle the error
            throw ex;
        }

        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }


        return this;

    }

    public void update()
    {
        da.Update(dt);
    }

    public string Get_Agentname(string id_agent)
    {
        var name_agent="";
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "select * from Agent_igroup4 where AgentID='"+ id_agent + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                name_agent = (string)dr["firstName"];
            }

            return name_agent;
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

    public List<string> Read_Customer_Email_list()
    {
        List<string> Email_list = new List<string>();
        string Email;
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Customer_igroup4";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Email = (string)dr["email"];
                Email_list.Add(Email);
            }
            return Email_list;
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

    public List<Agent> Read_agent()
    {
        List<Agent> agents_list = new List<Agent>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Agent_igroup4";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Agent a = new Agent();
                a.AgentID= Convert.ToInt32(dr["AgentID"]);
                a.FirstName = (string)dr["firstName"];
                a.SureName = (string)dr["sureName"];
                a.Email = (string)dr["email"];
                a.Password = (string)dr["password1"];
                a.PhoneNumber = (string)dr["phoneNumber"];
                a.AgencyName = (string)dr["agencyName"];

                agents_list.Add(a);
            }
            return agents_list;
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

    public List<string> Read_Agent_Email_list()
    {
        List<string> Email_list = new List<string>();
        string Email;
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Agent_igroup4";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Email = (string)dr["email"];
                Email_list.Add(Email);
            }
            return Email_list;
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

    public List<string> Read_City_list()
    {
        List<string> City_list = new List<string>();
        string City;
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM countryCode_igroup4";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                City = (string)dr["city"];
                City_list.Add(City);
            }
            return City_list;
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
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

    //public int check_attractionID(string attractionID)
    //{
    //    int checkattractionID=0;
    //    SqlConnection con = null;

    //    try
    //    {
    //        con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

    //        String selectSTR = "select COUNT(attractionID) as count_ from PromotedAttraction_igroup4 where attractionID='" + attractionID+"'";
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);

    //        // get a reader
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

    //        while (dr.Read())
    //        {
    //            checkattractionID = Convert.ToInt32(dr["count_"]);
    //        }
    //        return checkattractionID;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }
    //}

    public int ExistsAttraction(string attractionID, int AgentID)
    {
        int count = 0;
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "select COUNT(*) as count from PromotedAttraction_igroup4 where agent_ID=" + AgentID + " AND attractionID='" + attractionID + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                count = Convert.ToInt32(dr["count"]);
            }
            return count;
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

}
