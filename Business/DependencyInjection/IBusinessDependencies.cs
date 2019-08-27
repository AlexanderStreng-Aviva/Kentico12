using Business.Repository.Company;
using Business.Repository.Menu;
using Business.Repository.Social;
using Business.Services.Context;
using Business.Services.Culture;

namespace Business.DependencyInjection
{
    public interface IBusinessDependencies
    {
        ISiteContextService SiteContextService { get; }
        ICompanyRepository CompanyRepository { get; }
        ISocialLinkRepository SocialLinkRepository { get; }
        ICultureService CultureService { get; }
        IMenuRepository MenuRepository { get; }
    }
}