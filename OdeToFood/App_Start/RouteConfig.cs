using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;

            // /Cuisine
            routes.MapRoute("Cuisine",
                "cuisine/{name}",
                /*
                 * With 'UrlParameter.Optional' if name is not defined, the route
                 * won't crash and I can also declare an optional name at the controller
                 */
                new { controller = "Cuisine", action = "Search", name = UrlParameter.Optional });

            // /Home
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
