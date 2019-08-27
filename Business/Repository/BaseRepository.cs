using AutoMapper;
using Business.Services.Query;

namespace Business.Repository
{
    public class BaseRepository : IRepository
    {
        protected BaseRepository(IMapper mapper, IDocumentQueryService documentQueryService)
        {
            Mapper = mapper;
            DocumentQueryService = documentQueryService;
        }
        protected IMapper Mapper { get; }

        protected IDocumentQueryService DocumentQueryService { get; }
    }
}