using System;
using System.Web.Mvc;
using System.Web.UI;
using Business.DependencyInjection;
using Business.Dto.Doctor;
using Business.Repository.Doctor;
using Business.Services.Cache;
using CMS.DocumentEngine.Types.MedioClinic;
using MedioClinic.Models.Doctors;

namespace MedioClinic.Controllers
{
    public class DoctorsController : BaseController
    {
        private readonly ICacheService _cacheService;
        private readonly IDoctorSectionRepository _doctorSectionRepository;
        private readonly IDoctorRepository _doctorsRepository;

        public DoctorsController(IBusinessDependencies dependencies, ICacheService cacheService,
            IDoctorRepository doctorsRepository, IDoctorSectionRepository doctorSectionRepository) : base(dependencies)
        {
            _cacheService = cacheService;
            _doctorsRepository = doctorsRepository;
            _doctorSectionRepository = doctorSectionRepository;
        }

        public ActionResult Index()
        {
            var doctorSection = _cacheService.Cache(
                () => _doctorSectionRepository
                    .GetDoctorSection(), // Gets data for the DoctorSection if there isn't any cached data (data was invalidated or cache expired)
                60, // Sets caching of data to 60 minutes
                $"{nameof(DoctorsController)}|{nameof(Index)}|{nameof(DoctorSectionDto)}", // cached data identifier
                _cacheService.GetNodesCacheDependencyKey(Doctor.CLASS_NAME,
                    CacheDependencyType.All) // cache dependencies
            );

            if (doctorSection == null) return HttpNotFound();

            var model = GetPageViewModel(new DoctorsViewModel
            {
                DoctorSection = doctorSection,
                Doctors = _doctorsRepository.GetDoctors()
            }, doctorSection.Header);

            return View(model);
        }

        [OutputCache(Duration = 3600, VaryByParam = "nodeGuid", Location = OutputCacheLocation.Server)]
        public ActionResult Detail(Guid nodeGuid, string nodeAlias)
        {
            var doctor = _doctorsRepository.GetDoctor(nodeGuid);
            if (doctor == null) return HttpNotFound();


            _cacheService.SetOutputCacheDependency(nodeGuid);
            var model = GetPageViewModel(new DoctorDetailViewModel
            {
                Doctor = doctor
            }, doctor.FullName);

            return View(model);
        }
    }
}