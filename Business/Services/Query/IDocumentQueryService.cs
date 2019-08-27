using System;
using CMS.DocumentEngine;

namespace Business.Services.Query
{
    public interface IDocumentQueryService
    {
        DocumentQuery<TDocument> GetDocument<TDocument>(string pageAlias) where TDocument : TreeNode, new();

        DocumentQuery<TDocument> GetDocument<TDocument>(Guid nodeGuid) where TDocument : TreeNode, new();

        DocumentQuery<TDocument> GetDocuments<TDocument>() where TDocument : TreeNode, new();
    }
}