using System.Linq;
using AutoMapper;
using Business.Dto.LandingPage;
using Business.Services.Query;

namespace Business.Repository.LandingPage
{
    public class LandingPageRepository : BaseRepository, ILandingPageRepository
    {
        public LandingPageRepository(IMapper mapper, IDocumentQueryService documentQueryService) : base(mapper,
            documentQueryService)
        {
        }

        public LandingPageDto GetLandingPageDto(string pageAlias)
        {
            return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.MedioClinic.LandingPage>(pageAlias)
                .AddColumns("DocumentID", "DocumentName")
                .ToList()
                .Select(lp => Mapper.Map<LandingPageDto>(lp))
                .FirstOrDefault();
        }
    }
}