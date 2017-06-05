﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CourseProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "OnlyAction",
            "{action}",
            new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
            name: "Reservation",
             url: "Reservation/{id}",
             defaults: new { controller = "Home", action = "Reservation" },
             constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
            name: "Tour",
             url: "Tour/{id}",
             defaults: new { controller = "Home", action = "Tour" },
             constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
            "Default", 
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        );

        }

    }
}
