using System.Web.Mvc;
using Business.DependencyInjection;
using Business.Repository.LandingPage;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;

namespace MedioClinic.Controllers
{
    public class LandingPageController : BaseController
    {
        private readonly ILandingPageRepository _landingPageRepository;

        public LandingPageController(IBusinessDependencies dependencies, ILandingPageRepository landingPageRepository) : base(dependencies)
        {
            _landingPageRepository = landingPageRepository;
        }

        public ActionResult Index(string nodeAlias)
        {
            var landingsPageDto = _landingPageRepository.GetLandingPageDto(nodeAlias);
            if (landingsPageDto == null)
            {
                return HttpNotFound();
            }

            var model = GetPageViewModel(landingsPageDto.Title);
            HttpContext.Kentico().PageBuilder().Initialize(landingsPageDto.DocumentId);

            return View(model);

        }
    }
}