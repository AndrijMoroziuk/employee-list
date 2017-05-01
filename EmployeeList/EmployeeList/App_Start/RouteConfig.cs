using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeeList.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
               name: "Home",
               url: "",
               defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
               name: "AddEmployee",
               url: "addEmployee",
               defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
              name: "Dashboard",
              url: "dashboard",
              defaults: new { controller = "Home", action = "Index" }
           );


            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "EmployeeList.Web.Controllers" }
            //);
        }
    }
}
