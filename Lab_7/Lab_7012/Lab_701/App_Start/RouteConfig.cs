using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab_701
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Phone",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Phone", action = "Browse", id = UrlParameter.Optional }
            );
        }
    }
}
