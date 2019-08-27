using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MedioClinic.Utils
{
    public class MultiCultureMvcRouteHandler : MvcRouteHandler
    {
        public const string CultureUrlParam = "culture";

        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            try
            {
                var cultureName = requestContext.RouteData.Values[CultureUrlParam].ToString();
                var culture = new System.Globalization.CultureInfo(cultureName);

                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
            catch
            {
                requestContext.HttpContext.Response.StatusCode = 404;
            }

            return base.GetHttpHandler(requestContext);
        }
    }
}