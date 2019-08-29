using System.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Sections;

[assembly: RegisterSection("MedioClinic.Section.TwoColumnSixtyForty",
    typeof(TwoColumnSixtyFortySectionController),
    "{$Section.TwoColumnSixtyForty.Name$}", 
    Description = "{$Section.TwoColumnSixtyForty.Description}", 
    IconClass = "icon-l-cols-70-30")]
namespace MedioClinic.Controllers.Sections
{
    public class TwoColumnSixtyFortySectionController : Controller
    {
        public ActionResult Index()
        {
            return PartialView("Sections/_TwoColumnSixtyFortySection");
        }
    }
}