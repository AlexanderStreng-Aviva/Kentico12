using System.Web.Mvc;

namespace MedioClinic.Controllers
{
    public class LandingPageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}