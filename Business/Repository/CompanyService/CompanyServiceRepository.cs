using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Dto.CompanyService;
using Business.Services.Query;

namespace Business.Repository.CompanyService
{
    public class CompanyServiceRepository : BaseRepository, ICompanyServiceRepository
    {
        public CompanyServiceRepository(IMapper mapper, IDocumentQueryService documentQueryService) : base(mapper,
            documentQueryService)
        {
        }

        public IEnumerable<CompanyServiceDto> GetCompanyServices()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.CompanyService>()
                .AddColumns("Header", "Text", "Icon")
                .OrderByAscending("NodeOrder")
                .ToList()
                .Select(m => Mapper.Map<CompanyServiceDto>(m));
        }
    }
}