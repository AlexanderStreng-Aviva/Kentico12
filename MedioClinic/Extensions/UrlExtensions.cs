using Kentico.Content.Web.Mvc;
using Kentico.Web.Mvc;
using System.Web.Mvc;
using MedioClinic.Models;

namespace MedioClinic.Extensions
{
    public static class UrlExtensions
    {
        public static string KenticoImageUrl(this UrlHelper helper, string path, IImageSizeConstraint size = null)
        {
            return helper.Kentico().ImageUrl(path, size?.GetSizeConstraint() ?? SizeConstraint.Empty);
        }
    }
}