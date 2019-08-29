using System.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Sections;

[assembly: RegisterSection("MedioClinic.Section.TwoColumnFortySixty", 
    typeof(TwoColumnFortySixtySectionController),
    "{$Section.TwoColumnFortySixty.Name$}", 
    Description = "Two columns divided 40/60", 
    IconClass = "icon-l-cols-30-70")]
namespace MedioClinic.Controllers.Sections
{
    public class TwoColumnFortySixtySectionController : Controller
    {
        public ActionResult Index()
        {
            return PartialView("Sections/_TwoColumnFortySixtySection");
        }
    }
}