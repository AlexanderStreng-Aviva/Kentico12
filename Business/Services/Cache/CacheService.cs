using System;
using System.Web;
using Business.Services.Context;
using CMS.Base;
using CMS.Helpers;

namespace Business.Services.Cache
{
    public class CacheService : BaseService, ICacheService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ISiteContextService SiteContextService { get; }

        // Injects a service which holds the site name and current culture code name
        public CacheService(ISiteContextService siteContextService, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SiteContextService = siteContextService;
        }

        public string GetNodesCacheDependencyKey(string className, CacheDependencyType dependencyType) => $"nodes|{SiteContextService.SiteName}|{className}|{dependencyType}".ToLowerInvariant();

        public string GetNodeCacheDependencyKey(Guid nodeGuid) => $"nodeguid|{SiteContextService.SiteName}|{nodeGuid}".ToLowerInvariant();

        public void SetOutputCacheDependency(Guid nodeGuid)
        {
            var dependencyCacheKey = GetNodeCacheDependencyKey(nodeGuid);

            // Ensures that the dummy key cache item exists
            CacheHelper.EnsureDummyKey(dependencyCacheKey);

            // Sets cache dependency to clear the cache when there is any change to node with given GUID in Kentico
            HttpContext.Current.Response.AddCacheItemDependency(dependencyCacheKey);
        }

        public TData Cache<TData>(Func<TData> dataLoadMethod, int cacheForMinutes, string cacheItemName, string cacheDependencyKey)
        {
            var cacheSettings = new CacheSettings(cacheForMinutes, cacheItemName, SiteContextService.SiteName, SiteContextService.CurrentSiteCulture)
            {
                GetCacheDependency = () => CacheHelper.GetCacheDependency(cacheDependencyKey.ToLowerInvariant())
            };

            return CacheHelper.Cache(dataLoadMethod, cacheSettings);
        }
    }
}