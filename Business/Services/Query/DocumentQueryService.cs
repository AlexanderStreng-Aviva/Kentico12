using System;
using System.Linq;
using Business.Services.Context;
using CMS.DocumentEngine;

namespace Business.Services.Query
{
    public class DocumentQueryService : BaseService, IDocumentQueryService
    {
        private readonly ISiteContextService _siteContext;

        private readonly string[] _coreColumns =
        {
            "NodeGUID", "DocumentID", "NodeID"
        };

        public DocumentQueryService(ISiteContextService siteContext)
        {
            _siteContext = siteContext;
        }


        public DocumentQuery<TDocument> GetDocument<TDocument>(Guid nodeGuid) where TDocument : TreeNode, new() =>
            GetDocuments<TDocument>().TopN(1).WhereEquals("NodeGUID", nodeGuid);

        public DocumentQuery<TDocument> GetDocument<TDocument>(string pageAlias) where TDocument : TreeNode, new() =>
            GetDocuments<TDocument>().TopN(1).WhereEquals("NodeAlias", pageAlias);

        public DocumentQuery<TDocument> GetDocuments<TDocument>() where TDocument : TreeNode, new() =>
            (_siteContext.IsPreviewEnabled) ? GetPreviewQuery<TDocument>() : GetLiveQuery<TDocument>();
        
        private DocumentQuery<TDocument> GetLiveQuery<TDocument>() where TDocument : TreeNode, new() =>
            DocumentHelper.GetDocuments<TDocument>()
                .Columns(_coreColumns.Concat(new[] {"NodeSiteID"}))
                .OnSite(_siteContext.SiteName)
                .Published(false)
                .LatestVersion()
                .Culture(_siteContext.PreviewCulture);

        private DocumentQuery<TDocument> GetPreviewQuery<TDocument>() where TDocument : TreeNode, new() =>
            DocumentHelper.GetDocuments<TDocument>()
                .Columns(_coreColumns)
                .OnSite(_siteContext.SiteName)
                .Published()
                .PublishedVersion()
                .Culture(_siteContext.CurrentSiteCulture);
    }
}