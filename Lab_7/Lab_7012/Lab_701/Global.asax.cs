using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lab_701.Models;
using Lab_701.App_Start;
using System.Data.Entity;
using System.Web.Http;

namespace Lab_701
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //Database.SetInitializer(new CatalogDbInitializer());
            //AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new CatalogDbInitializer());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
