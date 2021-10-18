using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bug_Tracker_Project.Models;

namespace Bug_Tracker_Project.Controllers
{
    public class TaskController : Controller
    {
        // Not being used atm
        public ActionResult Index(Task task=null)
        {
            if (task == null) return View("About", new Task());

            var results = task.Title + "\n" + task.Description;
            var resultsHtml = results.Replace("\n", "<br /><br />");

            var finalTask = new Task(resultsHtml);
            return View("About", finalTask);
        }
    }
}