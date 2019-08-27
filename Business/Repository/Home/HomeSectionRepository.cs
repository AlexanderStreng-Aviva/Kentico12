using System.Linq;
using AutoMapper;
using Business.Dto.Home;
using Business.Services.Query;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Home
{
    public class HomeSectionRepository : BaseRepository, IHomeSectionRepository
    {
        public HomeSectionRepository(IMapper mapper, IDocumentQueryService documentQueryService) : base(mapper,
            documentQueryService)
        {
        }

        public HomeSectionDto GetHomeSection()
        {
            return DocumentQueryService.GetDocuments<HomeSection>()
                .AddColumns("Title", "Text", "Button")
                .TopN(1)
                .ToList()
                .Select(m => Mapper.Map<HomeSectionDto>(m))
                .FirstOrDefault();
        }
    }
}