using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.DependencyInjection;
using Business.Repository.CompanyService;
using Business.Repository.Home;
using CMS.DocumentEngine;

using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using MedioClinic.Models.Home;

namespace MedioClinic.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICompanyServiceRepository _companyServiceRepository;
        private readonly IHomeSectionRepository _homeSectionRepository;

        public HomeController(IBusinessDependencies businessDependencies, ICompanyServiceRepository companyServiceRepository, IHomeSectionRepository homeSectionRepository) : base(businessDependencies)
        {
            _companyServiceRepository = companyServiceRepository;
            _homeSectionRepository = homeSectionRepository;
        }

        public ActionResult Index()
        {
            var homeSection = _homeSectionRepository.GetHomeSection();
            if (homeSection == null)
            {
                return HttpNotFound();
            }

            var model = GetPageViewModel(new HomeViewModel
            {
                CompanyServices = _companyServiceRepository.GetCompanyServices(),
                HomeSection = homeSection
            }, homeSection.Title);

            return View(model);
        }
    }
}