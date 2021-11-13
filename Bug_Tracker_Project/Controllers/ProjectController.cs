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
    public class ProjectController : Controller
    {
        public async Task<ActionResult> Index(Project project=null)
        {
            if (project == null) return View("Project", new Project());

            var results = project.Title + "\n" + project.Description;
            var resultsHtml = results.Replace("\n", "<br /><br />");

            var finalTask = new Project(resultsHtml);

            await ProjectCreation.CreateProject(project.Title, project.Description, project.EstimatedCompletionDate);

            return View("Project", finalTask);
        }
    }
}