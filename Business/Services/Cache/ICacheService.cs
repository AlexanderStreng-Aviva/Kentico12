using System;

namespace Business.Services.Cache
{
    public interface ICacheService : IService
    {
        string GetNodeCacheDependencyKey(Guid nodeGuid);

        string GetNodesCacheDependencyKey(string className, CacheDependencyType dependencyType);

        void SetOutputCacheDependency(Guid nodeGuid);

        string GetNodeCacheDependencyKey(string nodeAliasPath);

        void SetOutputCacheDependency(string nodeAliasPath);

        TData Cache<TData>(Func<TData> dataLoadMethod, int cacheForMinutes, string cacheItemName,
            string cacheDependencyKey);
    }
}