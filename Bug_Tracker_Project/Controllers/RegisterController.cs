using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bug_Tracker_Project.Models;
using Bug_Tracker_Project.Scripts;
using System.Threading.Tasks;


namespace Bug_Tracker_Project.Controllers
{
    public class RegisterController : Controller
    {
        /// <summary>
        /// Return a different view based on whether the register is successful.
        /// Probably needs to work with async. Change this to AsyncController
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        public async Task<ActionResult> Index(RegisterModel registerModel = null)
        {
            if (registerModel == null) return View("Register", new RegisterModel());

            var results = UserRegistry.Validate(registerModel.Email, registerModel.Password);

            var resultsHtml = results.Replace("\n", "<br /><br />");
            var register = new RegisterModel(resultsHtml);

            await UserRegistry.RegisterUser(registerModel.Email, registerModel.Password, ((int)registerModel.UserType), registerModel.FirstName, registerModel.LastName);
            
            return View("Register", register); // should return to the index rather than the ret
        }
    }
}