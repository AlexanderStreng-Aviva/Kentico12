using AutoMapper;
using Business.Dto.CompanyService;

namespace Business.Repository.CompanyService
{
    public class CompanyServiceProfile : Profile
    {
        public CompanyServiceProfile()
        {
            CreateMap<CMS.DocumentEngine.Types.MedioClinic.CompanyService, CompanyServiceDto>()
                .ForMember(src => src.Icon, ctx => ctx.MapFrom(dst => dst.Fields.Icon));
        }
    }
}
