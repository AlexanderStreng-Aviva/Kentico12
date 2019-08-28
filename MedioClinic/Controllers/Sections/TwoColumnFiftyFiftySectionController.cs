using System.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Sections;

[assembly: RegisterSection("MedioClinic.Section.TwoColumnFiftyFifty", typeof(TwoColumnFiftyFiftySectionController), "Two 50/50 columns", Description = "Two columns, divided 50/50", IconClass = "icon-l-cols-2")]
namespace MedioClinic.Controllers.Sections
{
    public class TwoColumnFiftyFiftySectionController : Controller
    {
        public ActionResult Index()
        {
            return PartialView("Sections/_TwoColumnFiftyFiftySection");
        }
    }
}