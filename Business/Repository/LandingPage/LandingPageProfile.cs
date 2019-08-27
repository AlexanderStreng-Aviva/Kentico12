using AutoMapper;
using Business.Dto.LandingPage;

namespace Business.Repository.LandingPage
{
    public class LandingPageProfile : Profile
    {
        public LandingPageProfile()
        {
            CreateMap<CMS.DocumentEngine.Types.MedioClinic.LandingPage, LandingPageDto>()
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.LandingPageName))
                .ForMember(dst => dst.DocumentId, opt => opt.MapFrom(src => src.DocumentID));
        }
    }
}