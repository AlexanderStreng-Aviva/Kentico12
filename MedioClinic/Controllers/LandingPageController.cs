using System.Web.Mvc;
using System.Web.UI;
using Business.DependencyInjection;
using Business.Repository.LandingPage;
using Business.Services.Cache;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;

namespace MedioClinic.Controllers
{
    public class LandingPageController : BaseController
    {
        private readonly ICacheService _cacheService;
        private readonly ILandingPageRepository _landingPageRepository;

        public LandingPageController(IBusinessDependencies dependencies, ICacheService cacheService, ILandingPageRepository landingPageRepository) : base(dependencies)
        {
            _cacheService = cacheService;
            _landingPageRepository = landingPageRepository;
        }

        [OutputCache(Duration = 3600, VaryByParam = "nodeAlias", Location = OutputCacheLocation.Server)]
        public ActionResult Index(string nodeAlias)
        {
            var landingsPageDto = _landingPageRepository.GetLandingPageDto(nodeAlias);
            if (landingsPageDto == null)
            {
                return HttpNotFound();
            }

            _cacheService.SetOutputCacheDependency(nodeAlias);
            var model = GetPageViewModel(landingsPageDto.Title);
            HttpContext.Kentico().PageBuilder().Initialize(landingsPageDto.DocumentId);

            return View(model);

        }
    }
}