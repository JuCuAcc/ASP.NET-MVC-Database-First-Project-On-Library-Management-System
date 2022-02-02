using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library_Mvc_Jashim
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Custom Routing
            routes.MapRoute(
               name: "Book",
               url: "Book/{action}",
               defaults: new { controller = "Book", action = "Index" }
           );

            routes.MapRoute(
               name: "CategoryID",
               url: "Book/{action}",
               defaults: new { controller = "Book", action = "exportReport" }
           );

            //With Constraint
            routes.MapRoute(
               name: "BookCategory",
               url: "BookCategory/{action}/{cId}",
               defaults: new { controller = "BookCategory", action = "CategoryID", cId = UrlParameter.Optional },
               constraints: new { cId = @"\d{1}" }
           );

            //Generic
            routes.MapRoute(
                name: "Generic",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
            );

            //Specific
            routes.MapRoute(
                name: "Specific",
                url: "GenericRoute/Specific",
                defaults: new { controller = "BookCategory", action = "Edit", id = UrlParameter.Optional }
            );



            // Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
