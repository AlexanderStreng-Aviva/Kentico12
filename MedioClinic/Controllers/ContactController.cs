using System.Web.Mvc;
using Business.DependencyInjection;
using Business.Repository.Contact;
using Business.Repository.Map;
using Business.Services.MediaLibrary;
using MedioClinic.Models.Contact;
using MedioClinic.Utils;

namespace MedioClinic.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactSectionRepository _contactSectionRepository;
        private readonly IMapRepository _mapRepository;
        private readonly IMediaLibraryService _mediaLibraryService;

        public ContactController(IBusinessDependencies dependencies, IContactSectionRepository contactSectionRepository, IMapRepository mapRepository, IMediaLibraryService mediaLibraryService) : base(dependencies)
        {
            _contactSectionRepository = contactSectionRepository;
            _mapRepository = mapRepository;
            _mediaLibraryService = mediaLibraryService;
        }

        public ActionResult Index()
        {
            var contactSection = _contactSectionRepository.GetContactSection();
            if (contactSection == null)
            {
                return HttpNotFound();
            }

            var model = GetPageViewModel(new ContactViewModel
            {
                ContactSection = contactSection,
                OfficeLocations = _mapRepository.GetOfficeLocations(),
                MedicalCenterImages = _mediaLibraryService.GetMediaLibraryFiles("MedicalCenters", Dependencies.SiteContextService.SiteName, ".png", ".jpg")
            }, contactSection.Header);

            return View(model);
        }
    }
}