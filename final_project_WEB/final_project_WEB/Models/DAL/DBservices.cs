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
        sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}', '{4}')", customer.FirstName, customer.SureName, customer.PhoneNumber.ToString(), customer.BirthDay.ToString(), customer.Email);
        String prefix = "INSERT INTO Customer_igroup4 " + "(firstName,sureName,phoneNumber,birthday,email)";
        command = prefix + sb.ToString();

        return command;
    }

    private String BuildInsertCommand(Agent agent)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}', '{4}', '{5}', '{6}')",agent.AgentID.ToString(), agent.FirstName, agent.SureName, agent.Email , agent.Password, agent.PhoneNumber.ToString(), agent.AgencyName);
        String prefix = "INSERT INTO Agent_igroup4 " + "(AgentID,firstName,sureName,email,password1,phoneNumber,agencyName)";
        command = prefix + sb.ToString();

        return command;
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

    public List<Customer> Read_customers()
    {
        List<Customer> customer_list = new List<Customer>();
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
                Customer c = new Customer();
                c.FirstName = (string)dr["firstName"];
                c.SureName = (string)dr["sureName"];
                c.PhoneNumber = Convert.ToInt32(dr["phoneNumber"]);
                c.BirthDay = (string)dr["birthDay"];
                c.Email = (string)dr["email"];
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
                a.PhoneNumber = Convert.ToInt32(dr["phoneNumber"]);
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
}
