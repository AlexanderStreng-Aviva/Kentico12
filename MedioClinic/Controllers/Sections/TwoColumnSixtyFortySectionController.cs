using System.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Sections;

[assembly: RegisterSection("MedioClinic.Section.TwoColumnSixtyForty", typeof(TwoColumnSixtyFortySectionController), "Two 60/40 columns", Description = "Two columns, divided 60/40", IconClass = "icon-l-cols-70-30")]
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