using System.Web;
using System.Web.Optimization;

namespace MedioClinic
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Custom JavaScript files from the ~/Scripts/ directory can be included as well
            bundles.Add(new ScriptBundle("~/bundles/master-scripts")
                .IncludeDirectory("~/Scripts/Master", "*.js", true));

            // Custom CSS files from the ~/Content/ directory can be included as well
            bundles.Add(new StyleBundle("~/bundles/master-css")
                .IncludeDirectory("~/Content/Css/Master", "*.css", true));

            BundleTable.EnableOptimizations = true;
        }
    }
}