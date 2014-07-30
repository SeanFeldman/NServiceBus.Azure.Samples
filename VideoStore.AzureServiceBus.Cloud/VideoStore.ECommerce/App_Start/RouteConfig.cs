﻿using Microsoft.AspNet.SignalR;

namespace VideoStore.ECommerce
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default", String.Empty, new { controller = "Home", action = "Index" });
        }
    }
}