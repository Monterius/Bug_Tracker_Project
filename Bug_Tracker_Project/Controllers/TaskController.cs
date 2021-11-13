using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bug_Tracker_Project.Scripts;
using Bug_Tracker_Project.Models;
using System.Threading.Tasks;

namespace Bug_Tracker_Project.Controllers
{
    public class TaskController : Controller
    {
        // Not being used atm
        public async Task<ActionResult> Index(TaskModel taskModel=null)
        {
            if (taskModel == null) return View("About", new TaskModel());


            if (string.IsNullOrEmpty(taskModel.Title) || string.IsNullOrEmpty(taskModel.Description))
            {
                return View();
            }

            await TaskCreation.CreateTask(taskModel.Title, taskModel.Description);
            
            
            //var results = task.Title + "\n" + task.Description;
            //var resultsHtml = results.Replace("\n", "<br /><br />");

            //var finalTask = new Task(resultsHtml);
            //return View("About", finalTask);

            return View();
        }
    }
}