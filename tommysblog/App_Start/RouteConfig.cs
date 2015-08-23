using LowercaseRoutesMVC;
using System.Web.Mvc;
using System.Web.Routing;

namespace tommysblog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRouteLowercase(
                name: "Tags",
                url: "blog/tags/{urlSlug}",
                defaults: new { controller = "Blog", action = "Tags", urlSlug = UrlParameter.Optional }
            );

            routes.MapRouteLowercase(
                name: "Archives",
                url: "blog/archive/{month}/{year}",
                defaults: new { controller = "Blog", action = "Archive", month = UrlParameter.Optional, year = UrlParameter.Optional }
            );

            routes.MapRouteLowercase(
                name: "BlogPost",
                url: "blog/{urlSlug}",
                defaults: new { controller = "Blog", action = "BlogPost" }
            );

            routes.MapRouteLowercase(
                name: "LoremLewis",
                url: "loremlewis",
                defaults: new { controller = "Ipsums", action = "LoremLewis" }
            );

            routes.MapRouteLowercase(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
