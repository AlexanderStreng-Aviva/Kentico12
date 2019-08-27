using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using CMS.SiteProvider;

namespace MedioClinic.Utils
{
    public class SiteCultureConstraint : IRouteConstraint
    {
        private readonly HashSet<string> _allowedCultureNames;

        public SiteCultureConstraint(string siteName)
        {
            var siteCultureNames = CultureSiteInfoProvider.GetSiteCultureCodes(siteName);
            _allowedCultureNames = new HashSet<string>(siteCultureNames, StringComparer.InvariantCultureIgnoreCase);
        }


        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var cultureName = values[parameterName].ToString();
            return _allowedCultureNames.Contains(cultureName);
        }
    }
}