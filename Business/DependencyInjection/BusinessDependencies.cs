using Business.Repository.Company;
using Business.Repository.Menu;
using Business.Repository.Social;
using Business.Services.Context;
using Business.Services.Culture;

namespace Business.DependencyInjection
{
    public class BusinessDependencies : IBusinessDependencies
    {
        public ISiteContextService SiteContextService { get; }
        public ICompanyRepository CompanyRepository { get; }
        public ISocialLinkRepository SocialLinkRepository { get; }
        public ICultureService CultureService { get; }
        public IMenuRepository MenuRepository { get; }

        public BusinessDependencies(ISiteContextService siteContextService, ICompanyRepository companyRepository, ISocialLinkRepository socialLinkRepository, ICultureService cultureService, IMenuRepository menuRepository)
        {
            SiteContextService = siteContextService;
            CompanyRepository = companyRepository;
            SocialLinkRepository = socialLinkRepository;
            CultureService = cultureService;
            MenuRepository = menuRepository;
        }
    }
}