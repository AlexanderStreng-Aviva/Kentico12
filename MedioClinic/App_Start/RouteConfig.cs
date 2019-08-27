using System.Web.Http.Routing.Constraints;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using Kentico.Web.Mvc;
using MedioClinic.Config;
using MedioClinic.Utils;
using SiteCultureConstraint = MedioClinic.Utils.SiteCultureConstraint;

namespace MedioClinic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var defaultCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.Kentico().MapRoutes();

            routes.MapRoute(
                "NotFound",
                "notfound",
                new { controller = "NotFound", action = "Index" }
            );

            var route = routes.MapRoute(
                name: "DoctorWithAlias",
                url: "{culture}/Doctors/Detail/{nodeGuid}/{nodeAlias}",
                defaults: new
                {
                    action = "Detail", controller = "Doctors", culture = defaultCulture.Name, nodeGuid = string.Empty, nodeAlias = ""
                },
                constraints: new
                {
                    culture = new SiteCultureConstraint(AppConfig.SiteName),
                    nodeGuid = new System.Web.Mvc.Routing.Constraints.GuidRouteConstraint(),
                    nodeAlias = new System.Web.Mvc.Routing.Constraints.OptionalRouteConstraint(new System.Web.Mvc.Routing.Constraints.AlphaRouteConstraint())
                }
            );
            route.RouteHandler = new MultiCultureMvcRouteHandler();
            
            route = routes.MapRoute(
                name: "LandingPage",
                url: "{culture}/LandingPage/{nodeAlias}",
                defaults: new { culture = defaultCulture.Name, controller = "LandingPage", action = "Index", nodeAlias = "" },
                constraints: new
                {
                    culture = new SiteCultureConstraint(AppConfig.SiteName),
                    nodeAlias = new System.Web.Mvc.Routing.Constraints.OptionalRouteConstraint(new System.Web.Mvc.Routing.Constraints.RegexRouteConstraint(@"[\w\d_-]*"))
                }
            );
            route.RouteHandler = new MultiCultureMvcRouteHandler();

            route = routes.MapRoute(
                name: "DefaultWithCulture",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { culture = defaultCulture.Name, controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { culture = new SiteCultureConstraint(AppConfig.SiteName), id = new System.Web.Mvc.Routing.Constraints.OptionalRouteConstraint(new System.Web.Mvc.Routing.Constraints.IntRouteConstraint()) }
            );
            route.RouteHandler = new MultiCultureMvcRouteHandler();
        }
    }
}
