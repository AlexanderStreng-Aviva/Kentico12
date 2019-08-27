using System.Collections.Generic;
using System.Linq;
using Business.Dto.Culture;
using Business.Services.Context;
using CMS.SiteProvider;

namespace Business.Services.Culture
{
    public class CultureService : BaseService, ICultureService
    {
        private readonly ISiteContextService _siteContextService;

        public CultureService(ISiteContextService siteContextService)
        {
            _siteContextService = siteContextService;
        }

        public IEnumerable<CultureDto> GetSiteCultures()
        {
            return CultureSiteInfoProvider.GetSiteCultures(_siteContextService.SiteName).Items.Select(m =>
                new CultureDto
                {
                    CultureGuid = m.CultureGUID,
                    CultureCode = m.CultureCode,
                    CultureName = m.CultureName,
                    CultureShortName = m.CultureShortName
                }
            );
        }
    }
}
