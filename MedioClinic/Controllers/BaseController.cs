using System.Collections.Generic;
using System.Web.Mvc;
using Business.DependencyInjection;
using Business.Dto.Company;
using Business.Dto.Culture;
using Business.Dto.Menu;
using Business.Dto.Page;
using Business.Dto.Social;
using MedioClinic.Models;

namespace MedioClinic.Controllers
{
    public class BaseController : Controller
    {
        protected BaseController(IBusinessDependencies dependencies)
        {
            Dependencies = dependencies;
        }

        protected IBusinessDependencies Dependencies { get; }

        public PageViewModel GetPageViewModel(string title)
        {
            return new PageViewModel
            {
                MenuItems = GetMenuItems(),
                Company = GetCompany(),
                Cultures = GetCultures(),
                SocialLinks = GetSocialLinks(),
                PageMetadata = GetMetaData(title)
            };
        }


        public PageViewModel<TViewModel> GetPageViewModel<TViewModel>(TViewModel data, string title)
            where TViewModel : IViewModel
        {
            return new PageViewModel<TViewModel>
            {
                Data = data,
                MenuItems = GetMenuItems(),
                Company = GetCompany(),
                Cultures = GetCultures(),
                SocialLinks = GetSocialLinks(),
                PageMetadata = GetMetaData(title)
            };
        }

        private PageMetadataDto GetMetaData(string title)
        {
            return new PageMetadataDto
            {
                CompanyName = Dependencies.SiteContextService.SiteName,
                Title = title
            };
        }

        private IEnumerable<MenuItemDto> GetMenuItems() => Dependencies.MenuRepository.GetMenuItems() ?? new List<MenuItemDto>();

        private IEnumerable<CultureDto> GetCultures()
        {
            return Dependencies.CultureService.GetSiteCultures();
        }

        private IEnumerable<SocialLinkDto> GetSocialLinks()
        {
            return Dependencies.SocialLinkRepository.GetSocialLinks();
        }

        private CompanyDto GetCompany()
        {
            return Dependencies.CompanyRepository.GetCompany();
        }
    }
}