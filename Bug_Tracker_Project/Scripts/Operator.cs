using System;
using System.Threading.Tasks; // Monterius should I move this to somewhere else?
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Bug_Tracker_Project.Scripts
{
    /// <summary>
    /// Deals with all operations regarding the database
    /// </summary>
    public class Operator
    {
        /// <returns>
        /// Dumps row by row to a database, if successful it returns true
        /// and if unsuccessful returns false Only use if you know the 
        /// database exists prior to calling
        /// </returns>
        public static async Task<bool> DbRetrieval(string query) {

            MySqlConnection con = null;
            MySqlDataReader sqlRd = null;
            bool result = true;

            try
            {
                con = await ConnectToDb();
                MySqlCommand cmd = new MySqlCommand(query, con);
                sqlRd = cmd.ExecuteReader();
            }
            catch (MySqlException err) 
            {
                Console.Write(err);
                result = false;
            }
            finally { DisconectFromDb(con); }
            _ = Console.Read();
            // if it reaches here then it was successfully dumped
            return result;
        }

        /// <summary>
        /// Converts an Object type to a data type string for queryinng
        /// </summary>
        /// <returns> returns a string of the data type </returns>
        public static async Task<String> SqlColumnType(Object value)
        {
            // May need to add more types as more things are added
            if (value.GetType() == typeof(String)) return "text"; // may do something where some of these are chars/varchars down the line to save space
            else if (value.GetType() == typeof(int)) return "int";
            else if (value.GetType() == typeof(double)) return "double";
            else if (value.GetType() == typeof(DateTime)) return "varchar(255)";
            return "text";
        }


        public static async Task<bool> DumpToDb( List<String> columnNames,List <Object> dataVals, string tableName)
        {
            bool result = true;
            MySqlConnection con = null;

            String query = "CREATE table " + tableName + "if not exists (";

            for(int i = 0; i < columnNames.Count(); i++)
            {
                query += columnNames[i] + " " + SqlColumnType(dataVals[i]);
            }


            try
            {
                con = await ConnectToDb();
                MySqlCommand cmd = new MySqlCommand(query, con);
            }
            catch (MySqlException err)
            {
                Console.Write(err);
                result = false;
            }
            finally { DisconectFromDb(con); }
            _ = Console.Read();
            // if it reaches here then it was successfully dumped
            return result;
        }

            ///<returns>
            /// Returns the connection to the database with the hard coded connection string
            ///</returns>
            public static async Task<MySqlConnection> ConnectToDb() {

            // customize connection string for your particular settings
            // Note the default port is 3306 but I chose 6000 because 3306 was not open on my machine.
            String connString =
                "database = bugTrackerFlynt; server = localhost; user id = root; pwd = D@nkm3m3s; Port = 6000";
            MySqlConnection con = new MySqlConnection(connString);
            con.Open();
            return con;
        }


        public static async void DisconectFromDb(MySqlConnection con) { if (con != null) con.Close(); }

        /// <returns>
        /// If successful it returns a valid MySqlDataReader, Upon failing it returns a 
        /// null MySqlDataReader
        /// </returns>
        public static async Task<MySqlDataReader> QueryDb(string query) {

            MySqlConnection con = null;
            MySqlDataReader sqlRd = null;

            try
            {
                con = await ConnectToDb();
                MySqlCommand cmd = new MySqlCommand(query, con);
                sqlRd = cmd.ExecuteReader();
            }
            catch (MySqlException err) { 
                Console.Write(err);
                sqlRd = null;
            }
            finally { DisconectFromDb(con); }

            _ = Console.Read();

            return sqlRd;
        }
    }
}