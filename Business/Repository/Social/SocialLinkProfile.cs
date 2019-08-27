using AutoMapper;
using Business.Dto.Social;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Social
{
    public class SocialLinkProfile : Profile
    {
        public SocialLinkProfile()
        {
            CreateMap<SocialLink, SocialLinkDto>()
                .ForMember(src => src.Icon, ctx => ctx.MapFrom(dst => dst.Fields.Icon));
        }
    }
}