using System.Web.Mvc;
using CMS.Helpers;

namespace MedioClinic.Extensions
{
    public static class LocalizationExtensions
    {
        public static string Localize(this HtmlHelper helper, string key)
        {
            return ResHelper.GetString(key);
        }
    }
}