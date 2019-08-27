using System.Linq;
using AutoMapper;
using Business.Dto.ContactSection;
using Business.Services.Query;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Contact
{
    public class ContactSectionRepository : BaseRepository, IContactSectionRepository
    {
        public ContactSectionRepository(IMapper mapper, IDocumentQueryService documentQueryService) : base(mapper,
            documentQueryService)
        {
        }

        public ContactSectionDto GetContactSection()
        {
            return DocumentQueryService.GetDocuments<ContactSection>()
                .TopN(1)
                .AddColumns("Title", "Subtitle", "Text")
                .ToList()
                .Select(cs => Mapper.Map<ContactSectionDto>(cs))
                .FirstOrDefault();
        }
    }
}