using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bug_Tracker_Project.Scripts
{
    public class TaskCreation
    {

        // TODO: Register to database
        public static async Task<bool> CreateTask(string title, string description)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
                return false;
            bool result = false;
            
            string query = "INSERT INTO tasks  (Title, _Description)" +
                $"VALUES('{title}' , '{description}' ) ;";

            result = await Operator.ExecuteDbQuery(query);

            return result;
        }
    }
}