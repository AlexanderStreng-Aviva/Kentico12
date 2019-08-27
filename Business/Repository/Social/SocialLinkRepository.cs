using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Dto.Social;
using Business.Services.Query;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Social
{
    public class SocialLinkRepository : BaseRepository, ISocialLinkRepository
    {
        public SocialLinkRepository(IMapper mapper, IDocumentQueryService documentQueryService) : base(mapper,
            documentQueryService)
        {
        }
        public IEnumerable<SocialLinkDto> GetSocialLinks()
        {
            return DocumentQueryService.GetDocuments<SocialLink>()
                .AddColumns("Title", "Url", "Icon")
                .OrderByAscending("NodeOrder")
                .ToList()
                .Select(socialLink => Mapper.Map<SocialLinkDto>(socialLink));
        }
    }
}