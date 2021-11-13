using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bug_Tracker_Project.Scripts
{
    public class UserRegistry
    {
        private const string EmailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public static string Validate(string email, string password)
        {
            if (email == null || password == null) return "";

            var emailisValid = ValidateEmail(email);
            var passIsValid = ValidatePassword(password);

            var results = "";
            if (emailisValid) results += "Email is valid";
            else results += "Email is invalid";

            if (passIsValid) results += Environment.NewLine + "Password is valid";
            else results += Environment.NewLine + "Password is invalid";

            string success;
            //if (RegisterUser(email, password).Result)
              //  success = "successful user register";

            return results;
        }

        private static bool ValidateEmail(string input)
        {
            var regex = new Regex(EmailPattern, RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValidEmail = regex.IsMatch(input);
            return isValidEmail;
        }

        private static bool ValidatePassword(string input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
            return isValidated;
        }

        public static async Task<bool> RegisterUser(string email, string password, int userType, string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;
            bool result = false;
 
            string query = "INSERT INTO users (username, password, FirstName, LastName, UserType)" +
                $"VALUES('{email}' , '{password}', '{firstName}', '{lastName}', {userType} ) ;";

             result = await Operator.ExecuteDbQuery(query);

            return result;
        }
    }
}