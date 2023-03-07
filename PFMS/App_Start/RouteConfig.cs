using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PFMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 "Default",
                 "{controller}/{action}",
                defaults: new { controller = "Home", action = "dashboard"}
            );
        }
    }
}
