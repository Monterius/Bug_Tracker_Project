using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bug_Tracker_Project
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "{controller}/{Register}",
                defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Task",
                url: "{controller}/{About}",
                defaults: new { controller = "Task", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Project",
                url: "{controller}/{Project}",
                defaults: new { controller = "Project", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapMvcAttributeRoutes();
        }
    }
}
