using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bug_Tracker_Project.Scripts
{
    public class ProjectCreation
    {

        public static void Validate()
        {
        }

        private static void ValidateEmail(string input)
        {
        }

        private static void ValidatePassword(string input)
        {
        }

        // TODO: Register to database
        public static async Task<bool> CreateProject(string title, string description, DateTime estimatedCompletiion)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
                return false;
            bool result = false;
            
            string query = "INSERT INTO projects  (Title, _Description, EstimatedCompletion)" +
                $"VALUES('{title}' , '{description}', '{estimatedCompletiion.ToString("yyyy-MM-dd H:mm:ss")}' ) ;";

            result = await Operator.ExecuteDbQuery(query);

            return result;
        }
    }
}