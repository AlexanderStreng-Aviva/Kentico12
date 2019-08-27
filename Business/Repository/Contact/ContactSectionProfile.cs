using AutoMapper;
using Business.Dto.ContactSection;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Contact
{
    public class ContactSectionProfile : Profile
    {
        public ContactSectionProfile()
        {
            CreateMap<ContactSection, ContactSectionDto>();
        }
    }
}