using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bug_Tracker_Project.Models;
using Bug_Tracker_Project.Scripts;
using MySql.Data.MySqlClient;

namespace Bug_Tracker_Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public async Task<ActionResult> Login(String email, String password)
        {
            if( string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return View();
            }
            String query = "select * from users where username = '" + email + "' and password = '" + password + "';";
            Task<MySqlDataReader> sqlRd = Operator.QueryDb(query);
            if (sqlRd == null) return View();
            if (sqlRd.Result.HasRows)
            {
               // Login functionality is working, NOTE: jflynt I just need to figure out
               // how to redirect to the page it logs into
               return View("~Views/Home/Contact.cshtml");
            }
            else return View();
        }

    }
}